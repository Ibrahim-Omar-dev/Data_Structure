using System;
using System.Data;
using System.Dynamic;

namespace StackUsingLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new Stack<int>();
            //Check IsEmpty befor Push any data;
            Console.WriteLine("Is Empty : " + list.IsEmpty());

            //Stack Push
            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Push(5);
            list.Display();

            Console.WriteLine("Length of Items ="+list.GetLength());

            Console.WriteLine("Peek element = " + list.Peek());

            //Stack Pop
            list.Pop();
            list.Pop();
            list.Display();

            Console.WriteLine("Length of Items =" + list.GetLength());

            Console.WriteLine("Peek element = " + list.Peek());

            //Check IsEmpty after Push elements
            Console.WriteLine("Is Empty : " + list.IsEmpty());



        }
        public class Node<T>
        {
            public T data;
            public Node<T> next;
            public Node(T data)
            {
                this.data = data;
            }
        }
        public class Stack<T>
        {
            public Node<T> top;
            public int length = 0;
            public Stack()
            {
                top = null;
            }
            public bool IsEmpty()
            {
                return top == null;
            }
            public void Push(T data)
            {
                Node<T> node = new Node<T>(data);
                node.next = top;
                top = node;
                length++;
            }
            public void Pop()
            {
                if (top == null)
                {
                    Console.WriteLine("The stack is null");
                    return;
                }
                else
                {
                    var temp = top;
                    top = top.next;
                    Console.WriteLine("Pop " + temp.data);
                    temp = null;
                    length--;
                    
                }
            }
            public T Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Stack Is Empty");
                }
                return top.data;
            }
            public void Display()
            {
                var current = top;
                Console.Write("\nItems in the stack : [ ");
                while (current != null)
                {
                    Console.Write(current.data + " ");
                    current = current.next;

                }
                Console.WriteLine("]");
            }
            public int GetLength()
            {
                return length;
            }
        }
    }
}
