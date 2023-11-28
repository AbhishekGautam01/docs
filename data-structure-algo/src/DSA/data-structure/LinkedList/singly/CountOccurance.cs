using System.Collections.Generic;

namespace data_structure.linked_list.singly
{
    public static class CountOccurance
    {
        public static int CountOccurances<T>(this LinkedList<T> lList, T key)
        {
            var current = lList.Head;
            int count = 0;
            while (current != null)
            {
                if (lList.IsEqual(current.Data, key))
                    count++;
            }
            return count;
        }

        public static int CountOccuranceRecurisve<T>(Node<T> head, T key)
        {
            if(head == null)
                return 0;
            if(EqualityComparer<T>.Default.Equals(head.Data, key))
            {
                return 1 + CountOccuranceRecurisve(head.Next, key);
            }
            return CountOccuranceRecurisve(head.Next, key);
        }
    }
}
