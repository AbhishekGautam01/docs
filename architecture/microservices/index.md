# Design Patterns for microservices 
* **Goal**: Increase Velocity of application releases, by decomposing the application into small autonomous services that can be deployed independently. 
![microservices-patterns](./img/microservices-patterns.png)
1. Ambassador
    > **Definition**: Can be used to offload common client connectivity tasks such as monitoring, logging, routing and security in language agnostic way. 
2. Anti-Corruption Layer 
    > **Definition**: Implements Facade between new and legacy apps to ensure that design of a new app is not limited by dependencies on legacy system. 
3. Backends for Frontend
    > **Definition**: Creates separate backend services for different types of clients. Single backend service doesn't need to handle all conflicting requirements of various client types.
4. Bulkhead 
    > **Definition**: It isolates critical resources such as connection pool, memory and CPU for each workload or service. By using this, a single service cant starve others. This increases **resiliency** & **prevents cascading failures**
5. Gateway Aggregation
    > **Definition**: aggregates requests to multiple individual microservices into a single request, reducing chattiness between consumers and services.
6. Gateway Offloading
    > **Definition**: enables each microservice to offload shared service functionality, such as the use of SSL certificates, to an API gateway.
7. Gateway Routing 
    > **Definition**: routes requests to multiple microservices using a single endpoint, so that consumers don't need to manage many separate endpoints.
8. Sidecar
    > **Definition**: deploys helper components of an application as a separate container or process to provide isolation and encapsulation.
9. Strangler Fig 
    > **Definition**: supports incremental refactoring of an application, by gradually replacing specific pieces of functionality with new services.
