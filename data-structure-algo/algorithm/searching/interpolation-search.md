# Interpolation Search 
* Interpolation search is **improvement on binary search** for instances where **values in a sorted array is uniformly distributed**. 
* **Uniform distribution**: Uniform distribution means that the probability of a randomly chosen key being in a particular range is equal to it being in any other range of the same length
* Interpolation search may go to a different position closer to key being searched instead of middle. 

## Complexity 
1. **Best Case Time Complexity**: O(1)
2. **Avg Case Time Complexity**: O(log(logN))
3. **Worst Case Time Complexity**: O(N)
4. **Space Complexity**: O(1)

[Detailed Explanation Here](https://iq.opengenus.org/time-complexity-of-interpolation-search/)


## Interpolation Search Probing Formula 
```
// The idea of formula is to return higher value of pos
// when element to be searched is closer to arr[hi]. And
// smaller value when closer to arr[lo]

position(mid) = low + ((target – arr[low]) * (high – low) / (arr[high] – arr[low]))

arr[] ==> Array where elements need to be searched
x     ==> Element to be searched
lo    ==> Starting index in arr[]
hi    ==> Ending index in arr[]
```

## Algorithm 

1. Calculate the value of pos(mid) using the probing formula and start search from there.
2. If the pos value is equal to target, return index of value and terminate.
3. If it does not match, probe position to find new mid using probing formula.
4. If value is greater than arr[pos] search the higher sub-array, right sub-array.
5. If value is greater than arr[pos] search the lower sub-array, left sub-array.
6. Repeat until the target is found, terminate when the sub-array reduces to zero

# C# Implementation 
```
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

        public static void Main()
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

```