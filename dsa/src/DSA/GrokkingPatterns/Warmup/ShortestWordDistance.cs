using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingPatterns.Warmup
{
  public class ShortestWordDistance
  {
    /*
     * Given an array of strings words and two different strings that already exist in the array word1 and word2, return the shortest distance between these two words in the list.

Example 1:

Input: words = ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"], word1 = "fox", word2 = "dog"
Output: 5
Explanation: The distance between "fox" and "dog" is 5 words.
    */

    public int shortestDistance(string[] words, string word1, string word2)
    {
      int position1 = -1, position2 = -1;
      int shortestDistance = words.Length;

      for (int i = 0; i < words.Length; i++)
      {
        if (words[i] == word1)
          position1 = i;
        else if (words[i] == word2)
          position2 = i;

        if (position1 != -1 && position2 != -1)
        {
          shortestDistance = Math.Min(shortestDistance, Math.Abs(position1 - position2));
        }
      }
      return shortestDistance;
    }
  }
}
