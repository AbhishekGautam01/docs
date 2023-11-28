using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.linked_list.singly
{
    public static class NthNodeFromEnd
    {
        public static Node<T> GetNthNodeFromEnd<T>(this LinkedList<T> linkedList, int n)
        {
            var count = linkedList.Count();

            if (count < n)
                return null;

            int requiredSteps = count - n;
            var current = linkedList.Head;
            for(int i = 0; i < requiredSteps; i++)
            {
                current = current.Next;
            }
            return current;
        }
        public static Node<T> GetNthNodeFromEndRefPtrs<T>(this LinkedList<T> LinkedList, int n)
        {
            if(LinkedList == null)
                return null;

            var current = LinkedList.Head;
            var refPTR = LinkedList.Head;

            int stepsTaken = 0;
            while(stepsTaken < n)
            {
                if (refPTR == null)
                    throw new Exception("List has lesser elements than N");
                stepsTaken++;
                refPTR = refPTR.Next;
            }

            if (refPTR == null)
            {
                var head = LinkedList.Head.Next;
                if (head != null)
                    return head;
            }


            while (refPTR != null)
            {
                refPTR = refPTR.Next;
                current = current.Next;
            }
            
            return current; 
        }
        // Iterative function to return the k'th node from the end in a linked list
        public static Node<T> FindKthNode<T>(Node<T> head, int k)
        {
            Node<T> curr = head;

            // move `k` nodes ahead in the linked list
            for (int i = 0; curr != null && i < k; i++)
            {
                curr = curr.Next;

                // return if `k` is more than the total number of nodes in the list
                if (curr == null && i != k - 1)
                {
                    return null;
                }
            }

            // move the `head` and `curr` parallelly till `curr` reaches the list's end
            while (curr != null)
            {
                head = head.Next;
                curr = curr.Next;
            }

            // `head` will now contain the k'th node from the end
            return head;
        }
    }
}
