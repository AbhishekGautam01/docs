namespace data_structure.linked_list.singly
{
    public static class Segregate
    {
        // https://www.geeksforgeeks.org/segregate-even-and-odd-elements-in-a-linked-list/
        public static void SegregateEvenOdd(Node<int> head)
        {

            Node<int> evenStart = null;
            Node<int> evenEnd = null;
            Node<int> oddStart = null;
            Node<int> oddEnd = null;
            Node<int> currentNode = head;

            while (currentNode != null)
            {
                int element = currentNode.Data;

                if (element % 2 == 0)
                {

                    if (evenStart == null)
                    {
                        evenStart = currentNode;
                        evenEnd = evenStart;
                    }
                    else
                    {
                        evenEnd.Next = currentNode;
                        evenEnd = evenEnd.Next;
                    }

                }
                else
                {

                    if (oddStart == null)
                    {
                        oddStart = currentNode;
                        oddEnd = oddStart;
                    }
                    else
                    {
                        oddEnd.Next = currentNode;
                        oddEnd = oddEnd.Next;
                    }
                }

                // Move head pointer one step in forward direction
                currentNode = currentNode.Next;
            }


            if (oddStart == null || evenStart == null)
            {
                return;
            }

            evenEnd.Next = oddStart;
            oddEnd.Next = null;
            head = evenStart;
        }
    }
}
