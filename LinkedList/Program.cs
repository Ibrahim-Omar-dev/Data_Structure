using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Transactions;
using System.Xml.Linq;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertFirst(0);
            list.InsertFirst(1);
            Console.WriteLine("Item was insert first : ");
            list.print();

            list.InsertLast(4);
            list.InsertLast(3);
            Console.WriteLine("Item was insert at the last : ");
            list.print();

            Console.WriteLine("Item was Insert at Position");
            list.InsertAtPosition(1, 2);
            list.print();

            Console.WriteLine("Item Was insert After Position");
            list.InsertAfter(list.Find(1), 5);
            list.print();

            Console.WriteLine("Item Was insert Before Position");
            list.InsertBefore(list.Find(1), 5);
            list.print();

            list.print();
            int data = 5;
            int counter = list.coutItem(data);
            Console.WriteLine($"number of Item {data} is {counter}");
            Console.WriteLine("List Befor Deleted : ");
            list.print();

            list.DeleteNode(list.Find(1));
            list.DeleteItem(5);
            Console.WriteLine("After deleted : ");
            list.print();

            
            if(list.search(5)==-1)
                Console.WriteLine("Item was not found ");
            else
                Console.WriteLine($"The Item was found in Position {list.search(5)}");

            
        }
    }
    public class LinkedListNode
    {
        public int data;
        public LinkedListNode next;
        public LinkedListNode(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
    public class LinkedListIterator
    {
        public LinkedListNode currentNode;

        // default constructor for the iterator
        public LinkedListIterator()
        {
            this.currentNode = null;
        }

        // constructor for the iterator with a starting node
        public LinkedListIterator(LinkedListNode node)
        {
            this.currentNode = node;
        }

        // return the current node's data
        public int data()
        { 
            return  currentNode.data;
        }

        // advance to the next node and return the iterator
        public LinkedListIterator next()
        {
            this.currentNode = this.currentNode.next;
            return this;
        }

        // return the current node
        public LinkedListNode Current()
        {
            return this.currentNode;
        }
    }
    public class LinkedList
    {
        private int length;
        public LinkedListNode head = null;
        public LinkedListNode tail = null;
        public void InsertFirst(int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            if (length == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = this.head;
                this.head = newNode;
            }
            length++;
        }
        public void InsertLast(int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
            this.length++;
        }
        public void InsertAfter(LinkedListNode node, int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null)
                tail.next = newNode;
            this.length++;
        }
        public void InsertAtPosition(int index, int data)
        {
            if (index < 0 || index > length)
                Console.WriteLine("Sorry you Enter index out of range Please try again");
            else
            {
                if (index == 0)
                    InsertFirst(data);
                else if (index == length - 1)
                    InsertLast(data);
                else
                {
                    LinkedListNode newNode = new LinkedListNode(data);
                    LinkedListNode itr = head;
                    for (int i = 1; i < index; i++)
                        itr = itr.next;
                    newNode.next = itr.next;
                    itr.next = newNode;
                    length++;
                }
            }

        }
        public void InsertBefore(LinkedListNode node, int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.next = node;
            LinkedListNode parentNode = FindParent(node);
            if (parentNode == null)
                this.head = newNode;
            else
                parentNode.next = newNode;
            length++;
        }
        public void DeleteNode(LinkedListNode node)
        {
            if (head == tail)
            {
                this.head = null;
                this.tail = null;
            }
            if (head == node)
                head = node.next;
            else
            {
                LinkedListNode parentNode = FindParent(node);
                if (tail == node)
                    tail = parentNode;
                else
                    parentNode.next = node.next;

            }
            node = null;
            length--;
        }
        public void DeleteItem(int data)
        {
            LinkedListNode item = Find(data);
            if (item == null)
                Console.WriteLine("Sorry Item Was not found Please try another Item ");
            else
            {
                DeleteNode(item);
                
            }
        }
        public int search(int data)
        {
            LinkedListNode node = head;
            int position = 0;
            while(node != null)
            {
                if (node.data == data)
                    return position;
                node = node.next;
                position++;
            }
            return -1;
        }
        public int coutItem(int data) { 
            LinkedListNode node = head;
            int count = 0;
            while (node != null) { 
                if(node.data == data)
                    count++;
                node = node.next;
            }
            return count;
        }
        //public void Remove(int item)
        //{
        //    if (length == 0)
        //    {
        //        Console.WriteLine("Cannot remove from empty list");
        //        return;
        //    }

        //    LinkedListNode current, trailCurrent;

        //    if (head.data == item) // Delete the first element, special case
        //    {
        //        current = head;
        //        head = head.next;
        //        current = null; // Dereference the node to help with garbage collection
        //        length--;
        //        if (length == 0)
        //            tail = null;
        //    }
        //    else
        //    {
        //        current = head.next;
        //        trailCurrent = head;

        //        while (current != null)
        //        {
        //            if (current.data == item)
        //                break;

        //            trailCurrent = current;
        //            current = current.next;
        //        }

        //        if (current == null)
        //        {
        //            Console.WriteLine("The item is not there");
        //        }
        //        else
        //        {
        //            trailCurrent.next = current.next;
        //            if (tail == current) // Delete the last item
        //                tail = trailCurrent;
        //            current = null; // Dereference the node to help with garbage collection
        //            length--;
        //        }
        //    }

        //}



        public void print()
        {
            LinkedListNode current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
        public LinkedListNode Find(int data)
        {
            for (LinkedListIterator itr = this.Begin(); itr.Current != null; itr.next())
            {
                if (itr.data() == data)
                    return itr.Current();
            }
            return null;
        }
        public LinkedListNode FindParent(LinkedListNode node)
        {
            for (LinkedListIterator itr = this.Begin(); itr.Current() != null; itr.next())
            {
                if (itr.Current().next == node)
                {
                    return itr.Current();
                }
            }
            return null;
        }
        public int GetLength()
        {
            return this.length;
        }
        public LinkedListIterator Begin()
        {
            LinkedListIterator itr = new LinkedListIterator(this.head);
            return itr;
        }
    }

}
