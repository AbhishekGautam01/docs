using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.linked_list.singly
{
    public static class MiddleNodeLinkedList
    {
        public static Node<T> GetMiddleNode<T>(this LinkedList<T> lList)
        {
            if(lList.Head == null)
                return null;
            if(lList.Head.Next == null)
                return lList.Head;

            var fastPtr = lList.Head;
            var slowPtr = lList.Head;
            while(fastPtr != null && fastPtr.Next != null)
            {
                slowPtr = slowPtr.Next;
                fastPtr = fastPtr.Next.Next;
            }

            return slowPtr;
        }
    }
}
