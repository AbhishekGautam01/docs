using System;

namespace algorithms.sorting
{
    internal class Insertion
    {
        public static int[] InsertionSort(int[] arr) { 
            int arrLen = arr.Length;
            // i starts with 1 as we assume one element is always sorted so we dont need to check element on  0th index.
            for(int i = 1; i < arrLen - 1; ++i)
            {
                int key = arr[i]; // It is like a temp storage for current element, so that element doesnt get lost during shifting 
                int j = i - 1;
                while(j >= 0 && arr[j] > key)
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j+1] = key;
            }
            return arr; 
        }

        // A utility function to print
        // array of size n
        static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.Write("\n");
        }

        // Driver Code
        public static void Driver()
        {
            int[] arr = { 12, 11, 13, 5, 6 };
            Insertion.InsertionSort(arr);
            PrintArray(arr);
        }
    }
}
