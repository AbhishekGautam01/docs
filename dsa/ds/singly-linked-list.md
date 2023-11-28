# Linked List

* **Def**: Linear data structure; Stored in Non-continuous manner; 
![Linkedlist](./img/Linkedlist.png)

## Why LinkedList? 
* Limitation of **Arrays**: 
    1. **fixed size** : Upper Limit of elements to store must be known
    2. **inserting new element is expensive**: All existing elements needs to be shifted
    3. **deleting is expensive**  
* Advantage over **Arrays**: 
    1. **dynamic size** 
    2. **easy insertion/deletion** 
* Drawbacks of **Linked List**
    1. **random access not allowed** 
    2. **extra space required for pointers** 
    3. **not cache friendly**: In arrays there is locality of references 

## LinkedList vs Array
**Arrays** store in continuous memory location, leading to **calculable address**; faster access to **specific index**
1. **size**: In **arrays** size cannot be altered at runtime; In **linked list** size can change dynamically(expand or shrink) at runtime. 
2. **memory allocation**: Arrays -> Compile time; LinkedList -> Run time;
3. **Memory Efficiency**: LinkedList use more memory but size flexibility makes it use less memory overall. 
4. **Execution time**: In Arrays -> direct access; In LinkedList -> traverse all elements before that element to be access; **modification** is faster in arrays; **inserting/updating** is faster in linkedlist. 

# Singly Linked List 

[Basic Operation](https://www.alphacodingskills.com/cs/ds/cs-reverse-the-linked-list.php)

## Complexities
| Operation | Time | Space | 
| :---: | :---: | :---: | 
| Access i-th element | O(N)| O(1) |
| Traverse all elements | O(N)| O(1) |
| Insert element E at current point |  O(1) |O(1) |
| Delete Current Element | O(1) |O(1) |
| Insert element E at front | O(1) | O(1) |
| Insert element E at end | O(N)|O(1) |
* **Linked List Class** 
```
public class LinkedList<T> {
        public Node<T> head;
    }

    public class Node<T> {
        T data;
        public Node<T> next;

        public Node(T value) {
            this.data = value;
            next = null;
        }
    }
```

* **creating linked list** 
```
public static void Main(string[] args) {
    LinkedList<int> linkedList = new LinkedList<int>();
    linkedList.head = new Node<int>(1);
    Node<int> second = new Node<int>(2);
    Node<int> third = new Node<int>(3);
    linkedList.head.next = second;
    second.next = third;
 }
```

## Inserting

* **Insert at start**
```
public void InsertAtStart(T data) {
    var newElem = new Node<T>(data);
    newElem.Next = Head;
    Head = newElem;
        }
```
* **Insert after**
```
public void InsertAfter(Node<T> prevNode, T data)
{
    if (prevNode == null)
        throw new InvalidOperationException("Provided Node is null");

    var newElem = new Node<T>(data);
    newElem.Next = prevNode.Next;
    prevNode.Next = newElem;
}
```
* **insert at end**
```
public void InsertAtEnd(T data)
{
    if(Head == null)
        Head = new Node<T>(data);
    var current = Head;
    while(current.Next != null)
        current = current.Next;
    current.Next = new Node<T>(data);
}
```