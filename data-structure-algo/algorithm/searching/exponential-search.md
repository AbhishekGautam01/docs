# Exponential Search / Doubling Search / Galloping Search 
* It involves two steps:    
    1. Find the range where element is. 
    2. Perform binary search on it. 
* The idea is to start with sub-array size 1, compare its last element with x, then try size 2, then 4 and so on until last element of a sub-array is not greater. 
* Once we find an index i (after repeated doubling of i), we know that the element must be present between i/2 and i (Why i/2? because we could not find a greater value in previous iteration)

## Time Complexity 
1. **Worst case time complexity**: O(log i) where i is the index of the element being searched.
2. **Average case time complexity**: O(log i)
3. **Best case time complexity**: O(1)
4. **Space complexity**: O(1)
## PseudoCode 
```
Begin
   if (end – start) <= 0 then
      return invalid location
   i := 1
   while i < (end - start) do
      if array[i] < key then
         i := i * 2 //increase i as power of 2
      else
         terminate the loop
   done
   call binarySearch(array, i/2, i, key)
End
```


## C# Implementation 
```
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

        public static void Main()
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

```