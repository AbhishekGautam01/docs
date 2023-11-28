# Fibonacci Search 
* it is **comparison based** technique that uses Fibonacci number to search an element in sorted array. 
* It works on sorted array, divide and conquer and has log(N) complexity

## Differences with Binary Search
* It divides the array into **un-equal parts**
* Binary search uses a **division operator to divide range** 
* Fibonacci search examines relatively closer elements in subsequent steps. So when the input array is big that cannot fit in CPU cache or even in RAM. 

## Algorithms 
1. Firstly, we need to find F(k) which is kth fibonacci number which is greater than or equal to the size of array (n).
2. If F(k) = 0, then we need to stop here and print the message as element not found.
3. Set variable offset = -1.
4. We need to set i = min( offset + F(k-2), n-1)
5. We will check:
    > If search element (s) == Array[i] then, return i and stop the search.
    If search element (s) > Array[i] then, k = k-1, offset = I and we need to repeat steps 4,5.
    If search element (s) < Array[i] then, k = k-2 repeat steps 4,5.

## C# Implementation
```
using System;

namespace algorithms.searching
{
    internal class Fibonacci
    {
        // Utility function to find minumum of two elements
        public static int Min(int x, int y)
        {
            return (x <= y) ? x : y;
        }

        // returns index of item if present, else returns -1
        public static int FibonaccianSearch(int[] arr, int item, int arrLen)
        {
            // Initialize fibonacci numbers 
            int fibM2 = 0; // (m-2)th fibonacci no.
            int fibM1 = 1; // (m-`)th fibonacci no.
            int fibM = fibM2 + fibM1; // (m)th fibonacci no.

            // fibM is going to store the smallest fibonacci number greater than or equals to n
            while (fibM < arrLen)
            {
                fibM2 = fibM1;
                fibM1 = fibM;
                fibM = fibM2 + fibM1;
            }

            //Marks the eliminated range from front. 
            int offset = -1;

            /* while there are elements to be inspected.
            Note that we compare arr[fibMm2] with x.
            When fibM becomes 1, fibMm2 becomes 0 */
            while (fibM > 1)
            {
                // Check if fibMm2 is a valid location
                int i = Min(offset + fibM2, arrLen - 1);

                /* If x is greater than the value at
                index fibMm2, cut the subarray array
                from offset to i */
                if (arr[i] < item)
                {
                    fibM = fibM1;
                    fibM1 = fibM2;
                    fibM2 = fibM - fibM1;
                    offset = i;
                }

                /* If x is less than the value at index
                fibMm2, cut the subarray after i+1 */
                else if (arr[i] > item)
                {
                    fibM = fibM2;
                    fibM1 = fibM1 - fibM2;
                    fibM2 = fibM - fibM1;
                }

                /* element found. return index */
                else
                    return i;
            }

            /* comparing the last element with x */
            if (fibM1 == 1 && arr[arrLen - 1] == item)
                return arrLen - 1;

            /*element not found. return -1 */
            return -1;
        }

        // driver code
        public static void Main()
        {
            int[] arr = { 10, 22, 35, 40, 45, 50,
                      80, 82, 85, 90, 100,235 };
            int n = 12;
            int x = 235;
            int ind = FibonaccianSearch(arr, x, n);
            if (ind >= 0)
                Console.Write("Found at index: " + ind);
            else
                Console.Write(x + " isn't present in the array");
        }

    }

}
```