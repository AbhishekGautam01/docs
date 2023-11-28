using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.ArrayLeetCode
{
    public static class RemoveDuplicateSortedArray
    {
        // https://leetcode.com/problems/remove-duplicates-from-sorted-array/

        /// <summary>
        /// Solved using two pointer approach 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public static int[] Driver()
        {
            return new int[] { 1, 1, 3 };
        }
    }
}
