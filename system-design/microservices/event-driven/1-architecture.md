# The Architecture of Event Driven Architecture

* **COMPONENTS**
  * **Event Producer**:
    * Generate Events
  * **Event Channels**:
    * Pipeline through which events flows from producer to consumer.
    * Events are categorized into channels based on consumer
  * **Event Bus**:
    * Responsible for routing events from producers to consumers
  * **Event Consumers**: 
    * Components that act upon events.
<br/>

## Structuring the System
* 3 Main types of EDA Patterns:
  * Mediator
  * Broker
  * Hybrid

1. **Mediator EDA**: Here central mediator component takes charge of event handling
   * **Steps**
     1. Event producers send their events to the mediator
     2. Mediators knows about all producers and consumers and **determine where to route events**
     3. It performs
        1. Event aggregation
        2. Filtering 
        3. Event transformation
     4. After this delivers the events to appropriate event consumers
   * Mediator EDA offers control. 
   * It allows complex routing and transformation logic, providing control over event processing. 
   * **Drawback**: Mediator can become a bottleneck
<br/>

2. **Broker EDA**: No Central mediator
   1. Event producers send their events directly to event channels on the event bus. 
   2. Event consumers directly consumers from the events channel on event bus
   3. The broker is **Event Bus**
<br/>

3. **Hybrid EDA**:
   1. This is a mix of both, it is used when we want centralized control and high scalability

## Inner working
* Example of events start with a change in state in the system.
  * User action
  * Sensor reading
  * internal system update
* An event consumer is always listening. They are setup to monitor their subscribed channels on the event Bus, waiting for events. 
* The listening mechanism is usually implemented using observer or publish subscribe patterns.

## Event sourcing and CQRS
* Event sourcing means that changes in events are stored as a sequence of events and not just as a snapshot of the current state. 
* This allows full audibility
* Versioning
* ability to time travel in system at any point in time by replaying events
<br/>

* CQRS involves separating read and write operations, this is useful in EDA as it allows us to model our Event Handlers(write operations) separately from our views(read operations)

# Code Example
1. **Creating event**:
   ```java
    public class VehicleEvent {
        private final String vehicleId;
        private final String type;

        public VehicleEvent(String vehicleId, String type) {
            this.vehicleId = vehicleId;
            this.type = type;
        }

        public String getVehicleId() {
            return vehicleId;
        }

        public String getType() {
            return type;
        }
    }
   ```
2. **Creating event producer**
   ```java
        public class Sensor implements EventProducer {
        private EventBus eventBus;

        public Sensor(EventBus eventBus) {
            this.eventBus = eventBus;
        }

        public void vehicleDetected(String vehicleId, String action) {
            VehicleEvent event = new VehicleEvent(vehicleId, action);
            eventBus.publish(event);
        }
    }
   ```
3. **Event Bus**
   ```java
   public interface EventBus {
    void publish(VehicleEvent event);
    void addChannel(EventChannel channel);
    }

    public class SimpleEventBus implements EventBus {
        private List<EventChannel> channels;

        public SimpleEventBus() {
            this.channels = new ArrayList<>();
        }

        @Override
        public void publish(VehicleEvent event) {
            for (EventChannel channel : channels) {
                channel.add(event);
            }
        }

        @Override
        public void addChannel(EventChannel channel) {
            channels.add(channel);
        }
    }

    public interface EventChannel {
        void add(VehicleEvent event);
        void addConsumer(EventConsumer consumer);
    }

    public class SimpleEventChannel implements EventChannel {
        private List<EventConsumer> consumers;

        public SimpleEventChannel() {
            this.consumers = new ArrayList<>();
        }

        @Override
        public void add(VehicleEvent event) {
            for (EventConsumer consumer : consumers) {
                consumer.onEvent(event);
            }
        }

        @Override
        public void addConsumer(EventConsumer consumer) {
            consumers.add(consumer);
        }
    }
   ```
3. **Event Consumers**
   ```java
   public class TrafficLight implements Event

    Consumer {
        @Override
        public void onEvent(VehicleEvent event) {
            if ("entering".equals(event.getType())) {
                System.out.println("Vehicle " + event.getVehicleId() + " is entering. Adjusting traffic light timings.");
            } else if ("leaving".equals(event.getType())) {
                System.out.println("Vehicle " + event.getVehicleId() + " has left. Resetting traffic light timings.");
            }
        }
    }
   ```