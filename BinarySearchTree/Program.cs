using System.ComponentModel.Design;
using System.Security.AccessControl;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST<int> tree = new BST<int>();
            //tree.Insert(4);
            //tree.Insert(6);
            //tree.Insert(7);
            //tree.Insert(5);
            //tree.Insert(2);
            //tree.Insert(1);
            //tree.Insert(3);
            //tree.Print();
            //tree.Delete(2);
            //tree.Print();
            //tree.Delete(1);
            //tree.Print();
            //tree.Delete(4);
            //tree.Print();
            //tree.Print();
            //Console.WriteLine(tree.Find(7));
            //Console.WriteLine(tree.Find(1));

            tree.Insert(10);
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(15);
            tree.Insert(6);
            tree.Insert(7);
            tree.Insert(9);
            tree.Insert(12);
            tree.Insert(5);
            tree.Print();

            tree.Balance();
            tree.Print();
        }
    }
    class BST<Tdata> where Tdata : IComparable<Tdata>
    {
        NodeTree root;
        public void Insert(Tdata _data)
        {
            NodeTree newNode = new NodeTree(_data);
            if (root == null)
            {
                this.root = newNode;
                return;
            }
            NodeTree currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.data.CompareTo(_data) > 0)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.left;
                    }
                }
                else
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.right;
                    }
                }
            }

        }

        public void PreOrder()
        {
            InternalPreOrder(root);
            Console.WriteLine();
        }
        void InternalPreOrder(NodeTree node)
        {
            if (node == null)
                return;
            Console.Write(node.data + " ");
            InternalPreOrder(node.left);
            InternalPreOrder(node.right);
        }
        public void InOrder()
        {
            InternalInOrder(root);
            Console.WriteLine();
        }
        void InternalInOrder(NodeTree node)
        {
            if (node == null) return;
            InternalInOrder(node.left);
            Console.Write(node.data + " ");
            InternalInOrder(node.right);
        }
        public void PostOrder()
        {
            InternalPostOrder(root);
            Console.WriteLine();
        }
        void InternalPostOrder(NodeTree node)
        {
            if (node == null) return;
            InternalPostOrder(node.left);
            InternalPostOrder(node.right);
            Console.Write(node.data + " ");
        }

        public bool Find(Tdata _data)
        {
            NodeTree currentNode = new NodeTree(_data);
            while (currentNode != null)
            {
                if (currentNode.data.CompareTo(_data) == 0)
                    return true;
                if (currentNode.data.CompareTo(_data) > 0)
                    currentNode = currentNode.left;
                else
                    currentNode = currentNode.right;
            }
            return false;
        }
        NodeAndParent FindNodeAndParent(Tdata _data)
        {
            NodeTree parent = null;
            bool left = false;
            NodeTree currentNode = root;
            NodeAndParent nodeAndParentInfo = null;
            while (currentNode != null)
            {
                if (currentNode.data.CompareTo(_data) == 0)
                {
                    nodeAndParentInfo = new NodeAndParent()
                    {
                        Node = currentNode,
                        Parent = parent,
                        Isleft = left
                    };
                    break;
                }
                else if (currentNode.data.CompareTo(_data) > 0)
                {
                    parent = currentNode;
                    currentNode = currentNode.left;
                    left = true;
                }
                else
                {
                    parent = currentNode;
                    currentNode = currentNode.right;
                    left = false;
                }
            }
            return nodeAndParentInfo;
        }
        public int Height()
        {
            return InternalHeight(this.root);
        }
        int InternalHeight(NodeTree node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(
              InternalHeight(node.right),
              InternalHeight(node.left)
              );
        }
        public void Delete(Tdata _data)
        {
            NodeAndParent nodeAndParentiInfo = this.FindNodeAndParent(_data);
            if (nodeAndParentiInfo == null) return;
            if (nodeAndParentiInfo.Node.right != null && nodeAndParentiInfo.Node.left != null)
            {
                Has_two_child(nodeAndParentiInfo.Node);
            }
            else if (nodeAndParentiInfo.Node.right != null ^ nodeAndParentiInfo.Node.left != null)
            {
                Has_One_child(nodeAndParentiInfo.Node);
            }
            else
            {
                Leaf_Child(nodeAndParentiInfo);
            }
        }

        private void Leaf_Child(NodeAndParent nodeAndParentiInfo)
        {
            if(nodeAndParentiInfo.Parent == null)
            {
                this.root = null;
            }
            else
            {
                if (nodeAndParentiInfo.Isleft)
                    nodeAndParentiInfo.Parent.left = null;
                else
                    nodeAndParentiInfo.Parent.right = null;
            }
        }

        private void Has_One_child(NodeTree DeletedNode)
        {
            NodeTree NodeToReplace = null;
            if (NodeToReplace.left != null)
            {
                NodeToReplace = NodeToReplace.left;
            }
            else
            {
                NodeToReplace=NodeToReplace.right;
            }
            DeletedNode.left = NodeToReplace.left;
            DeletedNode.right = NodeToReplace.right;
            DeletedNode.data = NodeToReplace.data;
        }

        private void Has_two_child(NodeTree DeletedNode)
        {
            NodeTree currentNode = DeletedNode.right;
            NodeTree parent = null;
            while (currentNode.left != null)
            {
                parent = currentNode;
                currentNode = currentNode.left;
            }
            if (parent != null)
            {
                parent.left = currentNode.right;
            }
            else
            {
                DeletedNode.right = currentNode.right;
            }
        }

        public void Balance()
        {
            List<Tdata> nodes = new List<Tdata>();
            InOrderToArray(this.root, nodes);
            this.root = RecursiveBalance(0, nodes.Count - 1, nodes);
        }
        void InOrderToArray(NodeTree node, List<Tdata> nodes)
        {
            if (node == null) return;
            InOrderToArray(node.left, nodes);
            nodes.Add(node.data);
            InOrderToArray(node.right, nodes);
        }
        NodeTree RecursiveBalance(int start, int end, List<Tdata> nodes)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            NodeTree newNode = new NodeTree(nodes[mid]);
            newNode.left = RecursiveBalance(start, mid - 1, nodes);
            newNode.right = RecursiveBalance(mid + 1, end, nodes);
            return newNode;
        }

        class NodeInfo
        {
            public NodeTree Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public void Print(int topMargin = 2, int LeftMargin = 2)
        {
            if (this.root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this.root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = LeftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.left ?? next.right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }
        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int Left, int Right = -1)
        {
            Console.SetCursorPosition(Left, top);
            if (Right < 0) Right = Left + s.Length;
            while (Console.CursorLeft < Right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }


        class NodeTree
        {
            public Tdata data;
            public NodeTree left;
            public NodeTree right;
            public NodeTree(Tdata data)
            {
                this.data = data;
            }
        }
        class NodeAndParent
        {
            public NodeTree Parent;
            public NodeTree Node;
            public bool Isleft;
        }
    }
}
