namespace GrokkingPatterns.Warmup
{
  public  class Pangram
  {
    /*
     A pangram is a sentence where every letter of the English alphabet appears at least once.

    Given a string sentence containing English letters (lower or upper-case), return true if sentence is a pangram, or false otherwise.

    Note: The given sentence might contain other characters like digits or spaces, your solution should handle these too.
     */
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


}
