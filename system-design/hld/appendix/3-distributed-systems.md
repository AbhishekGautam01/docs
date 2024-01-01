# Distributed Systems
> **Definition**: A collection of independent components located on different machines that share messages with each other in order to achieve a common goal. It would still appear as one interface to end user. 

* Must have a **Network that connects all components(machine, hardware or software)** in which they can communicate and share messages. 
* **Messages** between machines contains forms of data like **files, objects, databases** 
* The way the messages are communicated reliably whether it’s sent, received, acknowledged or how a node **retries on failure** is an important feature of a distributed system.

## Types of Distributed Systems Architectures: 

### 1. Client Server
* In early days, DS contained **Server as a shared resource** like db, web server, printer.
* It has **multiple clients** which consume these shared resources as per need. 

### 2. Three Tier
* Client doesn't need to make decisions rather it can rely on middle tier to do decisions like which services/resources to consume. 
* Most initial web apps falls under this. 
* Middle tier can be stateless agent which takes incoming requests, process the data and forward to server. 

### 3. Multi Tier 
* Enterprise web apps. 
* Application server contains the business logic and interacts both with data tiers and presentation tiers. 

### 4. Peer-to-peer
* No Centralized or special machine to do heavy lifting . 
* All decision making responsibilities are split amongst involved machines. which could take role or client or server. 
* Example: Block chain