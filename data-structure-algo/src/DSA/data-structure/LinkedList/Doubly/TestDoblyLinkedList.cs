using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.LinkedList.Doubly
{
    public static class TestDoblyLinkedList
    {
        public static void TestDoblyLinkedListDriverCode()
        {
            var dLL = CreateWith3Nodes();
        }

        public static DoublyLinkedList CreateWith3Nodes()
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            // Adding First Node 
            Node first = new Node();
            first.data = 10;
            first.next = null;
            first.previous = null;
            //linking with head node
            doublyLinkedList.head = first;

            // Adding Second Node 
            Node second = new Node();
            second.data = 20;
            second.next = null;
            // Linking with first Node
            second.previous = first;
            first.next = second;

            // Adding third Node 
            Node third = new Node();
            third.data = 30;
            third.next = null;
            // Linking with second node;
            third.previous = second;
            second.next = third;

            return doublyLinkedList;
        }
    }
}
