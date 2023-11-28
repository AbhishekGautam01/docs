using System;

namespace algorithms.sorting
{
    internal class Selection
    {
        public static int[] SelectionSort(int[] input)
        {
            int arrLen = input.Length;

            for(int i = 0; i < arrLen - 1; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < arrLen-1; j++)
                {
                    if(input[j] < input[minIndex])
                        minIndex = j;
                }

                int temp = input[i];
                input[i] = input[minIndex];
                input[minIndex] = temp;
            }
            return input;
        }
        static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }


        public static void Main()
        {
            int[] arr = { 64, 25, 12, 22, 11 };
            SelectionSort(arr);
            Console.WriteLine("Sorted array");
            PrintArray(arr);
        }
    }
}
