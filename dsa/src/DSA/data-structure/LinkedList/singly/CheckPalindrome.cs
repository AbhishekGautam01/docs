using System;
using System.Collections.Generic;

namespace data_structure.linked_list.singly
{
  public static class CheckPalindrome
  {
    // Method 1: Using Stack
    public static bool IsPalindrome(this LinkedList<int> linkedList)
    {
      Stack<int> stack = new Stack<int>();
      var current = linkedList.Head;
      while (current != null)
      {
        stack.Push(current.Data);
        current = current.Next;
      }

      current = linkedList.Head;
      while (current != null)
      {
        int i = stack.Pop();
        if (i != current.Data)
          return false;
        current = current.Next;
      }
      return true;
    }

    public static void DriverPalindrome()
    {
      LinkedList<int> linkedList = new LinkedList<int>();
      linkedList.Head = new Node<int>(1);
      var second = new Node<int>(2);
      var third = new Node<int>(1);
      linkedList.Head.Next = second;
      second.Next = third;
      Console.WriteLine("palindrome " + linkedList.IsPalindrome());
    }

    //Method 2: Finding Mid ; Reversing 2nd half, Comparing
  }
}
