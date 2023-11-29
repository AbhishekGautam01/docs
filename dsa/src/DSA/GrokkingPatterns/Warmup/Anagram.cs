using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingPatterns.Warmup
{
  internal class Anagram
  {
    /* Given two strings s and t, return true if t is an anagram of s, and false otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
    */
    public bool isAnagram(string s, string t)
    {
      if(s.Length != t.Length) return false;  

      s =s.ToLower();
      t = t.ToLower();

      Dictionary<char, int> freqMap = new Dictionary<char, int>();
      for (int i = 0; i < s.Length; i++)
      {
        // Increment the frequency of the character in string s.
        freqMap[s[i]] = freqMap.GetValueOrDefault(s[i], 0) + 1;
        // Decrement the frequency of the character in string t.
        freqMap[t[i]] = freqMap.GetValueOrDefault(t[i], 0) - 1;
      }

      // Check if the frequency of all characters is 0.
      foreach (var entry in freqMap)
      {
        if (entry.Value != 0)
        {
          return false;
        }
      }
        return true;
    }
  }
}
