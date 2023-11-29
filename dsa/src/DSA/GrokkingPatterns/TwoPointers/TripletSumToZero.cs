using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingPatterns.TwoPointers
{
  internal class TripletSumToZero
  {

    /*Given an array of unsorted numbers, find all unique triplets in it that add up to zero.

Example 1:

Input: [-3, 0, 1, 2, -1, 1, -2]
Output: [[-3, 1, 2], [-2, 0, 2], [-2, 1, 1], [-1, 0, 1]]
Explanation: There are four unique triplets whose sum is equal to zero. smallest sum.'*/

    public List<List<int>> searchTriplets(int[] arr)
    {
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
  }
}
