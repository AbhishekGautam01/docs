# C# Classes related concepts

* **What is shadowing?**
  * Shadowing or method hiding, the child methods/properties/function will be hidden from parent class while polymorphism. 
  * When the child class inherits parent methods, instead of overriding the method of parent it would hide it using the new keyword instead of override keyword.
  * Doing this let say Customer(Parent){decimal calcDisc(); } and Child EnquireCustomer: Customer {new decimal calcDisc()} now if we make the parent class variable point to instance of Enquire class  like `Customer c = new EnquireCustomer()` then on var c we call call the calcDisc() it will call parent's implementation where as if we we had override this then c.calcDisc() will call child implementation.;
<br/>

* **Explain method hiding?**
<br/>

* **Shadowing vs Overriding**
* In overriding polymorphism is followed and parent object will invoke child methods which are override.
* While in case of shadowing the parent object will not see/invoke the shadowed methods during polymorphism. 
<br/>

* **When should you use shadowing?** 
  * Shadowing is a hack which we use when we have inherited/grouped in wrong way.
  * This is used when we violate LSP. Here the child is not backward compatible with parent. 
  * Shadowing is a reactive measure where the child class does not implement all the method of parent it leads to a Liskov issue.
<br/>

* **Explain Sealed Classes?**
  * Which cannot be inherited any further. This is done using the sealed keyword. 
<br/>

* **Can we create instance of sealed classes?**
  * Yes we can create the instance of sealed class.
<br/>
  
* **What are nested classes and when to use them?**
  * A class inside a class. 
  * 2 basic usage:
    * to logically group together Class Utility {class basicValidation{}, class Logging{}, class DatetimeFormatting{}}
    * When the class being nested is only useful to the enclosing class. Class Customer { class CustomerEligible{} } -- Declaring CustomerEligible will cause unnecessary pollution
<br/>

* **Can nested classes access outer class variables?**
  * You can not access directly the variables of the outer class. But if you pass the instance of the outer class to the methods of Nested class and you can access outer class properties through the instances.
<br/>

* **Can we have public protected access modifiers in nested class?**
  * We can put any access modifiers technically. 
  * Depending on the scenario
<br/>

* **Explain Partial classes?**
  * Partial classes can be written in two or more different physical files but while compiling the compiles to one class. 
  * This is done by using partial keyword. 
<br/>

* **In what scenarios do we use partial classes?**
  * In RAPID App dev tools where there is lot of code generations happening, like in WPF apps, etc. 
  * To organize complex code in to different physical files. Like core logic in one class , validations in another.
<br/>

* **Creating an Immutable class**
  * So properties should not change once created this is simple, by creating properties as readonly and have a parameterized constructor to initialize it. 