using System.Text;

namespace data_structure.linked_list.singly
{
    public static class AddTwo
    {
        public static int AddTwoNumbersAsLinkedList(LinkedList<int> first, LinkedList<int> second)
        {
            StringBuilder firstNumber = new StringBuilder() , secondNumber = new StringBuilder();
            var currFirst = first.Head;
            var currSecond = second.Head;

            while(currFirst != null)
            {
                firstNumber.Append(currFirst.Data);
            }
            while(currSecond != null)
            {
                secondNumber.Append(currSecond.Data);
            }

            int.TryParse(firstNumber.ToString(), out int val1);
            int.TryParse(secondNumber.ToString(),out int val2);
            return val1 + val2;

        }
    }
}
