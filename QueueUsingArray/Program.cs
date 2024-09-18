namespace QueueUsingArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(5);
            //check is empty before adding element
            queue.IsEmpty();
            //Adding element to the end
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            //Display element
            queue.display();
            queue.Peek();
            Console.WriteLine("Rear element is : " + queue.Getrear());
            Console.WriteLine("Length = " + queue.GetLength());
            
            //Removing element from the start
            Console.WriteLine("Dequeueing : ");
            queue.Dequeue();
            queue.Dequeue();
            queue.display();

            queue.Peek();
            Console.WriteLine("Rear element is : "+queue.Getrear());
            Console.WriteLine("Length = "+queue.GetLength());
            //check is empty 
            queue.IsEmpty();

        }
        class Queue
        {
            private int[] array;
            private int initialSize;
            private int currentSize;
            private int front;
            private int rear;

            public Queue(int initialCapacity)
            {
                this.array = new int[initialCapacity];
                this.initialSize = initialCapacity;
                this.currentSize = initialCapacity;
                this.front = -1;
                this.rear = -1;
            }
            public void ResizeOrNot()
            {
                if (rear < currentSize - 1)
                    return;
                Console.WriteLine("Resizing the stack...");
                int newSize = currentSize + initialSize;
                int[] newArray = new int[newSize];
                Array.Copy(array, newArray, this.array.Length);
                currentSize = newSize;
                array = newArray;
            }
            public bool IsEmpty()
            {
                return front < 0 ? true : false;
            }
            public void Enqueue(int data)
            {
                ResizeOrNot();
                if (this.front == -1)
                    front = 0;
                array[++rear] = data;
            }
            public void Dequeue()
            {
                if (IsEmpty()){
                    Console.WriteLine("The Queue is Empty");
                    return;
                }
                else
                {
                    Console.WriteLine("Dequeue : " + array[0]);
                    for (int i = 0; i <= rear; i++)
                    {
                        array[i] = array[i + 1];
                    }
                    
                    rear--;
                }
            }
            public void Peek()
            {
                Console.WriteLine("Peek element is : "+array[front]);
            }
            public bool IsFound(int data)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = data;
                    return true;
                }
                return false;
            }
           
            public int Getrear()
            {
                return array[rear];
            }
            public int GetLength()
            {
                return rear+1;
            }
            public void display()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Queue is empty");
                }
                Console.Write("Element of Queue : ");
                for (int i = 0; i <= rear; i++)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
