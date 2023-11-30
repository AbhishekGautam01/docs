namespace GrokkingPatterns.TwoPointers
{
  internal class TripletSumCloseToTarget
  {
    /*Given an array of unsorted numbers and a target number, find a triplet in the array whose sum is as close to the target number as possible, return the sum of the triplet. If there are more than one such triplet, return the sum of the triplet with the smallest sum.

Example 1:

Input: [-1, 0, 2, 3], target=3 
Output: 2
Explanation: The triplet [-1, 0, 3] has the sum '2' which is closest to the target.*/
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
  }
}
