# Abstract classes and Interfaces

* **Abstract Class?**
  * It is a half defined base parent class.
  * They are intended to act like parent classes. 
    Interfaces are implemented(Forced Contract) & Abstract classes are inherited. 
  * Eg Customer Abstract class- Discount() method will be different for each of these. 
    * WalkInCustomer
    * PremiumCustomer
    * EnquiryCustomer
<br/>

* **Interfaces**
  * Interfaces are just signature or a contract which the class implementing the interface promise to provide. 
  * Interfaces are kept without logic so developer can focus on abstraction, planning and decide what are most important things that needs to be shown. 
<br/>

> First interface is created then abstract class is created then we have concrete class where full logic is created.
> Interfaces are contract which leads to other benefits like unwanted impact analysis between client and interface designer. 
> If we make all methods/properties of abstract class as abstract then it becomes like interface. As in this if we implement ICustomer or inherit Customer class we have to implement all method properties. 
<br/>

* **Why do we need abstract classes?**
  * It is a half defined parent class. Customer base class, GoldCustomer & SilverCustomer can define own discounting logic. If we don't mark discount() method as abstract then discount() can be called using Customer class instance but customer class cannot provide the implementation currently. 
  <br/>

* **Are abstract methods virtual?**
  * Yes the abstract methods are virtual. Virtual methods in parent class can be override in child method. `public abstract decimal CalculateDiscount();`
  <br/>

* **Can we create a  instance of abstract class**
  * No , compiler will throw up an exception.
<br/>

* **Is it compulsory to implement abstract methods in child classes?**
  * Yes
<br/>

* **Why can't simple base class replace abstract class?**
  * Simple base class can't be defined partially. we cannot declare methods and properties with no implementation.
  <br/>

* **Explain interfaces and why do we need it?**
  * Interfaces are contract.
<br/>

* **Can we write logic in interface?**
  * No but in virtualized interfaces we can
<br/>

* **Can we define methods as private in interface?**
  * All methods/props are public
  <br/>

* **If I want to change interface whats the best practice?**
  * Never add any new method in current interface
  * Always create it in a new interface.
  <br/>

* **Explain multiple inheritance in interface?**
  * Yes it can.
  <br/>

* **Explain interface segregation principle?**
  <br/>

* **Can we create instance of interface?**
  * No
  <br/>

* **Can we do multiple inheritance with abstract classes?**
  * No