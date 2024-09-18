namespace QueueUsingLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            //check is empty before adding data
            Console.WriteLine("IsEmpty : "+ queue.IsEmpty());

            //Adding element at the end
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            //Display data after adding element
            queue.display();
            Console.WriteLine("length : " + queue.Length());
            Console.WriteLine("Peek Element is " + queue.Peek());
            int data = 3;
            Console.WriteLine($"The element {data} was found ! "+queue.IsFound(data));
            data = 4;
            Console.WriteLine($"The element {data} was found ! "+queue.IsFound(data));
            //queue.Clear();
            //queue.display();

            //remove element from the front
            queue.Dequeue();
            queue.Dequeue();

            //Display data after removing element
            queue.display();
            Console.WriteLine("length : " + queue.Length());
            Console.WriteLine("Peek Element is " + queue.Peek());

            //check is empty after adding data
            Console.WriteLine("IsEmpty : " + queue.IsEmpty());
        }
    }
    class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
    class Queue
    {
        private Node front;
        private Node rear;
        int length = 0;
        public Queue()
        {
            this.front = null;
            this.rear = null;
        }
        public void Enqueue(int data)
        {
            Node newNode = new Node(data);
            if (front == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
            length++;
        }
        public void Dequeue()
        {
            Node Temp = front;
            if (IsEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            if (front == rear)
            {
                front = rear = null;
                Console.WriteLine("Dequeue " + Temp.data);

            }
            else
            {

                front = front.next;
                Console.WriteLine("Dequeue " + Temp.data);
                Temp = null;
            }
            length--;
        }
        public bool IsFound(int data)
        {
            Node temp = front;
            while (temp != null)
            {
                if (temp.data == data)
                    return true;
                temp = temp.next;
            }
            return false;
        }
        public void Clear()
        {
            while (!IsEmpty())
                Dequeue();
        }
        public int Peek()
        {
            return IsEmpty() ? 0 : front.data;
        }
        public int Length()
        {
            return length;
        }
        public bool IsEmpty()
        {
            return front == null ? true : false;
        }
        public void display()
        {
            Node temp = front;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }
}
