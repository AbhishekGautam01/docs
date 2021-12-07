# Class Diagram 
* This shows how **different entities relate to each other**
* This shows **static structures of the system**
* This shows class **attributes, operations and constraints imposed on system**
* The purpose of this class diagram can be summarized as" 
    1. Analysis and design of the static view of an application;
    2. To describe the responsibilities of a system;
    3. To provide a base for component and deployment diagrams; and,
    4. Forward and reverse engineering.
<br/>

## How to?
* A class is depicted in the class diagram as a **rectangle with 3 horizontal sections**
* Upper section shows class name 
* Middle section shows class properties
* lower section contains the class operation/methods. 
    ![class-diagram](./img/class.svg)
    <br/>

## Different types of relationship 

### 1. Associations
* If two classes need to communicate with each other , then association **represent this link** 
* This is represented by **line and arrow pointing in direction of navigation**
    * By default associations are assumed to be **bi-directional** , both classes are aware of each other and their functionality.   
    * **uni-directional association** - two classes are related but only one class knows that **relationship exists** 

### 2. Multiplicity
* This indicates **how many instances of a class participate in the relationship**
* For example: FlightInstance will have 2 pilots but one pilots can have many FlightInstance
* A range of multiplicity can be expressed as **"O...""** which means **"Zero to many** or as "2...4" which means 2 to four
* We can indicate the multiplicity of an association by adding multiplicity adornments to the line denoting the association. 
![class-associations](./img/relationships.png)

### 3. Aggregations
* It is used to model **whole to it's part**. 
* Life cycle of **PART** class is independent on **WHOLE** class 
* Aggregation implies **a relationship where the child can exist independently of the parent**. Aircraft Can exist without Airlines. 

### 4. Composition 
* This is another form of **aggregation**. 
* Child class instance life cycle is dependent on the parent class instance lifecycle. 
* This denotes relationship where **child cannot exist independently without the parent** 
* Example: when Flight lifecycle ends, WeeklySchedule automatically gets destroyed.

### 5. Generalization 
* Combining similar classes of objects into **single or more general classes**.
* This identifies **commonalities amongst set of entities** 
* Crew , pilot and admin all are Person

### 5. Dependency
* In this one class or the client uses or depends upon another class, the supplier. 
* FlightReservation Depends upon Payment. 

### 6. Abstract Class
* It is specified by writing its name in _italics_
* Person and Accounts are abstract classes. 
<br/>

![uml-conventions](./img/uml-conventions.svg)