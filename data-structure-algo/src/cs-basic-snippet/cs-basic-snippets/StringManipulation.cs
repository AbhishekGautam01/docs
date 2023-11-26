using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharp_Code_Snippets
{
    public static class StringManipulation
    {
        public static string ReverseString(string input)
        {
            if (input == null) return null;
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool CheckPalindrome(string input)
        {
            return input.SequenceEqual(input.Reverse());

            //OR

            //int length = inputString.Length;
            //for(int i = 0; i < length/2; i++)
            //{
            //    if (inputString[i] != inputString[length - i - 1])
            //        return false;
            //}
            //return true;
        }

        public static string ReverseWordsInSentense(string sentence)
        {
            string[] words = sentence.Trim().Split(' ');
            StringBuilder reversedSentence = new StringBuilder();
            foreach(var word in words)
            {
                char[] wordAsCharArray = word.ToCharArray();
                Array.Reverse(wordAsCharArray);
                reversedSentence.Append($"{new String(wordAsCharArray)}");
            }
            return reversedSentence.ToString().Trim();
        }

        public static string ReverseSentense(string sentense)
        {
            string[] words = sentense.Trim().Split(' ');
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        public static Dictionary<char, int> CountOccourance(string input)
        {
            var charecterFrequency = new Dictionary<char, int>();
            char[] chars = input.ToCharArray();
            foreach(var ch in chars)
            {
                if (charecterFrequency.ContainsKey(ch))
                    charecterFrequency[ch]++;
                else
                    charecterFrequency[ch] = 1;
            }
            return charecterFrequency;
        }

        public static string RemoveDuplicate(string input)
        {
            return new string(input.ToCharArray().Distinct().ToString());

            ////or
            //string unqiue = string.Empty;
            //char[] chars = input.ToCharArray();
            //foreach(var ch in chars)
            //{
            //    if (!unqiue.Contains(ch))
            //    {
            //        unqiue.Append(ch);
            //    }
            //}
            //return unique;
        }

        public static List<string> GetAllSubstring(string input)
        {
            List<string> subStrings = new List<string>();
            int lenght = input.Length;
            for(int i = 0; i< lenght; i++)
            {
                for (int j = i; j < lenght; j++)
                {
                    subStrings.Add(input.Substring(i, j - i + 1));
                }
            }
            return subStrings;
        }

        // Anagrams are those strings which have same charecters
        public static bool CheckAnagrams(string str1, string str2)
        {
            var chr1 = str1.ToLower().ToCharArray();
            var chr2 = str2.ToLower().ToCharArray();
            Array.Sort(chr1);
            Array.Sort(chr2);

            return (chr1 == chr2) ? true : false;
        }

        public static int CountWord(string input)
        {
            string[] words = input.Trim().Split(" ");
            return words.Count();
        }

        public static int GetMaxOccourance(string input)
        {
            Dictionary<char, int> occourances = StringManipulation.CountOccourance(input);
            return occourances.Values.Max();
        }

        public static bool CheckUnqiue(string input)
        {
            string modifiedString = String.Empty;
            foreach(var ch in input)
            {
                if (modifiedString.Contains(ch)) return false;
                else
                    modifiedString.Append(ch);
            }
            return true;
        }

        public static string EscapeWhiteSpace(string input)
        {
            int lenght = input.Length;
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < lenght; i++)
            {
                if (input[i] == ' ')
                    result.Append("%20");
                else
                    result.Append($"{input[i]}");
            }
            return result.ToString();
        }

        public static string FirstNonRepeatingChar(string input)
        {
            string result = String.Empty;
            foreach(var ch in input)
            {
                if (result.Contains(ch))
                    return result;
                else
                    result.Append(ch);
            }
            return result;
        }

        public static string RemoveSpecialChar(string input)
        {
            return Regex.Replace(input, @"[^0-9a-zA-z]", "");
        }

        public static string CapitalizeEachWord(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static int CountOccouranceWord(string sentence, string word)
        {
            string[] words = sentence.Split(new char[]{ ' ', '.'});
            return Array.FindAll(words, s => s.Equals(word.Trim())).Length;
        }
        public static string SortSentense(string sentense)
        {
            string[] words = sentense.Trim().Split(new char[] { ' ', '.' });
            Array.Sort(words);
            return string.Join(' ', words);
         }

    }
}
