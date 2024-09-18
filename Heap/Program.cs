using System.ComponentModel;
using System.Net.WebSockets;

namespace Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap();
            heap.insertHeapMin(8);
            heap.insertHeapMin(4);
            heap.insertHeapMin(6);
            heap.print();
        }
    }
    class Heap
    {
        public int size;
        public int[] list;
        public Heap()
        {
            size = 0;
            list = new int[size];
        }
        public void ReSizeOrNot()
        {

            if (size < list.Length)
                return;
            else
            {
                size = size + 5;
                Console.WriteLine("Array was resize : ");
            }
        }
        public void insertHeapMin(int data)
        {
            ReSizeOrNot();
            
            int i =size++;
            this.list[i] = data;
            this.size++;
            int Parent_Index = (i - 1) / 2;
            while (i != 0 && list[i] < list[Parent_Index])
            {
                var temp = list[i];
                list[i]= list[Parent_Index];
                list[Parent_Index] = temp;
                i = Parent_Index;
                Parent_Index = (i - 1) / 2;
            }
        }
        public int Size()
        {
            return size;
        }

        public void print()
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
