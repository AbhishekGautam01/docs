using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharp_Code_Snippets
{
    public static class Miscellaneous
    {
        public static void TowerOfHanoiUsingRecursion(int total, string from, string to, string other)
        {
            if (total > 0)
            {
                TowerOfHanoiUsingRecursion(total - 1, from, other, to);
                Console.WriteLine($"Move disk {total} from tower {from}, to tower {to}");
                TowerOfHanoiUsingRecursion(total - 1, other, to, from);
            }
        }

        public static bool MatchingParenthesis(string source)
        {
            if (source == null || source.Length <= 1) return false;

            Stack<char> parenthesisSt = new Stack<char>();
            foreach (char ch in source)
            {
                if (ch == '(')
                    parenthesisSt.Push('(');
                else if (ch == ')')
                {
                    if (parenthesisSt.Count == 0)
                        return false;
                    else
                        parenthesisSt.Pop();
                }
            }
            return true;
        }

        public static bool CheckPassword(string pass)
        {
            if (pass.Length < 6 || pass.Length > 12) return false;
            if (pass.Contains(' ')) return false;
            if (!pass.Any(char.IsUpper))
                return false;

            //At least 1 lower case letter
            if (!pass.Any(char.IsLower))
                return false;

            //No two similar chars consecutively
            for (int i = 0; i < pass.Length - 1; i++)
            {
                if (pass[i] == pass[i + 1])
                    return false;
            }

            //At least 1 special char
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            foreach (char c in specialCharactersArray)
            {
                if (pass.Contains(c))
                    return true;
            }
            return false;
        }

        public static int CountWaysRepitionAllowed(int[] source, int target)
        {
            int[] count = new int[target + 1];

            // base case
            count[0] = 1;

            for (int i = 1; i <= target; i++)
            {
                for (int j = 0; j <= source.Length; j++)
                {
                    if (i >= source[j])
                        count[i] += count[i - source[j]];
                }
            }

            return count[target];
        }

    }
}
