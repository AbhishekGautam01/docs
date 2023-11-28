using System;

namespace algorithms.searching
{
    public static class Binary
    {
        // Iterative Method
        public static int BinarySearch(int[] arr, int value)
        {
            int low = 0, high = arr.Length - 1;
            while(low <= high)
            {
                int mid = (low + high) / 2;
                if(arr[mid] == value) return mid;
                else
                {
                    if(arr[mid] < value)
                        low = mid + 1;
                    else 
                        high = mid - 1;
                }
            }
            return -1;
        }

        // Recurisve Method
        public static int ReccursiveBinarySearch(int[] arr, int low , int high, int value)
        {
            if(low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == value) return mid;
                else
                {
                    if(arr[mid] > value)
                        return ReccursiveBinarySearch(arr, low, mid - 1, value);
                    else 
                        return ReccursiveBinarySearch(arr,mid + 1, high, value);
                }
            }
            return -1;
        }


        public static void DriverBinarySearch()
        {

            int[] arr = { 2, 3, 4, 10, 40 };
            int n = arr.Length;
            int x = 10;

            int result = BinarySearch(arr, x);

            if (result == -1)
                Console.WriteLine("Element not present");
            else
                Console.WriteLine("Element found at index "
                                  + result);
        }
    }
}
