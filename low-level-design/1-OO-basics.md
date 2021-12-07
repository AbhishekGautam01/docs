# Object Oriented Basics
* It focuses on objects to design and build apps. 
* It organizes apps to combine **data and functionality** and wrap it in **object**
* Some basic Concepts: 
    1. **Objects**: real-world entity and the basic building block of OOP. 
    2. **Class**: Prototype or blueprint of object. It is template defination of attributes and methods. 
<br/>

* There are 4 important principles of OO Design: 
    1. **Encapsulation**: Mechanism of **binding data together and hiding it from outside world.** This is achieved when object keeps its state private and expose only through public function and properties. 
    2. **Abstraction**: It is **natural extension of encapsulation**. Hiding all but relevant data and functionality of object to reduce the complexity. This simplifies object to object communication by exposing only the required functionality. 
    In C# abstraction can be achieved with help of **Abstract Classes** 
        * These classes cannot be instantiated. 
        * This can have abstract as well as non abstract methods. 
        * Abstract methods cannot be declared outside abstract class. 
        * These classes cannot be marked as sealed. 
        * Non abstract methods of abstract class can be called by using child class object reference. 
        * Static methods of abstract class can be called by name. 
        * We need to override abstract methods
    3. **Inheritance**: Creating new classes from existing class.
    4. **Polymorphism**: It is ability of object to take different forms and thus depending upon context respond to different message in different ways. 
    Compile time polymorphism can be achieved my method and parameter overloading and runtime polymorphism can be achieved by method overriding which is also known as **dynamic or late binding**
