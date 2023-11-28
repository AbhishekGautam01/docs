using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.linked_list.singly
{
    internal static class MergeTwo
    {
        public static Node<int> MergeSortedLinkedList(LinkedList<int> first, LinkedList<int> second)
        {
            var currFirst = first.Head;
            var currSecond = second.Head;
            
            if (currFirst == null)
                return second.Head;
            if(currSecond == null)
                return first.Head;

            // start with the linked list
            // whose head data is the least
            if (currFirst.Data < currSecond.Data)
                return MergeUtil(currFirst, currSecond);
            else
                return MergeUtil(currSecond, currFirst);
        }

        private static Node<int> MergeUtil(Node<int> first, Node<int> second)
        {
            // if only one node in first list
            // simply point its head to second list
            if (first.Next == null)
            {
                first.Next = second;
                return first;
            }

            // Initialize current and next pointers of
            // both lists
            Node<int> curr1 = first, next1 = first.Next;
            Node<int> curr2 = second, next2 = second.Next;

            while (next1 != null && curr2 != null)
            {
                // if curr2 lies in between curr1 and next1
                // then do curr1->curr2->next1
                if ((curr2.Data) >= (curr1.Data)
                    && (curr2.Data) <= (next1.Data))
                {
                    next2 = curr2.Next;
                    curr1.Next = curr2;
                    curr2.Next = next1;

                    // now let curr1 and curr2 to point
                    // to their immediate next pointers
                    curr1 = curr2;
                    curr2 = next2;
                }
                else
                {
                    // if more nodes in first list
                    if (next1.Next != null)
                    {
                        next1 = next1.Next;
                        curr1 = curr1.Next;
                    }

                    // else point the last node of first list
                    // to the remaining nodes of second list
                    else
                    {
                        next1.Next = curr2;
                        return first;
                    }
                }
            }
            return first;
        }


    }
}

