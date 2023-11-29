using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingPatterns.TwoPointers
{
  internal class TripletSumWithSmallestSum
  {
    public int searchTriplets(int[] arr, int target)
    {
      int count = 0;
      Array.Sort(arr);

      for(int i = 0; i < arr.Length; i++)
      {
        int left = i +1;
        int right  = arr.Length - 1;

        while(left < right)
        {
          var currentSum = arr[i]+ arr[left] + arr[right];
          if (currentSum < target)
          {
            count+= right - left;
            right--;
          }
          else
            right--;
        }
      }

      return count;
    }
  }
}
