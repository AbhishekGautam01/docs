# Event Driven Architecture Pattern

* Distributed systems have gained popularity because of scalability and resilience.
* Challenges of distributed system:
  * Increased system complexity
  * managing data consistency
  * handling asynchronous communication
* These issues are solved by Event driven architecture. 
* A **Event** is a change in state that holds some significance for objects in the system. 
* These events trigger specific actions. 

## THE PROBLEM: Managing complex interactions in distributed systems
* In distributed system we have multiple components that need to interact and coordinate. 
* In synchronous system, system makes a request and waits for the response before proceeding. This can be bottleneck as now you system is as fast as the slowest component
* Async communication, the system makes call and continues with other tasks, processing the response when it arrives. This is more efficient but more complex also. 

### Demand for real-time responsiveness
* Apps are becoming more real-time like sharing a photo should be immediately visible or online multi player games. 
* So in such system all the complex communication should happen in real time

### Data consistency
* Challenge is multiple systems are reading/writing data consistently so ensuring the consistency is important here. 
* If a component changes data, the other component working on that data should also be made aware about it. 
* Eg while making a transaction, as soon as it completes the account balance should be updated. 

## THE SOLUTION
* EDA deals with production, detection or consumption of events. 
* An event is change in state or an update that is produced by a component (**event producer**)
* This event is detected and consumed by one or more components known as **event consumer**
* Any messaging broker takes care of passing this event from producers to consumers
* Main adv is **it promotes decoupling**
* Eg - A user of instagram changes a photo - A photo posted event is sent
  * To update the followers
  * To update user profile
  * To notify the content moderation team
* Each of this action can be handled independently by just a single event
* Since producer continues it processing after publishing this increases the throughput and responsiveness of system. 
* Since producers and consumers are decoupled, they can scale independently based on workload. 
* Real-time processing of events is another benefit. 
* This is useful for 
  * **Fraud detection in banking**
  * **Realtime analytics**

### Components of Event Driven Architecture
* 3 Main Primary Components
  * **Event Producer**
    * Produce event
    * define what an event it
    * send it to event bus
  * **Event Bus** aka messaging queue
    * receives events from producer and transmit it to consumers. 
    * This decouples producers and consumers - so they work and scale independently
    * **Event Channels** - Segregate events based on nature and consumers. 
  * **Event Consumer**
    * Listen from events and react to them. 