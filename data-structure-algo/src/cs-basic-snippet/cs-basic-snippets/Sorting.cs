using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharp_Code_Snippets
{
    public static class Sorting
    {
        // Each iteration starts with assumption that first element in iteration is the smallest number then from the next element it loops to check if there is another number which is smaller than the first number and swaps its
        public static int[] SelectionSort(int[] soure)
        {
            int length = soure.Length;
            for(int i =0; i < length; i++)
            {
                int smallest = i;
                for(int j = i+1; j < length; j++ )
                {
                    if (soure[j] < soure[smallest])
                        smallest = j;
                }
                if(smallest != i)
                {
                    int temp = soure[i];
                    soure[i] = soure[smallest];
                    soure[smallest] = temp;
                }

            }
            return soure;
        }

        public static int FindSecondLargest(int[] arr)
        {
            int length = arr.Length;
            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            for (int i = 0; i < length; i++)
            {
                if (arr[i] >= largest)
                    largest = arr[i];
                else if (arr[i] >= secondLargest)
                    secondLargest = arr[i];
            }
            return secondLargest;
        }

        public static int[] MergeSort(int[] source)
        {
            int length = source.Length;
            if (length <= 1) return source;

            int[] left, right;
            int[] result = new int[length];

            int midPoint = length / 2;
            left = new int[midPoint];
            
            if (length % 2 == 0) right = new int[midPoint];
            else right = new int[midPoint + 1];

            //Populate Left Array 
            for(int i = 0; i < midPoint; i++)
            {
                left.Append(source[i]);
            }

            //Populate Right Array;
            for(int i = midPoint + 1; i < length; i++)
            {
                right.Append(source[i]);
            }

            //Recuserviely sort left & right array 
            left = MergeSort(left);
            right = MergeSort(right);

            result = Merge(left, right);
            return result;
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int resultLen = left.Length + right.Length;
            int[] result = new int[resultLen];

            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while(indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] < right[indexRight])
                    result[indexResult++] = left[indexLeft++];
                else
                    result[indexResult] = right[indexRight++];
            }

            if(indexLeft < left.Length)
            {
                for (int i = indexLeft; i < left.Length; i++)
                    result[indexResult++] = left[i];

            } else if(indexRight < right.Length)
            {
                for (int i = indexRight; i < right.Length; i++)
                    result[indexResult++] = right[i];
            }

            return result;
        }


        //TODO: Work to be done;
        private static int[] BubbleSort(int[] source)
        {
            int length = source.Length;
            for(int i = 0; i < length -1; i++)
            {
                for(int j = 0; j < length-1; j++)
                {

                }
            }

            return source;
        }

        private static int BinarySearch(int[] source, int element)
        {
            int minIndex = 0;
            int maxIndex = source.Length - 1;
            int ElementAtIndex = -1;
            while(maxIndex >= minIndex)
            {
                int midIndex = (minIndex + maxIndex) / 2;
                if (source[midIndex] == element)
                     ElementAtIndex = midIndex;
                else if (source[midIndex] > element)
                    minIndex = midIndex + 1;
                else
                    maxIndex = midIndex - 1;
            }
            return 0;
        }


        // Complete the checkMagazine function below.
        static void checkMagazine(string[] magazine, string[] ransom)
        {
            Dictionary<string, int> mag = new Dictionary<string, int>();
            Dictionary<string, int> note = new Dictionary<string, int>();


            mag = ConvertArray(magazine);
            note = ConvertArray(ransom);

            bool result = true;

            foreach (KeyValuePair<string, int> item in note)
            {

                if (!mag.Contains(item))
                {
                    if (mag.ContainsKey(item.Key) && mag[item.Key] < item.Value)
                        result = false;

                }
            }

            if (result == true)
            {
                Console.WriteLine("Yes");

            }
            else
            {
                Console.WriteLine("No");
            }

        }

        static private Dictionary<string, int> ConvertArray(string[] arr)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string word in arr)
            {
                if (dic.ContainsKey(word))
                {
                    dic[word]++;

                }
                else
                {
                    dic.Add(word, 1);


                }

            }
            return dic;
        }
        // Complete the twoStrings function below.
      

    }
}
