using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharp_Code_Snippets
{
    public static class LinkedListHelper
    {
        public static LinkedList<T> GetNewLinkedList<T>()
        {
            return new LinkedList<T>();
        }

        public static void AddFirst<T>(LinkedList<T> source, T element)
        {
            source.AddFirst(element);
        }

        public static void AddLast<T>(LinkedList<T> source, T element)
        {
            source.AddLast(element);
        }

        public static void AddAfter<T>(LinkedList<T> source, T nodeValue, T element)
        { 
            LinkedListNode<T> node = source.Find(nodeValue);
            source.AddAfter(node, element);
        }

        public static void AddBefore<T>(LinkedList<T> source, T nodeValue, T element)
        {
            LinkedListNode<T> node = source.Find(nodeValue);
            source.AddBefore(node, element);
        }

        public static void RemoveFirst<T>(LinkedList<T> source)
        {
            source.RemoveFirst();
        }

        public static void RemoveLast<T>(LinkedList<T> source)
        { 
            source.RemoveLast();
        }
        public static void Remove<T>(LinkedList<T> source, T element)
        {
            source.Remove(element);
        }

    }
}
