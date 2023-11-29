using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingPatterns.TwoPointers
{
  internal class NonDuplicateInstances
  {
    /* 
     * 
Given an array of sorted numbers, move all non-duplicate number instances at the beginning of the array in-place. The relative order of the elements should be kept the same and you should not use any extra space so that the solution has constant space complexity i.e., .
Move all the unique number instances at the beginning of the array and after moving return the length of the subarray that has no duplicate in it.

Example 1:
Input: [2, 3, 3, 3, 6, 9, 9]
Output: 4
Explanation: The first four elements after moving element will be [2, 3, 6, 9].
    */

    public int remove(int[] arr)
    {
      int nextNonDuplicate = 1;
      for (int i = 0; i < arr.Length; i++)
      {
        if (arr[i] != arr[nextNonDuplicate - 1])
        {
          arr[nextNonDuplicate] = arr[i];
          nextNonDuplicate++;
        }
      }
      return nextNonDuplicate;
    }


  }
}
