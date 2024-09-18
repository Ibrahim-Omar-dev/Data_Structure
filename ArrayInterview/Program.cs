using System.Xml.Linq;
using System;
using Microsoft.VisualBasic;
using System.Globalization;

namespace ArrayInterview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 20, 4, 1, 5 };
            int[] arr2 = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            int[] arrnegative = { -1, 2, -3, 4, 5, 6, -7, 8, 9 };
            int n = arr.Length;
            //8-
            RotateArray(arr);
            //7-
            //ArrangedArray(arrnegative);
            //6-
            //Array.Sort(arr2);
            //foreach (int i in arr2)
            //{
            //    Console.Write(i+" ");
            //}
            //Console.WriteLine();
            //Sort012(arr2);
            //5-
            //int result= countOccurrences(arr, n,1);
            //Console.WriteLine(result);
            //4
            //int result=kthSmallest(arr, n-5);
            //Console.WriteLine(result);
            //3
            //ReverseArray(arr);
            //2
            //MinMaxNum(arr,n);
            ////1-
            //Console.WriteLine(arr.Max());built in function;
            //Console.Write("Index of a peak point is " +
            //                 FindPeak(arr, n));
        }
        /*1-Given an array arr of n elements that is first strictly increasing and 
         * then maybe strictly decreasing, find the maximum element in the array.*/
        static int FindPeak(int[] arr, int n)
        {
            // First or last element is peak element
            if (n == 1)
                return 0;
            if (arr[0] >= arr[1])
                return 0;
            if (arr[n - 1] >= arr[n - 2])
                return n - 1;

            // Check for every other element
            for (int i = 1; i < n - 1; i++)
            {

                // Check if the neighbors are smaller
                if (arr[i] >= arr[i - 1] &&
                    arr[i] >= arr[i + 1])
                    return i;
            }
            return 0;
        }
        //2- write functions to find the minimum and maximum elements in it.
        static void MinMaxNum(int[] arr, int n)
        {
            Array.Sort(arr);
            Console.WriteLine("Min number is " + arr[0]);
            Console.WriteLine("Max number is " + arr[n - 1]);
        }
        //3-Reversing an array
        static void ReverseArray(int[] arr)
        {
            int length = arr.Length;
            int[] reversedArr = new int[length];
            for (int i = 0; i < length; i++)
            {
                reversedArr[i] = arr[length - i - 1];
            }
            Console.Write("Reversed Array: ");
            foreach (int num in reversedArr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        /*4-Given an array arr[] of N distinct elements and a number K, where K is smaller
         * than the size of the array. Find the K’th smallest element in the given array.*/
        static int kthSmallest(int[] arr, int k)
        {
            Array.Sort(arr);
            return arr[k - 1];
        }
        /*5-a sorted array arr[] of size N and a number X, you need to find the number
         * of occurrences of X in given array*/
        static int countOccurrences(int[] arr, int length, int num)
        {
            int count = 0;
            foreach (var item in arr)
            {
                if (num == item)
                    count++;
            }
            return count;
        }
        /*6- an array A[] consisting of only 0s, 1s, and 2s. The task is to sort the array, 
         * i.e., put all 0s first, then all 1s and all 2s in last.*/
        static void Sort012(int[] arr)
        {
            int c0 = 0, c1 = 0, c2 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0) c0 += 1;
                else if (arr[i] == 1) c1 += 1;
                else if (arr[i] == 2) c2 += 1;
            }
            int idx = 0;

            for (int i = 0; i < c0; i++)
                arr[idx++] = 0;
            for (int i = 0; i < c1; i++)
                arr[idx++] = 1;
            for (int i = 0; i < c2; i++)
                arr[idx++] = 2;
            foreach (var item in arr)
                Console.Write(item + " ");
        }
        /*7-An array contains both positive and negative numbers in random order. Rearrange
         * the array elements so that all negative numbers appear before all positive numbers.*/
        static void ArrangedArray(int[] arr)
        {
            int j = 0, temp;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    j++;
                }
            }
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
        /*8-Given an array, the task is to cyclically rotate the array clockwise by one time.*/
        static void RotateArray(int[] arr)
        {

            int last_el = arr[arr.Length - 1], i;

            for (i = arr.Length - 1; i > 0; i--)
                arr[i] = arr[i - 1];

            arr[0] = last_el;
            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }
        } 
    }
}
