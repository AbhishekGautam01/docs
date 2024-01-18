# Azure Event Hub
* message - is some data sent between receiver & sender. 
* events - are less complex and frequently used for broadcast this. 
  * It is a notification for something has happened.  
* Does the sender expect any particular processing to be done in the communication by the receiver?”
  * Yes - Message
  * No - Event
* Azure Message base delivery
  * Azure Service Bus
  * Azure Storage Queue
* Azure Event base delivery
  * Event grid
  * Event hub
* Azure EH & EG is used for business orchestrations for event storage and handling
* **Azure Event Grid**
  * Event routing service
  * allows the publisher to inform the consumer regarding any status change.
  * acts as a connector to tightly bind all the applications together and routes the event messages from any source to any destination.
* **Azure Event Bus**
  * data ingestion service which streams a huge count of messages from any source
  * Supported repeated replay of stored data.
  * Some data is stored in it even after it has been read by the consumer. 
> Event Grid is designed for one event at a time delivery and Event Hub is crafted to deliver a large stream of events along with data.

* **Event hub namespace**
  * dedicated scoping container
    * can have multiple event hubs inside it
* **Event Publisher**
  * Any one sending data to event hub 
  * It can happen through 
    * HTTP endpoints - for low volume of events
    * AMQP - for high volume of events
  * They use a **SAS - Shared Access Signature** token. 
  * Events can be single or grouped events 
  * **Event Hub Capture**
    * EHs can auto-capture and persist data in 
      * Blob storage
      * Azure Data lake
  * **Partitions**
    * EH splits up the streaming data into partition
    * In Service Bus queues and topics each consumer reads from the single queue lane (aka **competing consumer**)
    * Azure Event Hubs is based on the “**Partitioned Consumer**” pattern where multiple lanes are assigned which boosts up the scaling.
    * Events in partition stays there for a specific period of time and then auto removes
  * **Event Hub Consumer**
    *  Event hub consumers are connected through AMQP channels, this makes data availability easier for clients. 
 * **Consumer Groups**
   * Data in the event hub can be accessed only via consumer groups, partitions cannot be accessed directly
   * Each consumer can listen from this 
<br/>

## Scaling
* Throughput units (standard tier) 
  * volume of data in megabytes or the number (in thousands) of 1-KB events that ingress and egress through Event Hubs is referred to as throughput in Event Hubs. 
* processing units (premium tier)
* Partitions