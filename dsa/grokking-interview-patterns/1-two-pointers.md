# Two Pointers
* **USE CASE**: We deal with sorted arrays (or LinkedLists) and need to find a set of elements that fulfill certain constraint. Set of elements can be **pair, a triplet or even a sub array**.
* **EXAMPLE**: Given an array of sorted numbers and a target sum, find a pair in the array whose sum is equal to the given target
  
## Target Sum 
* Write a function to return the indices of the two numbers (i.e. the pair) such that they add up to the given target. If no such pair exists return [-1, -1].
```
Example 1:

Input: [1, 2, 3, 4, 6], target=6
Output: [1, 3]
Explanation: The numbers at index 1 and 3 add up to 6: 2+4=6
Example 2:

Input: [2, 5, 9, 11], target=11
Output: [0, 2]
Explanation: The numbers at index 0 and 2 add up to 11: 2+9=11
```

* **Space Complexity**: O(1) has constant space requirement for left, right and currentSum variables
* **Initialization**: O(1) as it involves assigning values to left & right pointer.
* **Time Complexity**: O(n)

```csharp
    public int[] search(int[] arr, int targetSum)
    {
      int leftPtr = 0, rightPtr = arr.Length-1;
      while (leftPtr < rightPtr)
      {
        var currentSum = arr[leftPtr] + arr[rightPtr];
        if (currentSum == targetSum)
          return new int[] { leftPtr, rightPtr };
        else if (currentSum > targetSum)
          rightPtr--;
        else
          leftPtr++;
      }
      return new int[] { -1, -1 };
    }
```

## Find Non Duplicate Instances
* Given an array of sorted numbers, move all non-duplicate number instances at the beginning of the array in-place. The relative order of the elements should be kept the same and you should not use any extra space so that the solution has constant space complexity i.e., .
* Move all the unique number instances at the beginning of the array and after moving return the length of the subarray that has no duplicate in it.
* Example 1:
```
Input: [2, 3, 3, 3, 6, 9, 9]
Output: 4
Explanation: The first four elements after moving element will be [2, 3, 6, 9]
```

* **Time Complexity**: O(n)
* **Space Complexity**: O(1)


```csharp
    public int remove(int[] arr) {
        int nextNonDuplicate = 1;
        for(int i = 0; i < arr.Length; i++){
          if(arr[i] != arr[nextNonDuplicate -1]){
            arr[nextNonDuplicate] = arr[i];
            nextNonDuplicate++;
          }
        }
        return nextNonDuplicate;
    }
```

## Squaring Sorted Array
* Given a sorted array, create a new array containing squares of all the numbers of the input array in the sorted order.
* Example 1:
```
Input: [-2, -1, 0, 2, 3]
Output: [0, 1, 4, 4, 9]
```

* **Time Complexity**: O(N)
* **Space Complexity**: O(N)
```csharp
int n = arr.Length;
      int[] squares = new int[n];
      int left = 0, right = n - 1;
      int maxElementIndex = n - 1;
      while(left <= right)
      {
        var leftSquare = arr[left] * arr[left];
        var rightSquare = arr[right] * arr[right];  

        if(leftSquare > rightSquare)
        {
          squares[maxElementIndex--] = leftSquare;
          left++;
        } else
        {
          squares[maxElementIndex--] = rightSquare;
          right--;
        }
      }
      return squares;
```

## Triplet Sum to Zero
* Given an array of unsorted numbers, find all unique triplets in it that add up to zero.
* Example 1:
```
Input: [-3, 0, 1, 2, -1, 1, -2]
Output: [[-3, 1, 2], [-2, 0, 2], [-2, 1, 1], [-1, 0, 1]]
Explanation: There are four unique triplets whose sum is equal to zero. smallest sum.'
```

* **Time Complexity**: O(N^2)
* **Space Complexity**: O(1)
1. Step 1: Sort the Array in Ascending Order
2. Now start a loop from i index to length_of_arr - 2 index , so last 3 elements needs to checked but last 2 elements shouldn't be looped as they can't form a triplet.
3. If the current i index is not zero then we need to check if previous element to current index i.e. arr[i-1] is not same as i because if it is same we will have duplicate triplates
4. Initialize a left pointer to index + 1
5. Initialize a right pointer to length_of_arr -1
6. while (left < right)
   1. Find Current Sum
   2. If Current Sum == 0
      1. Add to result list.
      2. increment left pointer 
      3. decrement right pointer as the new left pointer can only form a triplet with current right pointer if it is duplicate which we need to ignore.
      4. while left < right and updated left element same as previous left element then increment left as to avoid duplicate.
      5. while left < right and updated right element same as previous right element then decrement right to avoid duplicate.
   3. else if currentSum > 0 then decrement right to reduce the current some to make it near to zero
   4. else increment left to increment left to increase the current some to make it near to zero.
7. return the final triplet list.
   
```csharp
public List<List<int>> searchTriplets(int[] arr) {
          List<List<int>> triplets = new List<List<int>>();
      
      //Step 1: Sorting the Array
      Array.Sort(arr);
      int length = arr.Length;

      for(int i = 0; i < length -2; i++)
      {
        if (i > 0 && arr[i] == arr[i - 1])
          continue;

        int left = i + 1;
        int right = length - 1;

        while(left < right)
        {
          int currentSum = arr[i] + arr[left] + arr[right];

          if (currentSum == 0)
          {
            triplets.Add(new List<int>() { arr[i], arr[left], arr[right] });
            left++;
            right--;
            
            while (left < right && arr[left] == arr[left - 1])
              left++;

            while (left < right && arr[right] == arr[right + 1])
              right--;
          }
          else if (currentSum > 0)
            right--;
          else
            left++;
        }
      }
      return triplets;
    }
```

## Triplet Sum closed to target.
* Given an array of unsorted numbers and a target number, find a triplet in the array whose sum is as close to the target number as possible, return the sum of the triplet. If there are more than one such triplet, return the sum of the triplet with the smallest sum
* **Time Complexity**: O(N^2)
* **Space Complexity**: O(N) required for sorting.
  
* Example 1:
```
Input: [-1, 0, 2, 3], target=3 
Output: 2
Explanation: The triplet [-1, 0, 3] has the sum '2' which is closest to the target.
```

```csharp
    public int searchTriplet(int[] arr, int targetSum)
    {
      Array.Sort(arr);
      int result = int.MaxValue;
      int smallestDifference = int.MaxValue;

      for(int i = 0;i < arr.Length; i++)
      {
        int left = i + 1;
        int right = arr.Length - 1;
        while(left< right)
        {
          var currentSum = arr[i] + arr[left] + arr[right];
          var currentDifference = Math.Abs(currentSum - targetSum);
          if(currentDifference < smallestDifference || (currentDifference <= smallestDifference && currentSum < result))
          {
            smallestDifference = currentDifference;
            result = currentSum;
          }

          if (currentSum > targetSum)
            right--;
          else
            left++;
        }
      }
      return result;
    }
```

## Triplets with smallest Sum
```csharp
public int searchTriplets(int[] arr, int target)
    {
      int count = 0;
      Array.Sort(arr);

      for(int i = 0; i < arr.Length; i++)
      {
        int left = i +1;
        int right  = arr.Length - 1;

        while(left < right)
        {
          var currentSum = arr[i]+ arr[left] + arr[right];
          if (currentSum < target)
          {
            count+= right - left;
            left++;
          }
          else
            right--;
        }
      }

      return count;
    }
```