# Bulk Head Pattern
* It is a strategy used in the design of distributed systems to `prevent failures from propagating` across different parts of the system. 
* On a ship, bulkheads are compartments designed to contain water in case of a hull breach. If water enters one compartment, the bulkhead prevents it from flooding the entire ship, hence limiting the damage.
* In a **distributed system**, a bulkhead is a mechanism that `isolates different parts of the system` so that if one part fails, it doesn't cause the rest of the system to fail.

## The challenge of cascading failures
* Each service has its own responsibilities, resources, and potential failure modes
* When a service fails, it can cause a ripple effect, where the failure of one service leads to the failure of other services that depend on it
* `Cascading Failures` are the biggest challenge in a distributed system.
  * How to avoid them?
  * How to contain them in only a part of system?
* Failures may occur due to Networks become unavailable, machines crash, software bugs emerge, and resources get exhausted.
* **Impact**:  A minor failure might cause a slight slowdown, while a major one can lead to complete system unavailability

## Solution
* The essence of bulkhead pattern lies in **Isolation**
* It breaks components of system into `isolated units or bulk heads`
* Each bulkhead is designed to operate independently of other. 
* Bulkheads can be viewed as a `failure containment`
* Bulkheads are not a guarantee to solve all problems it is like even in case of failure system may continue to work with limited functionality and we may buy in some more time to do the fixes.

## Architecture
* A bulkhead can be 
  * separate service, 
  * a group of related processes, 
  * a set of threads, 
  * or even a dedicated CPU or 
  * memory area.
* The first step in implementing the Bulkhead pattern is to divide your system into bulkheads. This depends on the nature of system, and specifics of errors you want to isolate. 
* you might group services based on their function or the type of users they serve.
* Resource allocation is a critical aspect of the Bulkhead pattern because it prevents a failure in one bulkhead from consuming all the system's resources. If a bulkhead fails and starts consuming resources excessively, the resource allocation ensures that other bulkheads still have resources available to them.
* Now we should `careful manage the inter-bulkhead communications to ensure errors don't propagate`
* interactions between bulkheads should be kept to a minimum
* For instance, if the user management service needs to interact with the inventory service, it could do so via a message queue or an API gateway. This way, if the inventory service fails, the failure doesn't directly impact the user management service. The interaction remains isolated and manageable, maintaining the spirit of the Bulkhead pattern.
  