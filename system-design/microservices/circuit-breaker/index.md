# Circuit Breaker
* Fault Tolerance is key aspect of a distributed system
* `Fault tolerance` is the system's ability to continue functioning correctly, possibly at a reduced level, rather than failing completely, when some part of it fails.
*  the Circuit Breaker pattern acts like this safety mechanism. 
   *  When a microservice (Service A) calls another (Service B), and 
      *  if Service B is struggling (slow response or failures), the circuit breaker "trips" to prevent further strain. 
      *  This way, Service A can either handle the issue gracefully or 
      *  rely on a fallback mechanism, instead of continually waiting for Service B and potentially crashing itself.
* **States**:
  * **Closed**: Default initial state; request pass through freely
  * **Open**: If error (timeout or error) > threshold. Circuit breaker trips and Stop sending request
  * **Half-Open State**: After cool down period, it sends limited number of test requests
    * If it success then continue sending
    * Else move back to open state
* Eg: Order Service --> Payment Service
  * After noticing a set number of failed attempts to the Payment Service, the circuit breaker trips.
  * The Order Service stops calling the Payment Service, returning a default response like "Payment processing is delayed" or it might queue the order for later processing.
  * After a cool down period, the circuit breaker allows a few requests to check if the Payment Service is back to normal.
<br/>

* **System Failures**: System failures in distributed system are a reality not an exception. Errors can be
  * Db Timing out
  * Hardware Issue
  * Network issue
  * software bugs
  * unresponsive services
  * slow services
  * In worst case scenarios, these issues can become catastrophic for whole system
  * If one of service slows down due to spike of requests then this will cause slow processing whole flow. This can cause **cascading failures** and propagate in whole system. 
<br/>

* **The problem of constant replies**
  * Common practice is to retry on service failure. This can be good for **transient failures**
  * But in an actual degradation of service it can further worsen it. 

* circuit breaker can offer a protective layer around your service calls, preventing a single point of failure from bringing down your entire system

## Working
* it works like an electric circuit breaker.
* 3 States of Operation:
  * Closed:
    * All request flow normally
    * It's as if no circuit breaker is there in system
    * Behind the scene circuit breaker is monitoring all the traffic in background
    * number of failures exceeds a predetermined threshold within a defined time window, the Circuit Breaker 'trips' 
  * Open
    *  it prevents any further requests from reaching the service
    *   it returns an error to the client immediately without sending any request to the identified degraded service.
    *   After a predetermined timeout period(cool down), the Circuit Breaker moves into the Half-Open state.
  * Half Open:
    * It allows a limited number of requests to reach the service and closely monitors their outcomes. If these requests are successful, indicating that the service has recovered, the Circuit Breaker goes back to the Closed state
    * Else goes back to open states and waits for the cooling period. 

## Adding it to your code
* it would not need a code re-write just adding a protective layer wrapping your service calls.
* Essentially, every time a request is made to a service, it is made through the Circuit Breaker. It is the Circuit Breaker that determines whether to forward the request to the service based on its current state and the outcome of recent requests.
* Start by adding it to the essential services only then progress. 

```csharp
using System;
using Polly;
using Polly.CircuitBreaker;

class Program
{
    static void Main()
    {
        // Define the circuit breaker policy
        var circuitBreakerPolicy = Policy
            .Handle<Exception>()
            .CircuitBreaker(
                exceptionsAllowedBeforeBreaking: 2,
                durationOfBreak: TimeSpan.FromSeconds(5),
                onBreak: (ex, breakDelay) =>
                {
                    Console.WriteLine($"Circuit is open due to {ex.Exception.Message}. Retry after {breakDelay.TotalSeconds} seconds.");
                },
                onReset: () =>
                {
                    Console.WriteLine("Circuit is reset.");
                },
                onHalfOpen: () =>
                {
                    Console.WriteLine("Circuit is half-open.");
                }
            );

        // Define the fallback policy
        var fallbackPolicy = Policy
            .Handle<Exception>()
            .Fallback(() =>
            {
                Console.WriteLine("Fallback executed.");
            });

        // Combine the circuit breaker and fallback policies
        var policy = Policy.Wrap(fallbackPolicy, circuitBreakerPolicy);

        // Execute an operation within the policy
        policy.Execute(() =>
        {
            Console.WriteLine("Executing operation...");
            SimulateOperation();
        });

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void SimulateOperation()
    {
        var random = new Random();
        var result = random.Next(0, 3);

        if (result == 0)
        {
            Console.WriteLine("Operation succeeded.");
        }
        else
        {
            Console.WriteLine("Operation failed.");
            throw new Exception("Simulated failure.");
        }
    }
}

```

## Configuring
* **Failure Threshold**: limit of failed requests needed before activating the circuit breaker.
* **Timeout Period(Recover/CoolDown time)**:  duration the Circuit Breaker remains in the Open state before moving to Half-Open.
* **No of requests in half open state**: how many requests are allowed through when the Circuit Breaker is in the Half-Open state,
*  The ideal settings depend on several factors:
   * The nature of the service and the system.
   * The expected load on the service.
   * The criticality of the service to the system's overall functionality
> **these params shouldn't be static, they can adjust by response and performance of other system**
* these dynamic adjustments may include:
  * Increasing the failure threshold, allowing the service to endure more failed requests before the Circuit Breaker activates.
  * Reducing the timeout period, enabling quicker recovery attempts, thus allowing the service to handle more requests during peak times.