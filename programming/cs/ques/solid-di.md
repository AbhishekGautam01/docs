# SOLID & Dependency Injection

* **What is SOLID?**
  * 5 Design Principles
<br/>

* **WHat is full form of SOLID?**
  *  SOLID :
    * Single Responsibility
    * Open Closed
    * LISKOV Substitution
    * INterface Segregation Principle
    * Dependency Inversion
<br/>

* **What is goal of SOLID?**
  * The main goal of SOLID is to minimize dependencies. Thus making code understandable,maintainable and extendable.
<br/>

* **Explain SRP with example?**
  * Single Responsibility Principle
  * A class should have only one purpose.
<br/>

* **What is the benefit of SRP?**
  * Helps achieve More modular and focussed classes
  * A class/module/function should have only one reason to change
  * Eg. Customer has name , address, gender but it doesn't have responsibility to compute discount. Rather we should have Discount and Customer class.
<br/>

* **What is OCP explain by Example?**
  * Open Closed Principle: Open for Extension but closed for modification. 
  * Eg. We want to have a new criteria if customer is from mumbai give 100rs flat discount, what OCP says here instead of adding if for this, extend this, make it virtual and create a new class and override the method in that. 
<br/>

* **What is the benefit of OCP?**
  * Any design principle is not silver bullet, this is useful when class is consumed at multiple places modifications may have huge impact or side effects and all consumers may also need not get the change.
  * Reduces the impact changes as you are now making changes in the inherited class. 
<br/>

* **Can you explain LISKOV Principle and it's violation**
  * The child class should be able to replace the parent class seamlessly without any side effects. 
  * Eg Customer class, PremiumCustomer class, EnquiryCustomer - Both child should be able to replace CustomerClass object. 
  * In inheritance child class can not remove methods of the parent.
  * The child class should implement all methods of parents then we will not have the problem.
<br/>

* **How can we fix LISKOV Problem?**
  * Lack of clarity of understanding of requirement or poor domain language. Like the dev misunderstood an equiry customer is also like any other customer 
  * It looks like ducks , quacks like duck but it has battery.
  * Refactoring the code is the solution if mistake has reached the production.
  * CustomerBase(Name, Age, Address), Customer(Amount) and EnquiryCustomer():CustomerBase and PremiumCustomer(Amount).
<br/>

* **Explain interface segregation principle?**
  * No code should be forced to depend on method it does not use. 
  * Let say we have IRepository(with CRUD) now we have Reporting class which is just read here we can implement IRepository here because he will have to implement the extra CUD methods. 
  * Interfaces should be as slim as possible. Abstraction - Show only what is necessary. 
<br/>

* **Is there a connect between LISKOV and ISP?**
  * Both look similar as in one we are splitting parents and in second we split the interfaces.
  * LIKSKOV is more related to inheritance where we have grouped classes in a wrong family. Due to which the child class is forced to implement those. LSP focusses on wrong inheritance.
  * ISP is more broad and deals with interfaces.
<br/>

* **Define dependency inversion?**
  * Higher level modules should not depend on lower level modules directly but they should go via an abstraction.
<br/>

* **What is higher level module and lower level module?**
  * Higher Level Modules: Caller Module which calls the other module
  * Lower Level Modules: Callee Module which gets consumed is terms as Lower Level module. 
<br/>

* **How does dependency inversion benefit, show with an example?**
  * When one module is directly connected causes tight coupling. 
  * Any changes in lower level class then the higher level module will also have to change like if we introduce a new discount DiscountWeekend then without abstraction the high level module code will change. 
  * Go via abstraction - Go through an interface
<br/>

* **Will only Dependency inversion solve decoupling problem completely?**
  * No because to use interface we assign them obj instance within the high level module then it is again tight coupling 
<br/>

* **Why do developers move object creation outside high level module?**
  * To have low coupling, We use factory pattern or dependency injection.
<br/>

* **Explain IOC(Inversion of Control)?**
  * We invert the object creation control outside the higher module. The unnecessary job of object creation moves out of higher level module. 
<br/>

* **Explain Dependency injection with an example?**
  * It is a process in which we try to inject the Dependent objects.
<br/>

* **Is SOLID, IOC, DI design pattern or principle?**
  * SOLID is a principle
  * IOC is a principle
  * DI is a technique.
<br/>

* **Is only SOLID enough for good code/architecture?**
  * SOLID, DRY< Design Pattern, Architecture pattern, architecture principle, DI, IOC are everything combined gives the effect. 
  * All of these try to reduce the impacts of changes in longer term.