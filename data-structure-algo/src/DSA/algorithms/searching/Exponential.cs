using System;

namespace algorithms.searching
{
    public static class Exponential
    {

        public static int ExponentialSearch(int[] arr, int value)
        {
            int arrLen = arr.Length;
            if (arr[0] == value)
                return 0;

            int i = 1;
            while (i < arrLen && arr[i] <= value)
                i = i * 2;

            return BinarySearchRecursive(arr, i / 2, Math.Min(i, arrLen - 1), value);
        }

        private static int BinarySearchRecursive(int[] arr, int start, int end, int value)
        {
            if(start <= end)
            {
                int mid = start + (end - 1) / 2;
                if (arr[mid] == value)
                    return mid;

                if (arr[mid] > value)
                    return BinarySearchRecursive(arr, start, mid - 1, value);
                else 
                    return BinarySearchRecursive(arr, mid + 1, end, value);
            }
            return -1; 
        }

        public static void DriverExponentialSearch()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int n = arr.Length;
            int x = 10;
            int result = ExponentialSearch(arr, x);
            if (result == -1)
                Console.Write("Element is not present in array");
                else
                Console.Write("Element is present at index " + result);
        }
    }
}
