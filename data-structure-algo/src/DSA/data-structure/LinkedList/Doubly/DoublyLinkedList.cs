using System;

namespace data_structure.LinkedList.Doubly
{
  public class DoublyLinkedList
  {
    public Node head;
    public DoublyLinkedList()
    {
      head = null;
    }
    public void PrintList()
    {
      var current = head;
      if (current == null)
      {
        Console.WriteLine("The Doubly Linked List is currently empty!");
        return;
      }
      while (current != null)
      {
        Console.Write(" ," + current.data);
        current = current.next;
      }
      Console.WriteLine();
    }

    public void InsertAtStart(int data)
    {
      var newNode = new Node(data);
      if (head == null)
      {
        head = newNode;
        return;
      }
      head.previous = newNode;
      newNode.next = head;
      head = newNode;
    }

    public void InsertAtEnd(int data)
    {
      var newNode = new Node(data);
      if (head == null)
      {
        head = newNode;
        return;
      }
      var current = head;
      while (current != null)
        current = current.next;
      newNode.previous = current;
      current.next = newNode;
    }

    public void InsertAt(int data, int position)
    {
      if (position < 1)
        throw new ArgumentException("Position cannot be less than zero", nameof(position));
      if (head == null)
        throw new InvalidOperationException("Currently Doubly Linked List is empty! Specified Position doesn't exists");

      var newNode = new Node(data);

      var current = head;
      int i = 0;
      while (current != null && i < position)
      {
        current = current.next;
        i++;
      }
      if (i != position - 1)
      {
        throw new IndexOutOfRangeException("The specified position does not exist in the linked list");
      }

      newNode.next = current.next;
      newNode.previous = current;
      current.next = newNode;
      if (current != null)
        current.next.previous = newNode;
    }
    public void DeleteFirst()
    {
      if (head == null)
        throw new InvalidOperationException("The linked list is already empty");
      head = head.next;
      // if new head is not null then make the previous as null; 
      if (head != null)
        head.previous = null; 
    }

    public void DeleteLast()
    {
      if (head == null)
        throw new InvalidOperationException("the linked list is already emtpty");
      var current = head; 
      while(current.next.next != null)
      {
        current = current.next;
      }

      current.next = null; 
      current = null;
    }
    public void DeleteAt(int position)
    {
      if (position < 1)
      {
        throw new ArgumentOutOfRangeException();
      }
      else if (position == 1 && head != null)
      {

        Node nodeToDelete = head;
        head = head.next;
        nodeToDelete = null;
        if (head != null)
          head.previous = null;
      }
      else
      {
        var current = head;
        for (int i = 1; i < position - 1; i++)
        {
          if (current != null)
          {
            current = current.next;
          }
        }

        //4. If the previous node and next of the previous  
        //   is not null, adjust links 
        if (current != null && current.next != null)
        {
          Node nodeToDelete = current.next;
          current.next = current.next.next;
          if (current.next.next != null)
            current.next.next.previous = current.next;
          nodeToDelete = null;
        }
        else
        {
          Console.Write("\nThe node is already null.");
        }
      }
    }

    public void DeleteAll()
    {
      while (head != null)
      {
        head.previous = null;
        head = head.next;
      }
    }

    public int Count()
    {
      var count = 0;
      var current = head; 
      while(current != null)
      {
        count++;
        current = current.next; 
      }
      return count; 
    }

    public void DeleteEvenNodes()
    {
      if(head != null)
      {
        // if head is not null then create even & odd Node.
        var oddNode = head;
        var evenNode = head.next;
        Node temp = null;

        while(oddNode != null && oddNode != null)
        {
          // while oddNode & evenNode is not null, 
          // make next of oddNode as next of evenNode and free evenNode
          
          oddNode.next = evenNode.next;
          evenNode = null;
          
          // make temp as odd node and oddNode as next of oddNode; 
          temp = oddNode;
          oddNode = oddNode.next;

          // Updates previous link, oddNode and evenNode
          if(oddNode != null)
          {
            oddNode.previous = temp;
            evenNode = oddNode.next;
          }
        }
      }
    }

    public void DeleteOddNodes()
    {
      if(head != null)
      {
        Node temp = head;
        head = head.next;
        temp = null;
        if(head != null)
        {
          head.previous = null;
          var evenNode = head; 
          var oddNode = head.next;

          while(oddNode != null && evenNode != null)
          {
            evenNode.next = oddNode.next;
            oddNode = null;

            temp = evenNode; 
            evenNode = evenNode.next;

            if(evenNode != null)
            {
              evenNode.previous = temp; 
              oddNode = evenNode.next;
            }
          }
        }
      }
    }

    public Node Search(int data)
    {
      var current = head;
      while(current != null)
      {
        if(current.data == data)
          return current;
        current = current.next;
      }
      return null;
    }

    public void DeleteFirstNodeByValue(int value)
    {
      if(head.data == value)
      {
        var temp = head.next;
        temp.previous = null;
        head = temp;
        return;
      }

      var current = head;
      Node previous = null;
      while(current.next != null)
      {
        if(current.data == value)
        {
          var temp = current.next; 
          temp.previous = previous;
          previous.next = temp;
          return;
        }
        previous = current;
        current = current.next;
      }
    }

    public void DeleteLastOccouranceByValue(int value)
    {
      var current = head;
      Node lastNode = null, previousToLast = null;

      while(current != null)
      {
        if(current.data == value)
        {
          lastNode = current;
          previousToLast = current.previous;
        }
        current = current.next;
      }

      if (lastNode == null)
        return; 


    }
  }

  



  public class Node
  {
    public int data;
    public Node next;
    public Node previous;

    public Node(int data)
    {
      this.data = data;
      this.next = null;
      this.previous = null;
    }
  }
}
