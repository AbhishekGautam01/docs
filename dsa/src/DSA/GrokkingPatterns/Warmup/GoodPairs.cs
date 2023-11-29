using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingPatterns.Warmup
{
  internal class GoodPairs
  {
    /*
Given an array of integers nums, return the number of good pairs.
A pair (i, j) is called good if nums[i] == nums[j] and i < j.

Example 1:
Input: nums = [1,2,3,1,1,3]
Output: 4
Explanation: There are 4 good pairs, here are the indices: (0,3), (0,4), (3,4), (2,5).
     */

    public int numGoodPairs(int[] nums)
    {
      int pairCount = 0;
      Dictionary<int, int> map = new Dictionary<int, int>();
      foreach (var n in nums)
      {
        map[n] = map.GetValueOrDefault(n, 0) + 1;
        pairCount += (map[n] - 1);
      }
      return pairCount;
    }
  }
}
