using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.ArrayLeetCode
{
    public static class SearchInsertPosition
    {
        public static int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0) return 0;
            int j=0;
            for(j=0; j < nums.Length; j++)
            {
                if (nums[j] >= target)
                    return j;
            }
            return j;
        }
    }

    // [1,3,5,6]
}
