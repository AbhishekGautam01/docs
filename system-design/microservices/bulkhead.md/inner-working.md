# Inner Workings
* maintaining this independence between bulkheads often involves careful design and implementation choices. For instance, each bulkhead might run in its own process or container, have its own database and cache, use its own thread pool, and so on.
* **Aim of resource allocations**: The aim here is to ensure fairness (each bulkhead gets the resources it needs) and efficiency (resources are not wasted).
* resource allocation mi*ght involve setting resource quotas or limits for each bulkhead, scheduling resources in a fair and efficient manner, and dynamically adjusting resource allocation based on real-time conditions.
* For instance, if one bulkhead is experiencing a surge in demand while another is idle, the system might temporarily reallocate some resources from the idle bulkhead to the busy one. This dynamic allocation can help to improve system performance and responsiveness.
* Failure detection this often involves a combination of monitoring, alerting, and automatic recovery mechanisms

## Example
### Scenario: Protecting an External API
* Let’s imagine that your application sends requests to a third-party API. The API may get overwhelmed if you permit an excessive number of concurrent requests, which could cause sluggish response times or even outages. By restricting the number of concurrent calls sent to the API, the Bulkhead Pattern can be helpful.
* 