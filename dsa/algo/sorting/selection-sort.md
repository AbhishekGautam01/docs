# Selection Sort 
* It repeatedly keeps sorting array until minimum element is at the starting of array at end of each iteration. 
* It maintains 2 arrays:
    1. **SubArray** that is already Sorted
    2. **Remaining SubArray** that is unsorted. 
* At end of every iteration the minimum element from unsorted array is placed to sorted subarray.

> **NOTE**: The default implementation is not stable. However there is a [Stable Selection Sort](https://www.geeksforgeeks.org/stable-selection-sort/)

## Algorithms 
```
Step 1 − Set MIN to location 0
Step 2 − Search the minimum element in the list
Step 3 − Swap with value at location MIN
Step 4 − Increment MIN to point to next element
Step 5 − Repeat until list is sorted
```

## Complexity 
1. **Worst Case Time Complexity is**: O(N^2)
2. **Average Case Time Complexity is**: O(N^2)
3. **Best Case Time Complexity is**: O(N^2)
4. **Space Complexity**: O(1)

* The number of swaps in Selection Sort are as follows:

1. **Worst case**: O(N)
2. **Average Case**: O(N)
3. **Best Case**: O(1)
> **NOTE**: Good thing about selection sort is that the swaps can never go beyond O(N)

## Pseudocode 
```
procedure selection sort 
   list  : array of items
   n     : size of list

   for i = 1 to n - 1
   /* set current element as minimum*/
      min = i    
  
      /* check the element to be minimum */

      for j = i+1 to n 
         if list[j] < list[min] then
            min = j;
         end if
      end for

      /* swap the minimum element with the current element*/
      if indexMin != i  then
         swap list[min] and list[i]
      end if
   end for
	
end procedure
```


## C# Implementation 
```
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

```