# Performance Implications and Special Considering

1. **Scalability**:
   * Each component is decoupled and can scale independently.
   * Ensure a balance to avoid overwhelming certain parts of the system requires careful considerations.
2. **Processing Speed and Latency**:
   * Because EDA is asynchronous in nature we can see performance boost.
   * Flip side is **latency**
   * As system scales then volume of events increases, time taken to process an event frm when it is produced can grow causing delay in responses. 
3. **Error Handling and Message Durability**
   * What happens when an event fails to processed?
     * **System need retries. log failure or even alert an operator**
   * How to ensure messages are not lost in transit. 
     * Persistent storage may be required for events until they are processed. 
   * This can add complexity in system
4. **Event Schema and backward compatibility**
   * All component must understand the event structure. 
   * When schema changes (adding or removing fields) - backward compatibility should be ensured.
4. **Order of events**
   * Where order of events matter EDA can be challenge
   * Events by nature are async and could be processed in any order. 
5. **Testing**