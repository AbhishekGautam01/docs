namespace data_structure.linked_list.singly
{
    // https://www.youtube.com/watch?v=ugQ2DVJJroc
    public static class ReverseLinkedList
    {
        public static void ReverseIterative<T>(this LinkedList<T> linkedList)
        {
            Node<T> current = linkedList.Head;
            Node<T> previous = null;
            while (current != null)
            {
                Node<T> temp = current.Next;
                current.Next = previous;
                previous = current;
                current = temp;
            }
            linkedList.Head = previous;
        }

        public static Node<T> ReverseRecursive<T>(this LinkedList<T> linkedList)
        {
            if(linkedList.Head == null || linkedList.Head.Next == null)
            {
                return linkedList.Head;
            }
            var newHead = ReverseRecursive(linkedList);
            var headNext = linkedList.Head.Next;
            headNext.Next = linkedList.Head;
            linkedList.Head.Next = null;
            return newHead;
        }
    }
}
