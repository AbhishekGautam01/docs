# Binary Search
* Search the **sorted array** by repeatedly reducing the search sample to half. 
* Begin interval with whole array if value at middle index is less than then search in right half else search in left half. Repeatedly check this until interval is empty or value is found. 

# Complexity 
1. **Best Case Time**: O(1)
2. **Avg Case Time**: O(logN)
3. **Worst Case Time**: O(logN)
4. **Space Complexity**:
    1. **Iterative**: O(1)
    2. **Recursive**: O(N)

[Detailed Explanation here](https://iq.opengenus.org/time-complexity-of-binary-search/)


# PsuedoCode 
```
Start 
Initialize low = 0, high = size -1
Repeat until low >= high
    mid = (low+high) / 2
    If mid is equal to x 
        then return mid
    else
        if x is less than mid 
            high = mid - 1
        else 
            low = mid +  1
```

# C# Implementation
```
using System;

namespace algorithms.searching
{
    public static class Binary
    {
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


        public static void Main()
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

```