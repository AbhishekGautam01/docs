# Recursive Bubble Sort 
* it has no performance or implementation advantages. 

## Algorithm 
```
Base Case: If array size is 1, return.
Do One Pass of normal Bubble Sort. This pass fixes last element of current subarray.
Recur for all elements except last of current subarray.
```

## C# Implementation
```
public static void BubbleSortRecursive(int[] arr, int len)
        {
            if (len == 1)
                return;

            // One pass of sort. After this pass the largest is moved (or bubbled to end.
            for (int i = 0; i < len - 1; i++)
                if (arr[i] > arr[i + 1])
                {
                    // swap arr[i], arr[i+1]
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }

            // Largest element is fixed recur for remaining array
            BubbleSortRecursive(arr, len - 1);
        }
```