# Sequence Diagram 
* Describes **interactions** among classes in terms of an **exchange of message over time**
* This is used to explore **logic of complex operations, functions or procedures** 
* they can show detailed flow of entire use-case or parts of it. 
* The **vertical dimension** shows **sequence of messages** in chronological order 
* The **horizontal dimension** shows object instance to which message was sent
![sequence](./img/seq.svg)

## How to 
* Across the top of your diagram, identify the class instances (objects) by putting each class instance inside a box. 
* If a class instance sends a message to another class instance, draw a line with an open arrowhead pointing to the receiving class instance and place the name of the message above the line. 
* Optionally, for important messages, you can draw a dotted line with an arrowhead pointing back to the originating class instance; label the returned value above the dotted line.