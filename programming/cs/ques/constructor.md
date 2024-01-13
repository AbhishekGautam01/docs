# Constructors

* **Why do we need constructors**
  * Special method of class which gets automatically invoked when an instance of class is created. 
<br/>

* **IN parent child which constructor fires first?**
  * The parent constructor will be fired first. As on the base of parent the child should be created.
<br/>

* **How are initializers executed?**
  * Initializers means the member level variables. like int i = 1; 
  * The child initializers runs then parent initializers, then parent constructor then child constructor. 
<br/>

* **How are static constructors executed in Parent child?**
  * The static constructor of child fires then the static constructor of parent after normal constructor of parent fire then the child fire. 
<br/>

* **When does static constructor fires?**
  * Static constructor fires when we access the class for the first time. 
<br/>

* **Why do we need private constructor in C#?**
  * TO implement singleton pattern.
  * Preventing the instantiation
  * Factory methods
    ```csharp
    public class MyClass
        {
            private MyClass() { }

            public static MyClass CreateInstance()
            {
                // Additional logic if needed
                return new MyClass();
            }
        }
    ```
  