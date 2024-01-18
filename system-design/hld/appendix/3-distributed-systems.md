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

## Characteristics of distributed System
1. **Scalability**
   1. Horizontal
   2. Vertical
2. **Availability**
   1. Availability through redundancy and replication
   2. Availability through Load Balancing
   3. Availability through Distributed Data Storage
   4. Availability and Consistency Models(Strong, Weak, Eventual)
   5. Availability through Health monitoring and alerts
   6. Availability through Regular System Maintenance and Updates
   7. Availability through Geographic Distribution
3. **Latency and Performance**
   1. Data Locality
   2. Load Balancing
   3. Caching Strategies
4. **Concurrency and Coordination**
   1. Concurrency Control
   2. Synchronization 
5. **Monitoring and Observability**
   1. Metrics Collections
   2. Distributed Tracing
   3. Logging
   4. Alert and Anomaly Detection
   5. Visualization and Dashboards
6. **Resilience and Error Handling**
   1. Fault Tolerance
   2. Graceful Degradation
   3. Retry and Backoff strategies 
   4. Error Handling and Reporting
   5. Chaos Engineering
7. **Fault Tolerance vs High Availability**
   1. Fault Tolerance 
   2. High Availability