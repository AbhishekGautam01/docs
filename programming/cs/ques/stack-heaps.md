# Stack, Heap, Boxing, Unboxing, Value types, Reference types

* **Explain Stack & heap?**
  * Stack & heap are memory types where application running variables , objects are stored.
<br/>

* **Where is stack and heap stored?**
  * Both are stored on RAM
<br/>

* **What goes on stack and what goes on heap?**
  * Stack: Primitive Types/Value types + object reference pointers are stored on stack where as these objects actual value stored on heap.
  * Heap: Reference Types are stored on heap. 
<br/>
  
* **How is the stack memory address arranged?**
  * Stack memory address is contagious and memory addresses do not have any gaps
<br/>

* Stack memory is de allocated in LIFO manner means Last in First out.
<br/>

* **How are primitive and objects stored in memory?**
  * From primitive data value is stored wherever the memory address is. 
  * For Objects data value is stored whenever the memory pointer points to. 
<br/>

* Can primitive data types can be stored in heap?
  * If primitive type is part of object instance then it will go on a heap. 
<br/>
  
* **Explain Value Types and reference types**
  * Value types are primitive types. When assigning primitive type to primitive type the values are copied.
  * Reference types are objects. When assigning reference type to a reference type the memory address where actual value is only that is copied. Hence changes made to one object properties it will reflect on to the others.
<br/>

* **Explain copy by val and copy by ref?**
  * Copy by value - values are copied and fresh address is allocated. 
  * While in case of copy by ref they point to same memory address and do the same reference. 
<br/>
  
* **What is boxing and unboxing?**
  * Boxing: When variables objects moves from stack to heap
  * Unboxing: When variables/objects moves from heap to stack. 
<br/>

* **Is boxing unboxing good or bad**?
  * Extra time to move data across heap and stack. 
<br/>

* **Can we avoid boxing and unboxing?**
  * Situations like taking data from UI or binding to grid will have to go through boxing and unboxing. But uncessarily doing boxing and unboxing is a very bad practise. 
<br/>
  
<br/>

* **Are string objects or value types?  or are string allocated on stack or heap**
  * Strings are stored on heap. String are objects, strings are reference types.
<br/>
  
* **How many stacks and how many heaps are stacked is created for an app**
  * 1 Stack per thread
  * 1 Heap for the whole application. 
<br/>
  
* **How are stacks and heap memory de allocated**
  * Stacks: When thread exits then stacks is de allocated and memory is given back to OS> 
  * Heaps: GC runs undeterministically and checks which objects have no reference and then cleans them. 
<br/>

* **Where is structure allocated stack or heap?**
    * On Stack
<br/>

* **Are structures copy by val or copy by ref**
    * Copy by ref
<br/>

* **Can structures get created on heap**
  * No