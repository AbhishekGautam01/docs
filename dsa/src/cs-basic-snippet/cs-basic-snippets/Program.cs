using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace CSharp_Code_Snippets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 50, 10, 10 };
            Console.WriteLine(Sorting.FindSecondLargest(arr));

            //int N = Int32.Parse(Console.ReadLine());
            //string[] arr = Console.ReadLine().Split(' ');
            //int[] arrI = new int[N];
            //for(int i = 0; i < N; i++)
            //{
            //    arrI[i] = Int32.Parse(arr[i]);
            //}
            //uint bits = 4292967296;
            //for(int i = 0; i < N; i++)
            //{
            //    int maxXor = 0;
            //    for(int j = i+1; j < N; j++)
            //    {
            //        maxXor = Math.Max(maxXor,
            //                          arrI[i] ^ arrI[j]);
            //    }
                
            //    Console.WriteLine(((1 << bits) - 1) ^ maxXor);
            //}
        }

        int jumps(int flagheight, int bigJumps)
        {
            int result = 0;
            result = result + (flagheight / bigJumps);
            flagheight = flagheight % bigJumps;
            result = result + flagheight;
            return result;
        }

        private static bool MainMenu()
        {
            bool showMenu = false;

            Console.Clear();
            Console.WriteLine("Choose an Option");
            Console.WriteLine("1. Print Input Array");
            Console.Write("Select an option : ");

            bool isParsed = Int32.TryParse(Console.ReadLine(), out int choice);

            if (!isParsed)
            {
                Console.WriteLine("Please enter a valid option! Press enter to continue");
                Console.ReadLine();
                showMenu = true;
            } else
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Columns: ");
                        int.TryParse(Console.ReadLine(), out int cols);
                        Console.WriteLine("Enter Rows: ");
                        int.TryParse(Console.ReadLine(), out int rows);
                        int[,] arr = ArrayManipulation.Create2DArr(cols, rows);
                        break;
                    default:
                        showMenu = true;
                        break;
                }
            }
            
            return showMenu;
        }
    }
}
