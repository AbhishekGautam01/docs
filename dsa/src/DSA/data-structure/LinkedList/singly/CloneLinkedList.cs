using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.LinkedList.singly
{
    public static class CloneLinkedList
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node randomPointer; // this may point to itself or any random node in linked list
            public Node(int x)
            {
                data = x;
                next = randomPointer = null;
            }
        }
        // Duplicate a linked list using random pointer .
        // Using Extra space Dictionary
        // Time Complexity: O(N)
        // Space Complexity: O(N)
        public static Node CloneLinkedListUsingRandomPointer(Node head)
        {
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            var current = head;
            while(current != null)
            {
                map[current] = current;
            }

            current = head;
            var clonedList = head; 

            while(current!= null)
            {
                var cloneNode = map[current];
                cloneNode.next = current.next;
                cloneNode.randomPointer  = current.randomPointer;
                current = current.next;
            }

            return map[head];

        }

        // https://www.youtube.com/watch?v=4apaOcK586U&list=PLUcsbZa0qzu3yNzzAxgvSgRobdUUJvz7p&index=41 timestamp: 5:00
        public static Node Clone(Node head)
        {
            var current = head;
            Node temp = null;

            // Inserting additional node 
            // after each and every element in original node 
            while(current != null)
            {
                temp = current.next;
                //Inserting Node
                current.next = new Node(current.data);
                current.next.next = temp;
                current = temp;
            }
            current = head;

            // Adjust random pointers of newly added node
            while(current != null)
            {
                if(current.next != null)
                {
                    current.next.randomPointer = (current.randomPointer != null) ? current.randomPointer.next : current.randomPointer;
                }

                // move to the next newly added node
                // by skipping an original node
                current = (current.next != null) ? current.next.next
                                                : current.next;

            }

            Node original = head, copy = head.next;

            // save the start of copied linked list
            temp = copy;

            // now separate the original list
            // and copied list
            while (original != null && copy != null)
            {
                original.next = (original.next != null) ?
                            original.next.next : original.next;

                copy.next = (copy.next != null) ? copy.next.next
                                                     : copy.next;
                original = original.next;
                copy = copy.next;
            }
            return temp;
        }
    }
}
