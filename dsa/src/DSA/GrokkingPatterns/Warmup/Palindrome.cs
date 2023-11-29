using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingPatterns.Warmup
{
  public class Palindrome
  {
    /*
     * A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
     * Given a string s, return true if it is a palindrome, or false otherwise.
     * Example 1:
Input: sentence = "A man, a plan, a canal, Panama!"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.

    * Example 2:
Input: sentence = "Was it a car or a cat I saw?"
Output: true
Explanation: Explanation: "wasitacaroracatisaw" is a palindrome.
     */

    public bool isPalindrome(string s)
    {
      List<char> chars = new List<char>();
      foreach (char c in s.ToLower())
      {
        if(char.IsLetterOrDigit(c))
          chars.Add(c);
      }

      s = new string(chars.ToArray());
      int first = 0, last = s.Length - 1;
      while (first < last)
      {
        if (s[first] != s[last])
          return false;
         first++;
        last--;
      }
      return true;
    }
  }
}
