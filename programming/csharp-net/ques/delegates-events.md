# Delegates & Events

1. **What is a Delegate?**
   1. It is a pointer to a function. Delegates are callbacks which helps to communicate between concurrent, async and parallel process. 
   2. The point of invoking a function via delegates without doing it directly is that **callbacks** can be supported using delegates. 
   3. 

```csharp
class Program{
    

    static void Main(string[] args){
        MyFileSearch x = new MyFileSearch();
       // x.Search("filePath"); //blocking call. Synchronous
        Task.Run(() => x.Search("filePath")) //NonBlocking Call
    }

    class MyFileSearch{
        public delegate void searchMethod(string search); //declaring delegates. Same as method signature.
        public static searchMethod publisher = null. // instance
        public void Search(string dir){
            ..code
        }
    }
}
```