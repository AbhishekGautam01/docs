# Introduction to Java and OOPS

## JDK 
* JDK
  * Compiler: Source Code into Byte Code. App.Java into App.class which is intermediate code.
  * JRE: Environment for Byte code to run. Virtual OS which interpret the byte code into exec code.
    * JVM
      * JIT
    * API: Predefined APIs for IO, other low level codes. 

* **Java Platform Independency** : Code to byte code and using JIT it is converted to system dependent executable code by JVM. 

## OOPS in JAVA

* **Encapsulation**
  * Protecting functionality and properties of one object from another object. Capsule is class and props & methods are data and functionality. Class helps encapsulation 
* **Inheritance**
  * Defining a new object using existing object. **extends** keyword is used for this purpose. Also the new class can be adding new features. **Reusability** & **is-a** relation. Eg BMW is a Car and BMW can use common functionality of car. 
* **Abstraction**
  * Principle of hiding all unnecessary details of object and showing only essential functionality which is needed. This is done using **interfaces**.
  * Eg TV how it has been implemented is not important but using it for viewing. 
* **Polymorphism**
  * Multi - Forms : If objects can behave differently when different object use it. using object overloading and overriding. 
* **Classes & Objects**

## Procedure oriented vs Object oriented.
| Procedure Oriented | Object Oriented | 
| :---: | :---: |
| Sequence of Tasks | Data and Methods | 
| Procedure doing things | Data |
| Divided into function | Objects | 
| Data moving from function to function | Data is hidden using access specifiers | 
| Global data access | Access Specifiers | 
| C, Fortan , COBOL | C++ , Java, etc |

## Building blocks of Java program
* Class
* Variable: Memory location for data. referred using names. `data_type identity_name = value(optional)`
  * Static : Common across all object instances. 
  * Non Static: Object level different for each object
* Method : Set of programming instructions. `return_type name(arg_list){body...}` . Methods communicates with each other to do functionality.
* block : 
```java
class identity_name{
    variables(static or non static)
    methods
    blocks
}
```