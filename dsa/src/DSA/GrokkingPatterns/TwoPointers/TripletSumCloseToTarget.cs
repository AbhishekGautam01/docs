namespace GrokkingPatterns.TwoPointers
{
  internal class TripletSumCloseToTarget
  {
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
