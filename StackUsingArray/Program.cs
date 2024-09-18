using System.Drawing;
using System.Security.Principal;

namespace StackUsingArray
{
    namespace StackUsingArray
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                var stack = new Stack(5); // Initialize with initial capacity of 5
                Console.WriteLine("Stack is Empty: " + stack.IsEmpty());

                stack.Push(5);
                stack.Push(4);
                stack.Push(3);
                stack.Push(2);
                Console.WriteLine("Size of Stack : " + stack.Size());
                stack.Print(); // Output: 2 3 4 5
                Console.WriteLine("Peek element is : " + stack.Peek());
                
                Console.WriteLine("Stack is Empty: " + stack.IsEmpty());
                while (!stack.IsEmpty())
                {
                    stack.Pop();
                    Console.WriteLine("Size of Stack : " + stack.Size());
                    stack.Print();
                    Console.WriteLine("Peek element is : " + stack.Peek());
                }

            }
        }

        public class Stack
        {
            private int[] array;
            private int initialSize;
            private int currentSize;
            private int top;

            public Stack(int initialCapacity)
            {
                this.array = new int[initialCapacity];
                this.initialSize = initialCapacity;
                this.currentSize = initialCapacity;
                this.top = -1;
            }

            public void ResizeOrNot()
            {
                if (top < currentSize - 1)
                {
                    return; // No resize needed if space available
                }

                Console.WriteLine("Resizing the stack...");
                int newSize = currentSize + initialSize;
                int[] newArray = new int[newSize];
                Array.Copy(array, newArray, this.array.Length);
                currentSize = newSize;
                array = newArray;
            }

            public bool IsEmpty()
            {
                return top < 0;
            }

            public void Push(int data)
            {
                ResizeOrNot();
                this.array[++top] = data; // Pre-increment top for efficiency
            }

            public int Pop()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Stack is Empty");
                    return -1; // Or throw an exception
                }

                int poppedData = array[top];
                Console.WriteLine("Popped: " + poppedData);
                array[top] = 0; // Reset element value after pop for clarity
                top--;
                return poppedData;
            }

            public int Peek()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Stack is Empty");
                    return 0;
                }
                return array[top];
            }

            public int Size()
            {
                return top + 1;
            }

            public void Print()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Stack is Empty");
                    return;
                }

                Console.Write("Stack: ");
                for (int i = top; i >= 0; i--)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

