# Use Case Diagrams
* It describes **set of actions(called use cases) that a system should or can perform in collaboration with one or more external users of the system(called actors**)
* Each use case should provide some **observable and valuable result to the actors**
<br/>

1. Use case diagrams describe the **high-level functional behavior of system**
2. It answers what system does from **user point of view** 
3. It tells us **what system will/will not do?**

* Use is **unit of functionality** provided by the system. 
* this helps dev teams visualize the **functional requirements of system including actors** 

## How to ?
* We use **ovals** to illustrate a new use case and put name of it. 
* TO denote **actors** we draw **stick diagrams** either in left or right of diagrams.  
![usecase](./img/usecase.svg)

## Components of diagram
1. **System Boundary**: defines **scope and limits of the system**. It is shown in rectangle. 
2. **Actors**: **entity** which performs specific actions. These roles are **actual business user roles**. Actors interact with Use Case. 
3. **Use Case**: Every **business functionality** is a potential use case. This should list **discrete business functionality** 
4. **Include**: This represents **an invocation of one use case by another use case**. From coding purpose it is like one function being called by another function. 
5. **Extend**: This relationship signifies that the extended use case will work exactly like the base use case, except that **some new steps will be inserted in the extended use case**.