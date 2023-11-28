# Merge Sort 
* Like quick sort, this also uses **divide and conquer**. 
* It splits the array into two half ,then calls it self on the two half and merges the sorted half

## Complexity 
1. **Best Case Time Complexity**: O(NLogN)
2. **Avg Case Time Complexity**:  O(NLogN)
3. **Worst Case Time Complexity**:  O(NLogN)
4. **Space Complexity**: O(n)
## Algorithm
```
MergeSort(arr[], l,  r)
If r > l
     1. Find the middle point to divide the array into two halves:  
             middle m = l+ (r-l)/2
     2. Call mergeSort for first half:   
             Call mergeSort(arr, l, m)
     3. Call mergeSort for second half:
             Call mergeSort(arr, m+1, r)
     4. Merge the two halves sorted in step 2 and 3:
             Call merge(arr, l, m, r)
```

## Pseudocode 
```
MergeSort(arr, left, right):
    if left > right 
        return
    mid = (left+right)/2
    mergeSort(arr, left, mid)
    mergeSort(arr, mid+1, right)
    merge(arr, left, mid, right)
end
```

## C# Implementation 
```
using System;

namespace algorithms.sorting
{
    internal static class MergeSort
    {
        public static void Merge(int[] arr, int left, int mid, int right)
        {
            int leftSubArrLen = mid - left + 1;
            int rightSubArrLen = right - mid;

            int[] leftSubArr = new int[leftSubArrLen];
            int[] rightSubArr = new int[rightSubArrLen];
            int leftIndex , rightIndex ; 
            

            for (leftIndex = 0; leftIndex < leftSubArrLen; leftIndex++)
                leftSubArr[leftIndex] = arr[left + leftIndex];
            for(rightIndex = 0; rightIndex < rightSubArrLen; rightIndex++)
                rightSubArr[rightIndex] = arr[mid + 1 + rightIndex];

            leftIndex = rightIndex = 0;

            int mergedArrIndex = 0;

            while(leftIndex < leftSubArrLen && rightIndex < rightSubArrLen)
            {
                if (leftSubArr[leftIndex] <= rightSubArr[rightIndex])
                {
                    arr[mergedArrIndex] = leftSubArr[leftIndex];
                    leftIndex++;
                } else
                {
                    arr[mergedArrIndex] = rightSubArr[rightIndex];
                    rightIndex++;
                }
                mergedArrIndex++;
            }

            while(leftIndex < leftSubArrLen)
            {
                arr[mergedArrIndex] = leftSubArr[leftIndex];
                leftIndex++;
                mergedArrIndex++;
            }

            while(rightIndex < rightSubArrLen)
            {
                arr[mergedArrIndex++] = rightSubArr[rightIndex];
                rightIndex++;
                mergedArrIndex++;
            }
        }

        public static void Sort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int mid = (left + right) /2;
                Sort(arr, left, mid);
                Sort(arr, mid+1, right);
                Merge(arr, left, mid, right);
            }
        }

        // A utility function to
        // print array of size n */
        static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Given Array");
            PrintArray(arr);
            MergeSort.Sort(arr, 0, arr.Length - 1);
            PrintArray(arr);
        }
    }
}
```