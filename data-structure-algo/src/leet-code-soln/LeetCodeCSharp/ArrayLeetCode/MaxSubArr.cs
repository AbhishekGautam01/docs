using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.ArrayLeetCode
{
    public static class MaxSubArr
    {
        // https://leetcode.com/problems/maximum-subarray/

        //Kadane's Algorithm : Can be used here to solve this problem. 
        // https://medium.com/@rsinghal757/kadanes-algorithm-dynamic-programming-how-and-why-does-it-work-3fd8849ed73d
        public static int MaxSubArray(int[] nums)
        {
            if (!nums.Any()) return 0;
            int max_so_far = 0;
            int max_ending_here = Int32.MinValue; 

            for(int k = 0; k < nums.Length; k++)
            {
                max_ending_here = Math.Max(nums[k], max_ending_here + nums[k]);
                if ( max_ending_here > max_so_far)
                {
                    max_so_far = max_ending_here;
                }
            }
            return max_so_far;
        }
    }
}
