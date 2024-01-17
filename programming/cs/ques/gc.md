# Garbage Collector

* **Explain Garbage Collector?**
  * GC is a background process which runs undertermistcally and cleans unreference managed objects.
<br/>

* **How does GC know when to clean the object?**
  * Cleans objects once they are **out of scope** - When object on heap doesn't have reference on stack.
  * When method runs 2 memories are created stack and heap.
  * When objects goes out of scope when method completes the memory on heap remains and GC cleans the heap.  
<br/>

* **Is there a way we can see this heap memory and see GC works?**
  * It can be seen and how many times GC has ran by using **performance counters**
  * Performance counters are counters or they are measure of events in a software which allows us to do analysis. These counters are installed when software is installed. Eg See PerfMon on windows machine and add counters and go to .NET CLR memory and add **GC Handles** counters.
  * In Visual Studio also we can track these performance counter by going to Build menu.
<br/>

* **How to tune garbage collector?**
  * We can set:
    * maximum size of heap
    * size of individual generations
    * frequency of garbage collection
<br/>

* **Does GC collector clean primitive data types?**
  * NO as they are allocated on stack and stack removes them as soon as the variable goes out of scope.
  * GC Heap Size is also a measure how much the GC is running.
<br/>
  
* **Manages vs Un Managed Resources/object/code**
  * Manages resources are those which are pure .NET objects and these objects are controlled by .NET CLR
  * Un managed resources are those which ae nt controlled by .NET CLR Runtime like File Handle, COM Objects, Connection object or memory allocation code. Something which CLR didn't create.
<br/>

* **Does GC clean un managed resources?**
  * No as GC are not aware of disposing the object like how to de allocate the C++ created memory.
<br/>

* **Explain Generations?**
  * Logical buckets and every buckets defines how old the objects are 
    * GC0: Short Lived Object like local variables. Objects created within the loops.
    * CG1: Buffer or intermediately old object
    * GC2: Long Lived Object : Static Objects.
<br/>

* **Why need for generations?**
  * Performance of GC improves using generation. 
  * Let says GC comes 100 times and cleans memory, it will go 100 times to GC0 , 20 times GC1 and 10 times GC2 . These numbers are undeterministic.
  * This saves scanning times for objects.
  * These can be seen using Gen0, Gen1, Gen2 Size perf counters in visual studio.
<br/>

* **What is best place to clean un managed object?**
  * If a class uses a SQL handle or File handle then within that class **destructor** is the right place to cleanup for un managed object.
  * Destructor runs when the object instance is destroyed.
<br/>

* **What is the effect of putting destructor on GC?**
  * The GC re-claiming very slowly with destructor. When GC encounters the object with destructor, GC calls the destructor and promotes object from Gen 0 to Gen 1 then in the next run it cleans up the object. 
  * GC takes **more trips to clean up objects with destructor.** Hence more objects will accumulate in Gen 1 bucket or Gen 2 Bucket.
<br/>

* **How bad it is to have an empty destructor?**
  * Having an empty destructor will cause lot of harm as objects gets promoted to higher generations thus putting pressure on memory.
<br/>

* **How to solve more trips problems while cleaning object with Destructor?**
  * TO avoid multiple trips, we need to let GC know that cleanup from object side is already done for this we use IDispose Pattern. 
<br/>

* **Explain the Dispose Pattern**
    * In Dispose pattern we implement the IDisposable interface and call GC.SuppressFinalize(this) to tell GC that un managed object has been cleaned up adn claim the object do not wait. 
    * `SuppressFinalize(this)` means don't call the destructor , clean up in the first trip. Finalize == Destructor.
    * If Developer forgets to call Dispose then GC will come and clean up in multiple trips
```csharp
class SomeClass : IDisposable{

    ~SomeClass(){
        Dispose();
    }
    public void Dispose(){
        // cleanup code for un managed object.
        GC.SuppressFinalize(this); //this statement tells the GC in the first trip itself that this object is ready to cleanup as all un managed code has been cleaned up.
    }
}
```
<br/>

* **Finalize vs Destructor?**
  * Finalize and Destructor are one the same. Destructor calls the finalize method internally.
<br/>

* **What is use of Using Keyword?**
    * Defines the scope at the end of the scope Dispose() is called automatically. 
<br/>

* **Can you force GC to run?**
  * Using GC.Collect() - Can Force GC and passing 0, 1, 2, in this as param tells Which generation to clean.
<br/>

* **Is it a good practice to force GC?**
  * Fiddling with GC is not recommended at all because GC runs depending on various criteria's is memory running low, is processor getting overloaded and it does it's work wonderfully. 
<br/>

* **How can we detect bad memory? and How can wwe know the exact source of memory issue?**
  * Memory issues can be detected by running tools like visual studio profiler and we can check for two things: 
    * If the memory is increasing linearly it's a indication of memory issues. If the memory is moving in a range it is a healthy sign.
    * Also the memory allocation and de-allocation should be balance (Object delta change)- Should be red and green charts that is healthy sign. Red means de allocation. it is like a candle stick
  * In visual studio under allocations tab we can see class name which has maximum objects to know about the source of memory issue.
<br/>

* **What is memory leak?**
  * Situation where the memory consumed by the application is not returned back to the OS when the application exits. 
<br/>

* **Can .net APP have memory leak as we have GC?**
  * No We can have memory leak in .NET as complete memory of NET app is = UnManaged memory + Managed Memory. GC can clean only managed memory. 
<br/>

* How to detect memory leaks in a .NET Applications?
  * Total memory of .net app = Unmanaged + Managed.
  * So if you see just the total memory is increasing and managed memory is in a range then it means there is a memory leak in unmanaged memory.
<br/>

* **Explain strong and weak reference**
  * A weak reference permits the GC to collect the object but still allows to access the object until GC collects the object. We need to use the "WeakReference" object to create a weak reference.
    * `static WeakReference weak = new WeakReference(null);`
  * Strong reference - This is a normal referenced objects and once object is marked for GC it can never be referenced.
<br/>

* **When should we use weak reference?**
    * This should be used for object caching and object pooling and whenever object creation process is resource intensive caching and pooling can improve performance. 
    * But the code becomes complex as We have to use flags like weak.IsAlive etc  and code becomes complex.