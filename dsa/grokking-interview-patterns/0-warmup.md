# Warmup

### Problem 1: Contains Duplicate
* Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

```csharp
using System;
using System.Collections.Generic;

public class Solution {

  public bool containsDuplicate(int[] nums) {
    HashSet<int> uniqueNums = new HashSet<int>();
    for(int i = 0; i < nums.Length; i++){
      if(uniqueNums.Contains(nums[i]))
        return true;
      uniqueNums.Add(nums[i]);
    }
    return false;
  }
}
```

### Problem 2: PanGram
* A pangram is a sentence where every letter of the English alphabet appears at least once.
* Given a string sentence containing English letters (lower or upper-case), return true if sentence is a pangram, or false otherwise.
* Note: The given sentence might contain other characters like digits or spaces, your solution should handle these too.
```csharp
  public  class Pangram
  {
    
    public static bool checkIfPangram(string sentence)
    {
      HashSet<char> charMap = new HashSet<char>() {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
      sentence = sentence.ToLower();
      for(int i = 0; i < sentence.Length; i++)
      {
        if (charMap.Contains(sentence[i]))
          charMap.Remove(sentence[i]);
      }
      if (charMap.Count > 0)
        return false;
      return true;
    }

    public static void RunIt()
    {
      Console.WriteLine(Pangram.checkIfPangram("TheQuickBrownFoxJumpsOverTheLazyDog")); // Expected output: true
      Console.WriteLine(Pangram.checkIfPangram("This is not a pangram"));                // Expected output: false
      Console.WriteLine(Pangram.checkIfPangram("abcdef ghijkl mnopqr stuvwxyz"));        // Expected output: true
      Console.WriteLine(Pangram.checkIfPangram(""));                                      // Expected output: false
      Console.WriteLine(Pangram.checkIfPangram("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")); // Expected output: true
    }
  }
```

### Problem 3: Reverse Vowels
* Given a string s, reverse only all the vowels in the string and return it.
* The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.
* Example 1:
Input: s= "hello"
Output: "holle"

* Example 2:
Input: s= "AEIOU"
Output: "UOIEA"

* Example 3:
Input: s= "DesignGUrus"
Output: "DusUgnGires"

```csharp
    static readonly string vowels = "aeiouAEIOU";
    public string reverseVowels(string s)
    {
      StringBuilder sb = new StringBuilder(s);
      int first = 0, last = s.Length - 1;
      while(first < last)
      {
        if (vowels.Contains(s[first]) && vowels.Contains(s[last]))
        {
          char temp = sb[first];
          sb[first] = sb[last];
          sb[last] = temp;
          first++;
          last--;
        }
        else if (vowels.Contains(s[first]))
          last--;
        else if (vowels.Contains(s[last]))
          first++;
      }
      return sb.ToString();
    }
```


### Problem 4: Check Palindrome
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

```csharp
 /*

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
```

### Problem 5: Check Anagram
* Given two strings s and t, return true if t is an anagram of s, and false otherwise.
* An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
```csharp
    /* 
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
```

# Problem 6: Shortest Word Distance

* Given an array of strings words and two different strings that already exist in the array word1 and word2, return the shortest distance between these two words in the list.
```
 Example 1:
Input: words = ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"], word1 = "fox", word2 = "dog"
Output: 5
Explanation: The distance between "fox" and "dog" is 5 words.
```

```csharp
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
```

# Problem 7: Good Pairs
* Given an array of integers nums, return the number of good pairs.
* A pair (i, j) is called good if nums[i] == nums[j] and i < j.
```
Example 1:
Input: nums = [1,2,3,1,1,3]
Output: 4
Explanation: There are 4 good pairs, here are the indices: (0,3), (0,4), (3,4), (2,5).
```

```csharp
    public int numGoodPairs(int[] nums)
    {
      int pairCount = 0;
      Dictionary<int, int> map = new Dictionary<int, int>();
      foreach (var n in nums)
      {
        map[n] = map.GetValueOrDefault(n, 0) + 1;
        pairCount += (map[n] - 1);
      }
      return pairCount;
    }
```