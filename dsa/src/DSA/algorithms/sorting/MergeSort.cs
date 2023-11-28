using System;

namespace algorithms.sorting
{
    internal static class MergeSort
    {
        public static void Merge(int[] arr, int left, int mid, int right)
        {
            int leftSubArrLen = mid - left + 1;
            int rightSubArrLen = right - mid;

            int[] leftSubArr = new int[leftSubArrLen];
            int[] rightSubArr = new int[rightSubArrLen];
            int leftIndex , rightIndex ; 
            

            for (leftIndex = 0; leftIndex < leftSubArrLen; leftIndex++)
                leftSubArr[leftIndex] = arr[left + leftIndex];
            for(rightIndex = 0; rightIndex < rightSubArrLen; rightIndex++)
                rightSubArr[rightIndex] = arr[mid + 1 + rightIndex];

            leftIndex = rightIndex = 0;

            int mergedArrIndex = 0;

            while(leftIndex < leftSubArrLen && rightIndex < rightSubArrLen)
            {
                if (leftSubArr[leftIndex] <= rightSubArr[rightIndex])
                {
                    arr[mergedArrIndex] = leftSubArr[leftIndex];
                    leftIndex++;
                } else
                {
                    arr[mergedArrIndex] = rightSubArr[rightIndex];
                    rightIndex++;
                }
                mergedArrIndex++;
            }

            while(leftIndex < leftSubArrLen)
            {
                arr[mergedArrIndex] = leftSubArr[leftIndex];
                leftIndex++;
                mergedArrIndex++;
            }

            while(rightIndex < rightSubArrLen)
            {
                arr[mergedArrIndex++] = rightSubArr[rightIndex];
                rightIndex++;
                mergedArrIndex++;
            }
        }

        public static void Sort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int mid = (left + right) /2;
                Sort(arr, left, mid);
                Sort(arr, mid+1, right);
                Merge(arr, left, mid, right);
            }
        }

        // A utility function to
        // print array of size n */
        static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver code
        public static void Driver(String[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Given Array");
            PrintArray(arr);
            MergeSort.Sort(arr, 0, arr.Length - 1);
            PrintArray(arr);
        }
    }
}
