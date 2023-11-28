using System.Collections.Generic;

namespace data_structure.linked_list.singly
{
    public static class RemoveDuplicate
    {
        public static void RemoveDuplicateSortedList<T>(this LinkedList<T> linkedList)
        {
            if(linkedList == null)
                return;
            var current = linkedList.Head;
            while(current.Next != null)
            {
                while(linkedList.IsEqual(current.Data, current.Next.Data))
                {
                    current.Next = current.Next.Next;
                }
                current = current.Next;
            }
        }
        public static void RemoveDuplicateUnsortedList<T>(this LinkedList<T> linkedList)
        {
            if (linkedList == null)
                return;
            HashSet<T> visitedElements = new HashSet<T>();
            var current = linkedList.Head;
            while(current.Next != null)
            {
                if (visitedElements.Contains(current.Next.Data))
                {
                    current.Next = current.Next.Next;
                } else
                {
                    visitedElements.Add(current.Data);
                    current = current.Next;
                }
            }
        }
    }
}
