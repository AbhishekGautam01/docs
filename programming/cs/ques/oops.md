# Object Oriented Programming

* **Why do we need OOP?**
  * It forces the developer to think in terms of real world objects. 
  <br/>

* **What are the important pillars of OOPS**
  * Abstraction: Show only what is necessary
  * Polymorphism
  * Inheritance
  * Encapsulation
<br/>

* **What is class and object?**
  * Class is a blueprint and objet is a real world instance of this blue print. 
<br/>

* **Abstraction vs Encapsulation?**
  * Abstraction show only what is necessary. Employee {public Name, public Age, public Validate(); private checkName(), private checkAddress()} - outside world should see only Validate and not internal methods that Validate function would use. 
  * Encapsulation means hide complexity; Using access modifiers to implement concept of abstraction.
  * `Encapsulation implements abstraction`. Abstraction happens on design phase and encapsulation happens during the dev phase.
<br/>

* **Explain Inheritance?**
  * Inheritance defines a parent and a child relationship. 
  <br/>

* **Explain virtual keyword**
  * Virtual helps define some logic in parent class which can be further overridden and then in child class override using override keyword.
<br/>

* **What is overriding?**
  * Same method signature but different implementation.
  <br/>

* **What is overloading?**
  * Same method name with different signature.
  <br/>

* **Overloading vs Overriding?**
  * Overloading - Method with same names and with different signatures in same class
  * Overriding - Comes in parent child relationship. parent class method marked virtual and in child class it is overidden.
  <br/>

* **What is polymorphism?**
  * 
<br/>

* **Can polymorphism work with out inheritance**
<br/>

* Explain Static vs dynamic polymorphism(Compile time vs runtime polymorphism)
  * static poly is implemented by method overloading
  * dynamic poly is implemented by method overriding. 
<br/>

* **Explain operator overloading**
  * used to refine the operator. 
    * `public static SomeClass operator +(Someclass arg1, Someclass arg2){}`
<br/>
