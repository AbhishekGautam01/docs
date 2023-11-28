# Insertion Sort
* It is a simple sort in which array is virtually split into sorted and unsorted part, an element from unsorted part is placed at correct position is sorted part. 
* It has **lesser comparison than bubble sort**

## Complexity 
1. **Worst Case Time Complexity**: o(n^2)
2. **Avg Case Time Complexity**: O(n^2)
3. **Best Case Time Complexity**: O(n)
4. **Space Complexity**: O(1)

## Algorithm
```
To sort an array of size n in ascending order: 
1: Iterate from arr[1] to arr[n] over the array. 
2: Compare the current element (key) to its predecessor. 
3: If the key element is smaller than its predecessor, compare it to the elements before. Move the greater elements one position up to make space for the swapped element.
```

## Pseudocode 
```
for i = 0 to n
    key = A[i]
    j = i - 1
    while j >= 0 and A[j] > key
        A[j + 1] = A[j]
        j = j - 1
    end while
A[j + 1] = key
end for
```

## C# Implementation
```
using System;

namespace algorithms.sorting
{
    internal class Insertion
    {
        public static int[] InsertionSort(int[] arr) { 
            int arrLen = arr.Length;
            // i starts with 1 as we assume one element is always sorted so we dont need to check element on  0th index.
            for(int i = 1; i < arrLen - 1; ++i)
            {
                int key = arr[i]; // It is like a temp storage for current element, so that element doesn't get lost during shifting 
                int j = i - 1;
                while(j >= 0 && arr[j] > key)
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j+1] = key;
            }
            return arr; 
        }

        // A utility function to print
        // array of size n
        static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.Write("\n");
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 12, 11, 13, 5, 6 };
            Insertion.InsertionSort(arr);
            PrintArray(arr);
        }
    }
}

```