# Bubble Sort 
* It works by **swapping adjacent elements if they are in wrong order**. 

## Pseudocode 
```
procedure bubbleSort(A : list of sortable items)
      n := length(A)
      for i := 0 to n-1 inclusive do
          for j := 0 to n-i-1 inclusive do
              // the elements aren't in the right order
              if A[j] > A[j+1] then
                  // swap the elements
                  swap(A[j], A[j+1])
              end if
          end for
      end for
   end procedure
```

## Complexity
1. **Best Case Time Complexity**: O(N)
    1. **Best Case Number of Comparisons**: O(N)
    2. **Best Case Number of Swaps**: O(1)
2. **Average Case Time Complexity**: O(N^2)
    1. . **Average Case Swaps**: O(N^2)
3. **Worst Case Time Complexity**: O(N^2)
    1. **Worst Case Number of Comparisons**: O(N^2)
    2. **Worst Case Number of Swaps**: O(N^2)
4. **Space Complexity**: O(1)
[Detailed Explanations Here](https://iq.opengenus.org/time-space-complexity-bubble-sort/)


## C# Implementation 
```
using System;

namespace algorithms.sorting
{
    internal class Bubble
    {
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
        public static void Main()
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            BubbleSort(arr);
            Console.WriteLine("Sorted array");
            PrintArray(arr);
        }
    }
}
```