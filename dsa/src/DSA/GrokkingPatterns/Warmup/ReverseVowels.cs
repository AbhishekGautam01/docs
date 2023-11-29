using System.Text;

namespace GrokkingPatterns.Warmup
{
  public class ReverseVowels
  {
    static readonly string vowels = "aeiouAEIOU";

    /*
Given a string s, reverse only all the vowels in the string and return it.

The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

Example 1:

Input: s= "hello"
Output: "holle"
Example 2:

Input: s= "AEIOU"
Output: "UOIEA"
Example 3:

Input: s= "DesignGUrus"
Output: "DusUgnGires"
     */
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

    public static void RunIt()
    {
      ReverseVowels solution = new ();

      // Test Case 1
      string s1 = "hello";
      string expectedOutput1 = "holle";
      string actualOutput1 = solution.reverseVowels(s1);
      Console.WriteLine("Test Case 1: " + (expectedOutput1 == actualOutput1));

      // Test Case 2
      string s2 = "DesignGUrus";
      string expectedOutput2 = "DusUgnGires";
      string actualOutput2 = solution.reverseVowels(s2);
      Console.WriteLine("Test Case 2: " + (expectedOutput2 == actualOutput2));

      // Test Case 3
      string s3 = "AEIOU";
      string expectedOutput3 = "UOIEA";
      string actualOutput3 = solution.reverseVowels(s3);
      Console.WriteLine("Test Case 3: " + (expectedOutput3 == actualOutput3));

      // Test Case 4
      string s4 = "aA";
      string expectedOutput4 = "Aa";
      string actualOutput4 = solution.reverseVowels(s4);
      Console.WriteLine("Test Case 4: " + (expectedOutput4 == actualOutput4));

      // Test Case 5
      string s5 = "";
      string expectedOutput5 = "";
      string actualOutput5 = solution.reverseVowels(s5);
      Console.WriteLine("Test Case 5: " + (expectedOutput5 == actualOutput5));
    }
  }
}
