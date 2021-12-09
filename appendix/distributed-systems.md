# Distributed Systems
> **Definition**: A collection of independent components located on different machines that share messages with each other in order to achieve a common goal. It would still appear as one interface to end user. 

* **Most important functions of distributed computing** 
    * **Resource Sharing** - Sharing hardware, software or data 
    * **Openness** - How open is the software designed to be developed and shared with each other. 
    * **Concurrency** - multiple machines can process the same function at the same point. 
    * **Scalability** - How do the computing and processing capabilities multiply when extended to many machines. 
    * **Fault tolerance** - How easily and quickly can failures in parts of the system can be detected and recovered. 
    * **Transparency** - How much access does one node have to locate and communicate with other nodes in the system. 
> **NOTE:** Many modern distributed systems have evolved to include autonomous processes that might run on the same physical machine. 
<br/>

# Distributed System Architecture 
* Must have a **Network that connects all components(machine, hardware or software)** in which they can communicate and share messages. 
* **Messages** between machines contains forms of data like **files, objects, databases** 
* The way the messages are communicated reliably whether it’s sent, received, acknowledged or how a node **retries on failure** is an important feature of a distributed system.

# Types of Distributed Systems Architectures: 

## 1. Client Server
* In early days, DS contained **Server as a shared resource** like db, web server, printer.
* It has **multiple clients** which consume these shared resources as per need. 

## 2. Three Tier
* Client doesn't need to make decisions rather it can rely on middle tier to do decisions like which services/resources to consume. 
* Most initial web apps falls under this. 
* Middle tier can be stateless agent which takes incoming requests, process the data and forward to server. 

## 3. Multi Tier 
* Enterprise web apps. 
* Application server contains the business logic and interacts both with data tiers and presentation tiers. 

## 4. Peer-to-peer
* No Centralized or special machine to do heavy lifting . 
* All decision making responsibilities are split amongst involved machines. which could take role or client or server. 
* Example: Block chain

# Key Characteristics: 
* Key Characteristics: 
    1. Scalability 
    2. Reliability
    3. Availability 
    4. Efficiency 
    5. Manageability 
<br/>

# Scalability
> **Definition:** Capacity of System , Process or a network to grow and manage increased demand without **performance loss**. 
* A system may scale due to **increased data volume** or **increased number of transactions**
* It can be effected by reasons like: 
    * In network systems are far apart. 
    * transactions are not distributed because of design flaw or they are not atomic 
    * Task would limit the speed-up obtained by distribution. 

## Horizontal vs Vertical Scaling
* **horizontal Scaling** - Adding more servers to the pool of resources. 
    * Easier to scale dynamically by adding more machines. 
    * Eg Cassandra and MongoDB provide easily h scaling. 
* **Vertical Scaling** - Adding more power(**CPU, RAM, Storage, etc**) to existing server
    * Limited by capacity of single server
    * Eg MySQL 
    <br/>

# Reliability 
> **Definition**: Probability a system will fail in a given period. 
* A distributed system is considered reliable when even if on multiple component failures it keeps delivering services. 
* This can be achieved through **redundancy** of software and data components. 
* This would increase **cost** but also increase **resiliency** 
<br/>

# Availability 
> **Definition:** Time a system remains operational to perform its required function in a specific period of time. 
* Percentage of time a system remain operation during normal operation. 
* Availability accounts for **maintainability, repair time , spares availability and other logistic considerations** 

## Reliability vs Availability 
* If a system is reliable, it is available. If it is available then it is not necessarily reliable. 
* **High Reliability --> High Availability** Vice versa is not always true. 
<br/>

# Efficiency 
* Two Standard measures of efficiency are: 
    1. **Latency** - Response time. Time to obtain first item
    2. **Throughput** - Bandwidth - number of item delivered in given unit time. 
* These two measures corresponds to following cost. 
    1. Number of messages globally sent by the nodes of the system regardless of the message size. 
    2. Size of messages representing the volume of data exchanges. 
<br/>

# Serviceability or Manageability 
* **How easy any distributed system is to manage and operate?** 
* Speed at which system can be repaired or maintained. 
<br/>

# Examples of Distributed Systems
1. **Telecommunications systems:** 
2. **Distributed Real-time Systems**: real-time system distributed locally and globally. Flight-control systems, Uber, automation control systems
3. **Parallel Processing**: 
4. **Distributed Artificial Intelligence**: It uses large scala computing power and parallel processing to learn and process very large data sets using multiple agents. 
5. **Distributed Database Systems** Located over multiple servers and/or physical locations. 
    * **Homogenous Distributed Database**: Each system has the same dbms and data model. Easier to manage and scale. 
    * **Heterogenous Distributed Database**: It allows for multiple data models, different dbms systems. Gateways are used to translate the data between nodes and usually happen as a result of merging applications and systems.

