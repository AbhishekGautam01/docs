using System;

namespace algorithms.searching
{
    public static class Jump
    {
        public static int JumpSearch(int[] arr, int value)
        {
            int arrLen = arr.Length;
            int jumpSize = (int)Math.Floor(Math.Sqrt(arrLen));

            int previous = 0;

            // Finding block in which the item is present if any
            while(arr[Math.Min(jumpSize, arrLen) - 1] < value)
            {
                previous = jumpSize;
                jumpSize += (int)Math.Floor(Math.Sqrt(arrLen));
                if (previous >= arrLen)
                    return -1;
            }
            
            //Doing Linear Search to find value
            while(arr[previous] < value)
            {
                previous ++;
                if (previous == Math.Min(jumpSize, arrLen))
                    return -1;
            }

            if (arr[previous] == value)
                return previous;

            return -1;
        }

        public static void Driver()
        {
            int[] arr = { 0, 1, 1, 2, 3, 5, 8, 13, 21,
                    34, 55, 89, 144, 233, 377, 610};
            int x = 55;

            // Find the index of 'x' using Jump Search
            int index = JumpSearch(arr, x);

            // Print the index where 'x' is located
            Console.Write("Number " + x +
                                " is at index " + index);
        }
    }
}
