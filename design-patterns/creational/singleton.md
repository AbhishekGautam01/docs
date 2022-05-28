# Singleton 
* Here a class has only one instance in the program that provides **a global point of access to it.**
* **Characteristics**: 
    1. Private and parameter less single constructor
    2.  Sealed class
    3. Static variable to hold reference to the single created instance 
    4. A public and static way of getting the reference to the created instance. 

## Advantages 
* It can implement interfaces 
* Can be **lazy-loaded** and has **static initialization**
* It helps to hide dependencies 
* it provides a single point of access to a particular instance, so it is easy to maintain. 

## Disadvantages 
* Unit testing is bit difficult as it introduces a global state into application
* reduces the potential for parallelism within a program by locking

# Singleton vs Static methods 
1. Static class cannot be extended whereas a singleton class can be extended
2. A static class cannot be initialized whereas a singleton class can be. 
3. A static class is loaded automatically by the CLR when the program containing the class is loaded. 

# Implementation Approaches 
## NO Thread Safe singleton 
* Two different threads could both have evaluated the test (if instance == null) and found it to be true, then both create instances, which violates the singleton pattern.
```
public sealed class Singleton1 {
    private Singleton1(){}
    private static Singleton1 instance = null;
    public static Singleton1 Instance {
        get {
            if(instance == null){
                instance = new Singleton1();
            }
            return instance;
        }
    }
}

```

## Thread Safety Singleton
* **Code Explanation** 
    1. n the code, the thread is locked on a shared object and checks whether an instance has been created or not. It takes care of the memory barrier issue and ensures that only one thread will create an instance. For example: Since only one thread can be in that part of the code at a time, by the time the second thread enters it, the first thread will have created the instance, so the expression will evaluate as false.
    2. The biggest problem with this is performance; performance suffers since a lock is required every time an instance is requested.
```
public sealed class Singleton2{
    Singleton2(){}
    private static readonly object lock = new object();
    private static Singleton2 instance = null;
    public static Singleton2 Instance {
        get{
            lock(lock){
                if(instance == null){
                    instance = new Singleton2();
                }
                return instance; 
            }
        }
    }
}
```

## Thread Safety Singleton using double-check locking
* The thread is locked on a shared object and checks whether an instance has been created or nto with double checking 
```
public sealed class Singleton3{
    Singleton3(){}
    private static readonly object lock = new object();
    private static Singleton3 instance = null;
    public static Singleton3 Instance {
        get {
            if(instance == null){
                lock(lock){
                    if(instance == null){
                        instance = new Singleton3();
                    }
                }
                return instance;
            }
        }
    }
}
```

## Thread Safe Singleton without using locks and no lazy instantiation
* it is not lazy as other implementation
```
public sealed class Singleton4    
{    
    private static readonly Singleton4 instance = new Singleton4();    
    static Singleton4()    
    {    
    }    
    private Singleton4()    
    {    
    }    
    public static Singleton4 Instance    
    {    
        get    
        {    
            return instance;    
        }    
    }    
}   
```

## Using .NET 4's Lazy<T> type
* If you are using .NET 4 or higher then you can use the System.Lazy<T> type to make the laziness really simple.
* You can pass a delegate to the constructor that calls the Singleton constructor, which is done most easily with a lambda expression.
* Allows you to check whether or not the instance has been created with the IsValueCreated property.
```
public sealed class Singleton5    
{    
    private Singleton5()    
    {    
    }    
    private static readonly Lazy<Singleton5> lazy = new Lazy<Singleton5>(() => new Singleton5());    
    public static Singleton5 Instance    
    {    
        get    
        {    
            return lazy.Value;    
        }    
    }    
}    
```