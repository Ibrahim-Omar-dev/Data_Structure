using System;

namespace DoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            doublyLinkedList list = new doublyLinkedList();

            //Example insert first
            list.InsertFirst(3);
            list.InsertFirst(2);
            list.InsertFirst(1);
            Console.WriteLine("Insert first ");
            list.Print();

            //Example insert last
            list.InsertLast(7);
            list.InsertLast(8);
            list.InsertLast(9);
            Console.WriteLine("Insert last ");
            list.Print();

            Console.WriteLine("Insert before ");
            list.InsertBefore(list.Find(8), 100); // Example where the node is found
            list.Print();
            list.InsertBefore(list.Find(101), 5); // Example where the node is not found
            list.Print();

            //Example deleted head
            Console.WriteLine("Delete head");
            list.DeleteHead();
            list.Print();

            //Example deleted tail
            Console.WriteLine("Delete tail");
            list.DeleteTail();
            list.Print();

            //Example deleted node where the node is not found
            Console.WriteLine("Delete node");
            list.DeleteNode(list.Find(200));
            list.Print();
            
            //Example deleted node where the node is  found
            Console.WriteLine("Delete node");
            list.DeleteNode(list.Find(100));
            list.Print();

            //Get length
            Console.WriteLine("The length of the list = "+list.GetLength());

            //Get last Element
            Console.WriteLine("The last element is : "+list.GetLast());
            
            //Get first Element
            Console.WriteLine("The last element is : "+list.GetFirst());


        }
    }
    class LinkedListNode
    {
        public int data;
        public LinkedListNode next;
        public LinkedListNode previous;
        public LinkedListNode(int data)
        {
            this.data = data;
            this.next = null;
            this.previous = null;
        }
    }
    class LinkedListIterator
    {
        private LinkedListNode currentNode;
        public LinkedListIterator(LinkedListNode currentNode)
        {
            this.currentNode = currentNode;
        }
        public int data()
        {
            return this.currentNode.data;
        }
        public LinkedListIterator next()
        {
            this.currentNode = this.currentNode.next;
            return this;

        }
        public LinkedListIterator previous()
        {
            this.currentNode = this.currentNode.previous;
            return this;
        }
        public LinkedListNode Current()
        {
            return this.currentNode;
        }
    }
    class doublyLinkedList
    {
        public LinkedListNode head;
        public LinkedListNode tail;
        private int length = 0;
        public doublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }
        public void InsertFirst(int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = this.head;
                this.head.previous = newNode;
                this.head = newNode;
            }
            length++;
        }
        public void InsertLast(int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            if (this.head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.previous = this.tail;
                this.tail.next = newNode;
                this.tail = newNode;
            }
            length++;
        }
        public void InsertAfter(LinkedListNode node, int data)
        {
            if (node == null)
                return;
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.next = node.next;
            newNode.previous = node;
            node.next = newNode;
            if (newNode.next != null)
            {
                newNode.next.previous = newNode;
            }
            if (this.tail == node)
            {
                this.tail = newNode;
            }
            length++;
        }

        public void InsertBefore(LinkedListNode node, int data)
        {
            if (node == null)
                return;
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.next = node;
            newNode.previous = node.previous;

            if (node.previous != null)
            {
                node.previous.next = newNode;
            }
            node.previous = newNode;

            if (node == this.head)
            {
                this.head = newNode;
            }
            length++;
        }
        public void DeleteHead()
        {
            LinkedListNode node = this.head;
            this.head = node.next;
            node.next.previous = null;
            length--;
        }
        public void DeleteTail()
        {
            LinkedListNode node = this.tail;
            this.tail = node.previous;
            node.previous.next = null;
            length--;
        }
        public void DeleteNode(LinkedListNode node)
        {
            if (node == null) 
                return;
            else if(this.head == this.tail)
            {
                head = null;
                tail = null;
                length--;
            }
            else if(this.head == node)
                 DeleteHead();
            else if(this.tail == node)
                DeleteTail();
            else
            {
                node.previous.next = node.next;
                node.next.previous = node.previous;
                node = null;
                length--;
            }
        }


        public int GetLength()
        {
            return length;
        }
        public LinkedListIterator Begin()
        {
            LinkedListIterator itr = new LinkedListIterator(this.head);
            return itr;
        }
        public void Print()
        {
            for (LinkedListIterator itr = this.Begin(); itr.Current() != null; itr.next())
            {
                Console.Write(itr.data() + " ");
            }
            Console.WriteLine();
        }
        public LinkedListNode Find(int data)
        {
            for (LinkedListIterator itr = this.Begin(); itr.Current() != null; itr.next())
            {
                if (itr.data() == data)
                    return itr.Current();
            }
            Console.WriteLine($"Data {data} was not found");
            return null;
        }
        public int GetLast()
        {
            return this.tail.data;
        }
         public int GetFirst()
        {
            return this.head.data;
        }
        

    }
}

