using System;

namespace data_structure.linked_list.singly
{
    public static class NthNode
    {
        public static Node<T> GetNthNode<T>(LinkedList<T>  linkedList, int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n");
            int stepMoved = 0;
            var current = linkedList.Head;
            while(current != null)
            {
                if(stepMoved == n)
                    return current;
                stepMoved++;
                current = current.Next;
            }

            return null;
        }

        public static Node<T> GetNthNode<T>(Node<T> head, int n)
        {
            if(head == null)
                return null;

            if(n == 0)
                return head;

            return GetNthNode(head.Next, n - 1);
        }
    }
}
