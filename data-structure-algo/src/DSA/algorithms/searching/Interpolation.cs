using System;

namespace algorithms.searching
{
    public static class Interpolation
    {
        // Iterator Search 
        public static int InterpolationSearch(int[] arr, int value)
        {
            int low = 0, position = -1, high = arr.Length - 1, index = -1;
            while (low <= high)
            {
                position = (int)(((double)(high - low) / (arr[high] - arr[low]) * (value - arr[low])));
                if (arr[position] == value)
                {
                    index = position;
                    break;
                }
                else
                {
                    if (arr[position] < value)
                        low = position + 1;
                    else
                        high = position - 1;
                }
            }
            return index;
        }

        // Recursive Search
        public static int InterpolationSearchRecursive(int[] arr, int low, int high, int value)
        {
            if (low <= high)
            {
                int position = (int)(((double)(high - low) / (arr[high] - arr[low]) * (value - arr[low])));
                if (arr[position] == value)
                    return position;
                else
                {
                    if (arr[position] < value)
                        return InterpolationSearchRecursive(arr, position + 1, high, value);
                    else
                        return InterpolationSearchRecursive(arr, low, position - 1, value);
                }
            }
            return -1;
        }

        public static void Driver()
        {

            // Array of items on which search will
            // be conducted.
            int[] arr = new int[]{ 10, 12, 13, 16, 18,
                           19, 20, 21, 22, 23,
                           24, 33, 35, 42, 47 };

            // Element to be searched                      
            int x = 18;
            int n = arr.Length;
            int index = InterpolationSearchRecursive(arr, 0, n - 1, x);

            // If element was found
            if (index != -1)
                Console.WriteLine("Element found at index " +
                                   index);
            else
                Console.WriteLine("Element not found.");
        }
    }
}
