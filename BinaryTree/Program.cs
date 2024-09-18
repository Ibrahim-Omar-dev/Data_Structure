using System;
using System.Collections;
using System.Collections.Generic;
namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Binary treee
            BinaryTree<char> tree = new BinaryTree<char>();
            //tree.Insert('A');
            //tree.Insert('B');
            //tree.Insert('C');
            //tree.Insert('D');
            //tree.Insert('E');
            //tree.Insert('F');
            //tree.Insert('G');
            //tree.Insert('H');
            //tree.Insert('I');
            //tree.Print();
            //tree.Preorder();
            //tree.Inorder();
            //tree.Postorder();

            //Binary search tree
            BinaryTree<int> tree2 = new BinaryTree<int>();
            tree2.BSInsert(4);
            tree2.BSInsert(6);
            tree2.BSInsert(7);
            tree2.BSInsert(5);
            tree2.BSInsert(2);
            tree2.BSInsert(1);
            tree2.BSInsert(3);
            tree2.Print();
            tree2.BSDeleted(2);
            tree2.Print();
            tree2.BSDeleted(1);
            tree2.Print();
            tree2.BSDeleted(4);
            tree2.Print();


        }
    }
    class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
    {
        public TreeNode Root;
        public void BSInsert(Tdata data)
        {
            TreeNode newNode = new TreeNode(data);
            if (Root == null)
            {
                Root = newNode;
                return;
            }
            TreeNode CurrentNode = Root;
            while (CurrentNode != null)
            {
                if (CurrentNode.Data.CompareTo(data) > 0) //currentNode.data > data
                {
                    if (CurrentNode.Left == null)
                    {
                        CurrentNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        CurrentNode = CurrentNode.Left;
                    }
                }
                if (CurrentNode.Data.CompareTo(data) < 0) //currentNode.data > data
                {
                    if (CurrentNode.Right == null)
                    {
                        CurrentNode.Right = newNode;
                        break;
                    }
                    else
                    {
                        CurrentNode = CurrentNode.Right;
                    }
                }
            }
        }
        public bool Find(Tdata data)
        {
            TreeNode CurrentNode = Root;
            while (CurrentNode != null)
            {
                if (CurrentNode.Data.CompareTo(data) == 0)
                    return true;
                else if (CurrentNode.Data.CompareTo(data) > 0)
                    CurrentNode = CurrentNode.Left;
                else if (CurrentNode.Data.CompareTo(data) < 0)
                    CurrentNode = CurrentNode.Right;
            }
            return false;
        }
        public void Preorder()
        {
            InternelPreorder(Root);
            Console.WriteLine();
        }
        private void InternelPreorder(TreeNode node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                InternelPreorder(node.Left);
                InternelPreorder(node.Right);
            }
        }
        public void Inorder()
        {
            InternelInorder(Root);
            Console.WriteLine();
        }
        private void InternelInorder(TreeNode node)
        {
            if (node != null)
            {
                InternelInorder(node.Left);
                Console.Write(node.Data + " ");
                InternelInorder(node.Right);
            }
        }
        public void Postorder()
        {
            InternelPostorder(Root);
            Console.WriteLine();
        }
        private void InternelPostorder(TreeNode node)
        {
            if (node != null)
            {
                InternelPostorder(node.Left);
                InternelPostorder(node.Right);
                Console.Write(node.Data + " ");
            }
        }
        public int height()
        {
            return internalHeight(Root);
        }
        int internalHeight(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(
              internalHeight(node.Left),
              internalHeight(node.Right)
              );
        }
        NodeAndParent FindNodeAndParent(Tdata data)
        {
            TreeNode parent = null;
            bool left = false;
            TreeNode currentNode = Root;
            NodeAndParent nodeAndParentInfo = null;
            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(data) == 0)
                {
                    nodeAndParentInfo = new NodeAndParent()
                    {
                        Node = currentNode,
                        Parent = parent,
                        isLeft = left
                    };
                    break;
                }
                else if (currentNode.Data.CompareTo(data) > 0)
                {
                    parent = currentNode;
                    currentNode = currentNode.Left;
                    left = true;
                }
                else
                {
                    parent = currentNode;
                    currentNode = currentNode.Right;
                    left = false;
                }
            }
            return nodeAndParentInfo;

        }

        public void BSDeleted(Tdata data)
        {
            NodeAndParent nodeAndParentInfo = FindNodeAndParent(data);
            if (nodeAndParentInfo.Node == null) return;
            if (nodeAndParentInfo.Node.Left != null && nodeAndParentInfo.Node.Left != null)
            {
                BSDelete_Has_childs(nodeAndParentInfo.Node);
                
            }
            else if (nodeAndParentInfo.Node.Left != null ^ nodeAndParentInfo.Node.Right != null)
            {
                BSDelete_Has_Onechild(nodeAndParentInfo.Node);
            }
            else
            {
                BSDelete_Leaf(nodeAndParentInfo);
            }
        }

        private void BSDelete_Leaf(NodeAndParent nodeAndParent)
        {
            if (nodeAndParent.Parent == null)
            {
                this.Root = null;
            }
            else
            {
                if (nodeAndParent.isLeft)
                    nodeAndParent.Parent.Left = null;
                else
                    nodeAndParent.Parent.Right = null;

            }

        }

        private void BSDelete_Has_Onechild(TreeNode DeletedNode)
        {
            TreeNode NodeReplace = null;
            if (NodeReplace.Left != null)
            {
                NodeReplace = NodeReplace.Left;
            }
            else
            {
                NodeReplace = NodeReplace.Right;
            }
            DeletedNode.Left = NodeReplace.Left;
            DeletedNode.Right= NodeReplace.Right;
            DeletedNode.Data = NodeReplace.Data;
        }

        private void BSDelete_Has_childs(TreeNode DeletedNode)
        {
            TreeNode currentNode = DeletedNode.Right;
            TreeNode parent = null;
            while (currentNode.Left != null)
            {
                parent = currentNode;
                currentNode = currentNode.Left;
            }
            if (parent != null)
            {
                parent.Left = currentNode.Right;
            }
            else
            {
                DeletedNode.Right = currentNode.Right;
            }
            DeletedNode.Data = currentNode.Data;
        }

        public class TreeNode
        {
            public Tdata Data;
            public TreeNode Left;
            public TreeNode Right;
            public TreeNode(Tdata data)
            {
                this.Data = data;
            }
        }

        //print 
        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public void Print(int topMargin = 2, int LeftMargin = 2)
        {
            if (this.Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this.Root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString() };
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
                    if (next == item.Parent.Node.Left)
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
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
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

        class queue<Tdata>
        {
            LinkedList<Tdata> list;
            public queue()
            {
                this.list = new LinkedList<Tdata>();

            }
            public void enqueue(Tdata data)
            {
                list.AddLast(data);
            }
            public Tdata dequeue()
            {
                Tdata node_data = this.list.First.Value;
                this.list.RemoveFirst();
                return node_data;

            }
            public bool HasData()
            {
                return (list.Count > 0) ? true : false;
            }
            public Tdata peek()
            {
                return list.First();
            }
        }
        class NodeAndParent
        {
            public TreeNode Parent;
            public TreeNode Node;
            public bool isLeft;

        }
    }
}
