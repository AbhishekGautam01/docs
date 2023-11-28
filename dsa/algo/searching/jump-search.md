# Jump Search
* The basic idea is to check fewer element than linear search by skipping some elements. 
* If suppose Jump size is m, i is iteration variable. 
* Once we find `arr[m * i] < x < arr[m * (i+ 1)]` , then we perform linear search in this interval

## Optimal Jump Size Calculation
* **Optional Jump Size**: `sq-root(N)` where N: Total Array Elements
* In the worst case, we have to do N / M jumps and if last checked value is greater than element to be searched for then, we perform m - 1 comparisons more for linear search. 
* So **total comparisons in worst case**:  (N / m + (M -1))
* the value of this function will be minimum when Jump size **m = sq-root(N)**

# Complexity
1. **Worst case time complexity**: O(√N)
2. **Average case time complexity**: O(√N)
3. **Best case time complexity**: O(1)
4. **Space complexity**: O(1)

[Detailed Explanation Here](https://iq.opengenus.org/jump-search-algorithm/)

# Pseudocode 
```
Begin
   blockSize := √size
   start := 0
   end := blockSize
   while array[end] <= key AND end < size do
      start := end
      end := end + blockSize
      if end > size – 1 then
         end := size
   done
   for i := start to end -1 do
      if array[i] = key then
         return i
   done
   return invalid location
End
```

# C# Implementation
```
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

        public static void Main()
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
```