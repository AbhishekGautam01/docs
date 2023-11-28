using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.linked_list.singly
{
    internal class Flatten
    {
        public class List
        {
            Node head; // head of list

            /* Linked list Node */
            public class Node
            {
                public int data;
                public Node next, down;
                public Node(int data)
                {
                    this.data = data;
                    next = null;
                    down = null;
                }
            }
        }

        // https://www.youtube.com/watch?v=kvCYxPKpPGg&list=PLUcsbZa0qzu3yNzzAxgvSgRobdUUJvz7p&index=53
        public static void FlattenLevelWise()
        {

        }


    }
}
