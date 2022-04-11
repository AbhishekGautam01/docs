# Transient Fault Handling 
> Transient faults are errors whose cause is expected to be a temporary condition such as temporary service unavailability or network connectivity issues.

## Retry 
* Retry allows callers to retry operations in the expectation that many faults are transient and may **self-correct**: the operation may succeed if retried, possibly after a short delay.

* Waiting between retries allows faults time to self-correct. Practices such as **exponential backoff** and **jitter** refine this by scheduling retries to prevent them becoming sources of further load or spikes.

## Circuit Breaker 
* Detected the level of faults in calls placed through it, and prevents calls when a configurable threshold is exceeded. 
* In cases of massive failure, underlying system is offline, and load the retries are not appropriate. 
* A further ramification is that if a caller is unable to detect that a downstream system is unavailable, it may itself queue up large numbers of pending requests and retries. This may **exhaust or excessively blocked waiting for reply**
* When faults exceed the threshold, the circuit breaks (opens). While open, calls placed through the circuit, instead of being actioned, fail fast, throwing an exception immediately.
* This protects downstream system from **additional load** and allows upstream systems to **avoid placing calls which are unlikely to succeed**
<br/>

* After a configured period, the circuit moves to a half-open state, where the next call will be treated as a trial to determine the downstream system's health. On the basis of this trial call, the breaker decides whether to close the circuit (resume normal operation) or break again.

## Fallback 
> A [Fallback](https://github.com/App-vNext/Polly/wiki/Fallback) policy defines how the operation should react if, despite retries - or because of a broken circuit - the underlying operation fails
* Like retry and circuit-breaker, a fallback policy is reactive in that it responds to defined faults. Fallback policies can be used to provide a substitute, pre-canned response for failed calls, or for more complex remedial action.

# Promoting resilience through proactive, stability oriented approach