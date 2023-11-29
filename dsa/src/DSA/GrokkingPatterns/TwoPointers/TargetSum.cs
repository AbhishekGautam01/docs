namespace GrokkingPatterns.TwoPointers
{
  internal class TargetSum
  {
    /*
Write a function to return the indices of the two numbers (i.e. the pair) such that they add up to the given target. If no such pair exists return [-1, -1].

Example 1:

Input: [1, 2, 3, 4, 6], target=6
Output: [1, 3]
Explanation: The numbers at index 1 and 3 add up to 6: 2+4=6
Example 2:

Input: [2, 5, 9, 11], target=11
Output: [0, 2]
Explanation: The numbers at index 0 and 2 add up to 11: 2+9=11
     */

    public static int[] Search(int[] arr, int targetSum)
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

    public static void RunIt()
    {
      int[] result = TargetSum.Search(new int[] { 1, 2, 3, 4, 6 }, 6);
      Console.WriteLine("Pair with target sum: [" + result[0] + ", " + result[1] + "]");
      result = TargetSum.Search(new int[] { 2, 5, 9, 11 }, 11);
      Console.WriteLine("Pair with target sum: [" + result[0] + ", " + result[1] + "]");
    }
  }
}
