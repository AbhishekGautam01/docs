namespace data_structure.linked_list.singly
{
    public static class LastToFront
    {
        public static void MoveLastElementToFront<T>(this LinkedList<T> linkedList)
        {
            var head = linkedList.Head;
            if (head == null || head.Next == null) ;
            var last = head;
            Node<T> secLast = null;
            while (last.Next != null)
            {
                secLast = last;
                last = last.Next;
            }

            secLast.Next = null;
            last.Next = head;
            linkedList.Head = last;
        }
    }
}
