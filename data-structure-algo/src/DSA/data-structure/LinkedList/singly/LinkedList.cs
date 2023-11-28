using System;
using System.Collections.Generic;

namespace data_structure.linked_list.singly
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }

        public void InsertAtStart(T data)
        {
            var newElem = new Node<T>(data);
            newElem.Next = Head;
            Head = newElem;
        }

        public void InsertAfter(Node<T> prevNode, T data)
        {
            if (prevNode == null)
                throw new InvalidOperationException("Provided Node is null");

            var newElem = new Node<T>(data);
            newElem.Next = prevNode.Next;
            prevNode.Next = newElem;
        }

        public void InsertAtEnd(T data)
        {
            if(Head == null)
                Head = new Node<T>(data);
            var current = Head;
            while(current.Next != null)
                current = current.Next;
            current.Next = new Node<T>(data);
        }
        public int Count()
        {
            int count = 0;  
            if(Head == null)
                return count;
            if (Head.Next == null)
                return 1;
            var current = Head;
            while(current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }
        public void DeleteFirstNode()
        {
            if (Head == null)
                return;
            Head = Head.Next;
        }
        public void DeleteLastNode()
        {
            if (Head == null)
                return;
            var current = Head;
            while(current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;    
        }
        public void DeleteAt(int index)
        {
            if(index < 0)
                throw new ArgumentOutOfRangeException("index");
            if (Head == null)
                return;
            if(index == 0)
            {
                Head = Head.Next;
                return;
            }
            var current = Head;

            // Traverse to 1 Node before the mentioned index
            for(int i = 0; i < index; i++)
            {
                if (current != null)
                    current = current.Next;
            }

            if(current != null && current.Next != null)
            {
                current.Next = current.Next.Next;
            }


        }
        public void DeleteAll()
        {
            while(Head != null)
            {
                Head = Head.Next;
            }
        }
        public void DeleteFirstOccurnaceByKey(T key)
        {
            if(Head == null)
                return;
            
            if(IsEqual(Head.Data, key))
            {
                Head= Head.Next;
                return;
            }

            Node<T> current = Head;
            while(current.Next != null)
            {
                if(IsEqual(current.Next.Data, key))
                {
                    current.Next = current.Next.Next;
                    return;
                } else 
                    current = current.Next;
            }
            return;
        }
        public void DeleteLastOccuranceByKey(T key)
        {
            if(Head != null)
            {
                Node<T> lastNodeWithValueKey, previousToLastNode, current;
                lastNodeWithValueKey = previousToLastNode = null;

                if (IsEqual(Head.Data, key))
                    lastNodeWithValueKey = Head;

                current = Head;
                while(current.Next != null)
                {
                    if(IsEqual(current.Next.Data, key))
                    {
                        lastNodeWithValueKey = current.Next;
                        previousToLastNode = current;
                    }
                    current = current.Next;
                }

                if(lastNodeWithValueKey != null)
                {
                    if (lastNodeWithValueKey == Head)
                        Head = Head.Next;
                    else
                        previousToLastNode.Next = lastNodeWithValueKey.Next;
                }
            }
        }
        public void DeleteAllOccuranceByKey(T key)
        {
            while(Head != null && IsEqual(Head.Data, key))
            {
                Head = Head.Next;
            }

            Node<T> current = Head;
            if(current != null)
            {
                while(current.Next != null)
                {
                    if(IsEqual(current.Next.Data, key))
                        current.Next = current.Next.Next;
                    else
                        current = current.Next;
                }
            }
        }
        public void DeleteEvenNodes()
        {
            if (Head == null)
                return;
            var oddNode = Head;
            var evenNode = Head.Next;
            while(oddNode != null && evenNode != null)
            {
                oddNode = evenNode.Next; 
                oddNode = oddNode.Next;
                if(oddNode != null)
                    evenNode = oddNode.Next;
            }
        }
        public void DeleteOddNodes()
        {
            if (Head == null)
                return;
            var oddNode = Head;
            var evenNode = Head.Next;
            while(oddNode == null && evenNode != null)
            {
                evenNode = oddNode.Next;
                evenNode = evenNode.Next;
                if (evenNode != null)
                    oddNode = evenNode.Next;
            }
        }
        public Node<T> SearchAnElement(T data)
        {
            if(Head == null)
                return null;
            var current = Head;
            while(current != null)
            {
                if (IsEqual(current.Data, data)) 
                    return current;
                current = current.Next;
            }
            return null;
        }
        public void PrintList()
        {
            Node<T> current = Head;
            while (current != null) {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        public bool IsEqual<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }        
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            this.Data = value;
            Next = null;
        }
    }
}
