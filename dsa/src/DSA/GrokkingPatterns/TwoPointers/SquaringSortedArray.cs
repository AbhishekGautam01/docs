using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingPatterns.TwoPointers
{
  internal class SquaringSortedArray
  {
    /*Given a sorted array, create a new array containing squares of all the numbers of the input array in the sorted order.

Example 1:

Input: [-2, -1, 0, 2, 3]
Output: [0, 1, 4, 4, 9]*/

    public int[] makeSquares(int[] arr)
    {
      int n = arr.Length;
      int[] squares = new int[n];
      int left = 0, right = n - 1;
      int maxElementIndex = n - 1;
      while(left <= right)
      {
        var leftSquare = arr[left] * arr[left];
        var rightSquare = arr[right] * arr[right];  

        if(leftSquare > rightSquare)
        {
          squares[maxElementIndex--] = leftSquare;
          left++;
        } else
        {
          squares[maxElementIndex--] = rightSquare;
          right--;
        }
      }
      return squares;
    }
  }
}
