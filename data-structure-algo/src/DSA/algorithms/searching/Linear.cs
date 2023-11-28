using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms.searching
{
    public static class Linear
    {
        public static int LinearSearch(int[] input , int value)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == value)
                    return i;
            }
            return -1;
        }

        public static void Driver()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int x = 10;

            // Function call
            int result = LinearSearch(arr, x);
            if (result == -1)
                Console.WriteLine(
                    "Element is not present in array");
            else
                Console.WriteLine("Element is present at index "
                                  + result);
        }
    }
}
