# Special Considerations and Performance Implications
* Circuit Breaker does introduce a minimal overhead. It must monitor the service's responses, track the number of recent failures, and make a decision every time a request is made. 
* But what if your service's performance is highly sensitive, and even the slightest increase in latency is unacceptable? In such cases, you could explore options like 
  * asynchronous Circuit Breakers or 
  * distributed Circuit Breakers.
* Another critical consideration is **Fine tuning parameters**
  * Failure Threshold:
    * Too low: Unnecessarily triping the circuit breaker
    * Too High: There's a risk of not responding quickly enough and causing cascading failures
  * Timeout period:
    * To Short: Not enough time to recover again going back to the open state
    * Too Long: Can result in prolonged service unavailability
* TO fine tune these we should understand:
  * Service Behavior
  * System Dynamics
  * Balancing between availability and stability
* We can monitor system performance over time and make adaptive changes to this config

## Beyond circuit breaker
* Circuit breaker is not a stand alone solution, we can have
  * Load Balancing
  * Rate limiting
  * retries and timeout
* 