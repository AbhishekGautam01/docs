using System;

namespace algorithms.sorting
{
    internal static class Quick
    {
        public static void Swap(int[] arr, int firstIndex, int secondIndex)
        {
            int temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        /* This function takes last element as pivot, places
   the pivot element at its correct position in sorted
   array, and places all smaller (smaller than pivot)
   to left of pivot and all greater elements to right
   of pivot */
        public static int Partition(int[] arr, int low, int high)
        {
            //selecting end element as pivot
            int pivot = arr[high];

            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller 
                // than the pivot
                if (arr[j] < pivot)
                {

                    // Increment index of 
                    // smaller element
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }

        /* The main function that implements QuickSort
          arr[] --> Array to be sorted,
          low --> Starting index,
          high --> Ending index
        */
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place 
                int pi = Partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        // Function to print an array 
        static void PrintArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
                Console.WriteLine(arr[i] + " ");

            Console.WriteLine();
        }

        // Driver Code
        public static void main(String[] args)
        {
            int[] arr = { 10, 7, 8, 9, 1, 5 };
            int n = arr.Length;

            QuickSort(arr, 0, n - 1);
            Console.WriteLine("Sorted array: ");
            PrintArray(arr, n);
        }
    }
}
