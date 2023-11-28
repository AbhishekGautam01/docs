using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.strings
{
    public static class AddTwoNumbers
    {
        public static string AddTwoVeryLargeNumber(string number1, string number2)
        {
            // before proceeding make sure number2 is bigger than number1
            if(number1.Length > number2.Length)
            {
                string temp = number2;
                number2 = number1;
                number1 = temp;
            }

            string sum = "";
            char[] charNum1 = number1.ToCharArray();
            Array.Reverse(charNum1);
            char[] charNum2 = number2.ToCharArray();
            Array.Reverse(charNum2);
            return sum;
        }
    }
}
