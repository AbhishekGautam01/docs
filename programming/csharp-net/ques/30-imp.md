# 30 Important Interview Questions

1. **What is difference between .NET & C#?**
   * .net is **framework**. It has collection of libraries and run times. 
   * .net core is cross platform. .net 5 provides unified experience. 
   * C# is **programming language**. It has syntax & semantics and programming constructs. 

2. **What is IL & Why do we need JIT?**
    * C# code is converted to IL for it to run and JIT converts to machine dependent language. 
    * IL is partially compiled code. To see this IL code visually we need to have dis assemblers like il spy. 
    * JIT compiles IL to Machine language. 
    * The IL code is done because due to difference between development and runtime environment. eg dev is using win10 and runtime can be win8 x86 machine or linux machine. 
    * In .net framework we can code in various languages all CTS (Common Type Specification languages)

3. **Is it possible to view IL Code?**
    * Using IL DSM or IL Spy we can see the IL Code. 

4. **What is benefits of compiling into IL Code?**
    * The difference between the development and runtime environment. A Dev may be using any configuration but the runtime can be different OS and architecture. 

5. **Why does .NET support multiple programming languages?**
    * We can use C#, VB.NET, F#, VC++.NET which are all supported by .NET Framework. At end of day everything gets compiled to .NET IL Code.

6. **What is CLR(Common Language RunTime)?**
   * Converts IL code to native/machine language. 
   * It runs the native language and CLR is also responsible to run the garbage collector for re-claim unused memory. 

7. **What is difference between managed and un managed code?**
   * Code that executed under the env of CLR is managed code. 
   * C++ or VC++ or VB6 Code is not running under CLR env as they have their own runtime. CLR doesn't control these. 

8. **Explain the importance of GC**
   * It is background process running to **claim unused managed resources.**
   * It cleans objects that are no longer reachable. This can be seen in performance profiler in Visual Studio. 

9. **Can GC claim Un managed resources?**
   *  NO 

10. **Explain the importance of CTS(Common Type System)**
    * All of the languages which can be invoked within a .net library follows the CTS. 

11. **Explain importance of CLS(Common Languages Specification)?**
    * data type and behavior of all .net compatible languages are different. data type is controlled by CTS and behavior is controlled by CLS. Eg VB.Net doesn't understand case sensitivity while c# is case sensitive. this is different behavior here the CLS controls the **cross interoperability**

12. **Difference between stack & heap?**
    * It is memory types when the app runs, on stack primitive data types are allocated and on stack variable and value are stored in the same location.
    * On Heap the variable is allocated on stack but value is on heap and a pointer to heap memory location is stored. In heap objects are stored. 

13. **Value and reference types?**
    * Value is stored on stack and memory location and value are in same place. 
    * Reference type is ptr stored on stack and actual value on heap. 

14. **Boxing and Unboxing**
    * Boxing data moves from value type to reference type. 
    * Moving a reference type to a value type is unboxing. 
```csharp
int i = 10;
object y = i; //boxing
int z = (int)y;//unboxing.
```

15. **What is consequence of boxing and unboxing**
    * Performance is the consequence as data moves from stack to heap and heap to stack

16. **Casting, implicit and explicit casting**
    * Casting: trying to move from one data type to another data type. 
    * If casting happens automatically it is implicit casting. 
    * If casting is forced then it is explicit casting. Moving from higher data type to a lower data type. like double to int then it explicit casting

17. **What is consequence of explicit casting?**
    * There can be a possibility of data loss. like decimal can be lost while casting double to int. 

18. **Array vs ArrayList?**
    * Array is fixed length size. Array an be resized using Array.Resize<int>();
    * Array is strongly typed. 
    * ArrayList myList = new ArrayList(); It is of flexible size and it's not strongly typed. it can store any type as it's element. 

19. **Whose performance is better array or array list?**
    * Array is better as it is strongly typed and adding anything in array list leaded to boxing and unboxing.There can be need to do explicit casting as well. 

20. **What are generic collection?**
    * It is strongly typed and is flexible hence can grow in size. It has better performance compared to array list. 

21. **What are threads**
    * Threads helps to execute code parallel.
    * This comes from `System.Threading`

22. **Thread vs Task Parallel Library?**
    * TPL was introduces in 4.6 version of framework. 
    * Task also runs code parallel, same like task.
    * TPL has async and await. 
    * Task does parallel processing. If we have 10 threads and 4 core all 10 threads will run on 1 processor unless you create the process where as TPL runs code on all processors out of box. 
    * Task utilizes hardware properly without processor affinity extra coding as with the case with tasks.
    * Threads do context switching or time slicing. 
    * Tasks can return result but to get result from thread we need to use delegates. We can chain tasks cancel a task and use of async await. 
  
23. **Exception handling?**
    * Using try catch blocks. Each try block can have multiple catch blocks which should be arranged in most specific to least specific order. 

24. **What s use of finally block?**
    * Cleanup codes, memory clean up , this runs irrespective of exception occurred or not occurred.

25. **Out Keyword** 
    * C# func returns only value, out helps us to return multiple values. 
    * The variable must be declared but initialization happens within function where out is being passed.

26. **What are delegates?**
    * Delegate is pointer to a function and very useful as callbacks to communicate between threads. 

27. **What are events**
    * Events are encapsulation over delegates.

30. **Difference between abstract class and interface?**
    * Abstract class is a half defined parent class while interface is a contract. Abstract class is inherited while interfaces are implemented. 