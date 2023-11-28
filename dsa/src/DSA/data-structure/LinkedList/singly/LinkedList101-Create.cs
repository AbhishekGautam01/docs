namespace data_structure.linked_list.singly
{
    public class LinkedList101_Create
    {
        public static void Create()
        {
            CheckPalindrome.DriverPalindrome();
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Head = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);

            linkedList.Head.Next = second;
            second.Next = third;

            System.Console.WriteLine("Initial List");
            linkedList.PrintList();
            System.Console.WriteLine("Insert 0 at Start");
            linkedList.InsertAtStart(0);
            linkedList.PrintList();
            System.Console.WriteLine("Insert -1 at 2nd place");
            linkedList.InsertAfter(linkedList.Head, -1);
            linkedList.PrintList();
            System.Console.WriteLine("Insert 4 at end");
            linkedList.InsertAtEnd(4);
            linkedList.InsertAtEnd(2);
            linkedList.ReverseIterative();
            System.Console.WriteLine(CountOccurance.CountOccuranceRecurisve(linkedList.Head, 2));
            linkedList.RemoveDuplicateUnsortedList();
            System.Console.WriteLine("Removed duplicate");
            linkedList.PrintList();
            linkedList.MoveLastElementToFront();
            System.Console.WriteLine("Moving last to front");
            linkedList.PrintList();
            linkedList.DeleteFirstOccurnaceByKey(0);
            linkedList.DeleteFirstOccurnaceByKey(4);
            linkedList.DeleteLastOccuranceByKey(2);
            System.Console.WriteLine("Linked list after deletion");
            linkedList.PrintList();

        }
    }
}
