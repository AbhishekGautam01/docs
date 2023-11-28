using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.ArrayLeetCode
{
    public static class RemoveElements
    {
        // https://leetcode.com/problems/remove-element/
        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;
            int index = 0; 
            for(int i=0; i < nums.Length; i++)
            {
                if(nums[i] != val)
                {
                    nums[index++] = nums[i];
                }
            }
            return index;
        }

        public static Tuple<int[], int> Driver()
        {
            return Tuple.Create(new int[] { 3, 2, 2, 3 }, 3);
            //return Tuple.Create(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2);
        }
    }
}
