using System;

namespace algorithms.sorting
{
    internal class Bubble
    {
        public static void BubbleSortRecursive(int[] arr, int len)
        {
            if (len == 1)
                return;

            // One pass of sort. After this pass the largest is moved (or bubbled to end.
            for (int i = 0; i < len - 1; i++)
                if (arr[i] > arr[i + 1])
                {
                    // swap arr[i], arr[i+1]
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }

            // Largest element is fixed recur for remaining array
            BubbleSortRecursive(arr, len - 1);
        }
        public static int[] BubbleSort(int[] arr)
        {
            for(int i = 0; i < arr.Length - 2; i++)
            {
                for( int j = 0; j < arr.Length - i - 1; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
        /* Prints the array */
        static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver method
        public static void Driver()
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            BubbleSort(arr);
            Console.WriteLine("Sorted array");
            PrintArray(arr);
        }
    }
}
