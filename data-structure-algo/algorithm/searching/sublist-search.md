# Sub List Search (Search a Linked List in another list)

## Algorithm 
1. Take first node of second list. 
2. Start matching the first list from this first node. 
3. If whole lists match return true. 
4. Else break and take first list to the first node again. 
5. And take second list to its second node. 
6. Repeat these steps until any of linked lists becomes empty. 
7. If first list becomes empty then list found else not.

# Complexity 
* Time Complexity: O(m*n); m - number of nodes in first list, n - number of nodes in second linked list. 
* This can be further optimized by storing two list into string and applying **KMP Algorithm** 

## C# Code Implementation 
```
using System;

namespace algorithms.searching
{
    internal class SubList
    {
        #region Linked List 
        class Node
        {
            public int data;
            public Node next;
        }

        static Node NewNode(int key)
        {
            Node temp = new Node();
            temp.data = key;
            temp.next = null;
            return temp;
        }

        static void PrintList(Node node)
        {
            while (node.next != null)
            {
                Console.Write("{0} ", node.data);
                node = node.next;
            }
        }

        #endregion

        static Boolean FindList(Node first, Node second)
        {
            Node ptr1 = first, ptr2 = second;

            // If both linked lists are empty, return true
            if (first == null && second == null)
                return true;

            // Else if one is empty and other is not, return false
            if (first == null ||
               (first != null && second == null))
                return false;

            // Traverse the second list by picking nodes one by one. 
            while (second != null)
            {
                // Initializing pointer 2 to current node of second list.
                ptr2 = second;

                // Start matching first list with second list. 
                while (ptr1 != null)
                {
                    // If second list becomes empty and first is not then return false. 
                    if (ptr2 == null)
                        return false;

                    // If data part is same then go to next of both lists. 
                    else if (ptr1.data == ptr2.data)
                    {
                        ptr1 = ptr1.next;
                        ptr2 = ptr2.next;
                    }

                    // If not equal break the loop 
                    else break;
                }

                // Return true if first list gets traversed completely that means it is a match
                if (ptr1 == null)
                    return true;

                // Initialize ptr1 to first node of first list
                ptr1 = first;

                // go to next node of second list. 
                second = second.next;
            }
            return false;
        }

        public static void Main(String[] args)
        {
            /* Let us create two linked lists to test
            the above functions. Created lists shall be
                a: 1->2->3->4
                b: 1->2->1->2->3->4*/
            Node a = NewNode(1);
            a.next = NewNode(2);
            a.next.next = NewNode(3);
            a.next.next.next = NewNode(4);

            Node b = NewNode(1);
            b.next = NewNode(2);
            b.next.next = NewNode(1);
            b.next.next.next = NewNode(2);
            b.next.next.next.next = NewNode(3);
            b.next.next.next.next.next = NewNode(4);

            if (FindList(a, b) == true)
                Console.Write("LIST FOUND");
            else
                Console.Write("LIST NOT FOUND");
        }
    }
}

```