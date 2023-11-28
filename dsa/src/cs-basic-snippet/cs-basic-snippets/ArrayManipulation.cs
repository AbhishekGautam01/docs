using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace CSharp_Code_Snippets
{
    public static class ArrayManipulation
    {
        public static int[] LeftCircularRotation(int[] input)
        {
            int length = input.Length;
            if (length > 1)
            {
                int temp = input[0];
                for (int i = 0; i < length - 1; i++)
                {
                    input[i] = input[i + 1];
                }
                input[length - 1] = temp;
            }
            return input;
        }

        public static int[] RightCircularRotation(int[] input)
        {
            int length = input.Length;
            if (length > 1)
            {
                int temp = input[length - 1];
                for (int i = 0; i < length - 1; i++)
                {
                    input[i + 1] = input[i];
                }
            }
            return input;
        }
        public static bool TwoIntegerSumToTarget(int[] array, int target)
        {
            bool result = false;
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    if (i != j)
                    {
                        int sum = array[i] + array[j];
                        if (sum == target)
                            result = true;
                    }
                }
            }
            return result;
        }
        public static int[] Convert2DTo1D(int[,] input)
        {
            List<int> result = new List<int>();
            foreach (var number in input)
            {
                result.Append(number);
            }
            return result.ToArray();
        }

        public static int[,] Convert1Dto2D(int[] input, int Column, int Rows)
        {
            int[,] result = new int[Column, Rows];
            for (int i = 0; i < Column; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    result[i, j] = input[i * Rows + j];
                }
            }
            return result;
        }
        public static int[] ReverseArray(int[] array)
        {
            Array.Reverse<int>(array);
            return array;
        }
        public static int FindSecondLargest(int[] input)
        {
            input = input.OrderByDescending(c => c).Distinct().ToArray();
            switch (input.Count())
            {
                case 0:
                    return -1;
                case 1:
                    return input[0];
            }
            return input[1];
        }

        public static int LargestInt(int[] input)
        {
            input = input.OrderByDescending(c => c).Distinct().ToArray();
            if (input.Any())
            {
                return input[0];
            }
            return -1;
        }


        public static int[] SortDescending(int[] array)
        {
            return array.OrderByDescending(c => c).ToArray();
        }

        public static int[] MergeSortedArray(int[] arr1, int[] arr2)
        {
            int arr1Length = arr1.Length;
            int arr2Legth = arr2.Length;
            int[] result = new int[arr1Length + arr2Legth];
            int leftIndex = 0, rightIndex = 0;
            int ResultIndex = 0;

            while (leftIndex < arr1Length && rightIndex < arr2Legth)
            {
                if (arr1[leftIndex] <= arr2[rightIndex])
                    result[ResultIndex++] = arr1[leftIndex++];
                else
                    result[ResultIndex++] = arr2[rightIndex++];
            }

            if (leftIndex < arr1Length)
            {
                for (int j = leftIndex; j < arr1Length; j++)
                    result[ResultIndex++] = arr1[j++];
            }
            else
            {
                for (int j = rightIndex; j < arr2Legth; j++)
                    result[j++] = arr2[j++];
            }
            return result;
        }

        public static bool ContainsDuplicate(int[] array)
        {
            Dictionary<int, int> number = new Dictionary<int, int>();
            foreach (int i in array)
            {
                if (number.ContainsKey(i))
                    return true;
                number.Add(i, 1);
            }
            return false;
        }

        public static KeyValuePair<T, int> GetMaxOccurance<T>(T[] source)
        {
            Dictionary<T, int> occurances = new Dictionary<T, int>();
            KeyValuePair<T, int> result = new KeyValuePair<T, int>(default(T), 0);
            foreach (T element in source)

            {
                if (occurances.ContainsKey(element))
                    occurances[element]++;
                else
                    occurances.Add(element, 1);
            }

            foreach (KeyValuePair<T, int> element in occurances)
            {
                if (element.Value > result.Value)
                {
                    result = element;
                }
            }
            return result;
        }
        public static int CountDuplicate<T>(T[] source)
        {
            Dictionary<T, int> occurance = new Dictionary<T, int>();
            int duplicateCount = 0;
            foreach (T element in source)
            {
                if (occurance.ContainsKey(element))
                    duplicateCount++;
                else
                    occurance.Add(element, 1);
            }
            return duplicateCount;
        }
        public static T[] GetUnique<T>(T[] source)
        {
            T[] result = new T[source.Length];
            foreach (T element in source)
            {
                if (result.Contains(element))
                    continue;
                result.Append(element);
            }
            return result;
        }

        public static Tuple<int, int> GetMaxMin(int[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < source.Length; j++)
                {
                    if (source[j] < source[smallest])
                        smallest = j;
                }
                int temp = source[i];
                source[i] = source[smallest];
                source[smallest] = temp;
            }
            Tuple<int, int> result = new Tuple<int, int>(source.FirstOrDefault(), source.LastOrDefault());
            return result;
        }

        public static Tuple<IEnumerable<int>, IEnumerable<int>> SeperateOddEvenValue(int[] source)
        {
            IEnumerable<int> even = source.Where(c => c % 2 == 0);
            IEnumerable<int> odd = source.Where(c => c % 2 != 0);
            Tuple<IEnumerable<int>, IEnumerable<int>> result = new Tuple<IEnumerable<int>, IEnumerable<int>>(even, odd);
            return result;
        }

        public static T[] DeleteAtPosition<T>(T[] souce, int position)
        {
            if (souce.Length < position)
                return souce;
            T[] result = new T[souce.Length - 1];
            int resultIndex = 0;
            for (int i = 0; i < souce.Length; i++)
            {
                if (i == position)
                    continue;
                result[resultIndex++] = souce[i];
            }
            return result;
        }

        public static T[] RemoveElement<T>(T[] source, T element)
        {
            return source.Except(new T[] { element }).ToArray();
        }

        public static int GetSecondLargest(int[] source)
        {
            if (source.Length < 2) return source.FirstOrDefault();
            Array.Sort(source);
            return source.ElementAt(1);
        }


        public static void PrintIntArray<T>(T[] input)
        {
            Console.WriteLine(string.Join(" ,", input));
        }

        public static void Print2DArrayRowFirst<T>(T[,] source)
        {
            int cols = source.GetLength(0);
            int rows = source.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine($"Column: {j} Row: {i} Value: {source[j, i]} ");
                }
            }

            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }

        public static int hourglassSum(int[,] arr)
        {
            int max = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int currentSum = 0;
                    if ((arr[row, col] == arr[row + 1, col]) && (arr[row, col] == arr[row + 2, col]))
                    {
                        if ((arr[row, col + 1] == arr[row + 2, col + 1]))
                        {
                            if ((arr[row, col + 2] == arr[row + 1, col + 2]) && (arr[row, col + 2] == arr[row + 2, col + 2]))
                            {
                                currentSum = arr[row, col] + arr[row + 1, col] + arr[row + 2, col] + arr[row + 1, col + 1] + arr[row, col + 2] + arr[row + 1, col + 2] + arr[row + 2, col + 2];
                                if (currentSum > max) max = currentSum;
                            }
                        }
                    }
                }
            }
            return max;
        }

        public static int[,] Create2DArr(int cols, int rows)
        {
            int[,] result = new int[cols, rows];
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.WriteLine($"Enter value for Col: {i} Row: {j}");
                    int.TryParse(Console.ReadLine(), out result[i, j]);
                }
            }

            return result;
        }

        

    }

}
