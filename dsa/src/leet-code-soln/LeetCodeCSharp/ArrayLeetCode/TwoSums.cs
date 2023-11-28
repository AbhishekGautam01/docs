using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.ArrayLeetCode
{
    public static class TwoSums
    {
        // https://leetcode.com/problems/two-sum/submissions/
        /// <summary>
        /// Applying Brute Force Algorithm to find 
        /// Time Complexity : O(n2) and Space Complexity: O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
