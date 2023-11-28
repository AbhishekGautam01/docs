using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Transactions;

namespace CSharp_Code_Snippets
{
    public static class NumberManipulation
    {
        public static bool CheckPrime(int num)
        {
            if(num == 0 || num == 1) return false;
            if (num == 2) return true;

            double limit = Math.Ceiling(Math.Sqrt(num));
            for(int i = 2; i <= limit; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;

        }

        public static int SumofDigits(int num)
        {
            int absolute = Math.Abs(num);
            int sum = 0;
            while(absolute != 0)
            {
                sum += absolute % 10;
                absolute /= 10;
            }

            return sum;
        }

        public static decimal FindAngleinTime(int hour, int minute)
        {
            int hourDegree = (hour * 30) + (minute * 30 / 60);
            int minuteDegree = (minute * 6);

            int diffDegree = Math.Abs(hourDegree - minuteDegree);
            if(diffDegree > 180)
            {
                return (360 - diffDegree);
            }
            return diffDegree;
        }

        public static int FindNthFibbonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            
            int f = 0;
            int s = 1;
            int third = 0;

            for( int i = 0; i < n; i++)
            {
                third = f + s;
                f = s;
                s = third;
            }

            return third;
        }

        public static void SwapTwoNumbers(int n1, int n2)
        {
            n1 = n1 + n2;
            n2 = n1 - n2;
            n1 = n1 - n2;
        }

        public static void Reverse(int n)
        {
            int reverse = 0;
            while(n > 0)
            {
                int remainder = n % 10;
                reverse = reverse + remainder * 10;
                n = n / 10;
            }
        }

        public static IEnumerable<int> FindMissingNumber(int[] arr)
        {
            var orderedArry = arr.OrderBy(i => i);
            var first = orderedArry.First();
            var last = orderedArry.Last();

            IEnumerable<int> missingElement = Enumerable.Range(first, last-first + 1).Except(orderedArry);
            return missingElement;
        }

        public static IEnumerable<int>  Factors(int number)
        {
            List<int> result = new List<int>();
            if (number == 0 || number == 1) return result.Append(number);
            int limit = number / 2;
            for(int i = 1; i <= limit; i++)
            {
                if (number % i == 0)
                    result.Append(number);
            }
            return result;
        }

        public static int FindFactorialUsingRecursion(int number)
        {
            if (number == 0 || number == 1) return 1;
            return number * FindFactorialUsingRecursion(number - 1);
        }
        public static int SumOfDigitUsingRecusion(int number)
        {
            if (number == 0) return 0;
            return number % 10 + SumOfDigitUsingRecusion(number / 10);
        }

        public static int Power(int @base, int exponent)
        {
            if (exponent == 0) return 1;
            return @base * Power(@base, exponent - 1); 
        }

        public static int GCD(int number1, int number2)
        {
            if (number1 == 0) return number2;
            if (number2 == 0) return number1;
            if (number1 == number2) return number1;
            if (number1 > number2)
                return GCD(number1 - number2, number2);
            return GCD(number1, number2 - number1);
        }
        public static bool Palindrome(int number)
        {
            int temp = number;
            int reverse = 0;
            while(number > 0)
            {
                int remainder = number % 10;
                reverse = reverse + remainder * 10;
                number = number / 10;
            }
            if (temp == reverse)
                return true;
            return false;
        }
        public static bool CheckArmStrongNumber(int number)
        {
            int temp = number;
            int sum = 0;
            while (number > 0)
            {
                int m = number % 10;
                sum += (m * m * m);
                number = number / 10;
            }
            if (sum == temp) return true;
            else
                return false;
        }



    }
}
