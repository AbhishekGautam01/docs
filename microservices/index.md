# Microservices Architecture
* Below Patterns are covered as part of this documentation: 
   1. **Strangler Fig Pattern**: Facilitates the gradual replacement of a monolithic system with microservices, ensuring a smooth and risk-free transition.
   2. **API gateway Pattern**: Centralizes external access to your microservices, simplifying communication and providing a single entry point for client requests.
   3. **Backend for frontend (BFF)**: Creates dedicated backend services for each frontend, optimizing performance and user experience tailored to each platform.
   4. **Service Discovery Pattern**: Enables microservices to dynamically discover and communicate with each other, simplifying service orchestration and enhancing system scalability 
   5. **Circuit Breaker Pattern**: Implements a fault tolerance mechanism for microservices preventing cascading failures by automatically detecting and isolating faulty services. 
   6. **Bulkhead pattern**: Isolates microservices into separate partitions, preventing failures in one partition from effecting the entire system enhancing system resilience. 
   7. **Retry Pattern**: Enhances microservices resilience by automatically retrying failed operations, increasing the chances of successful execution and minimizing transient issues.
   8. **Sidecar Pattern**: Attaches additional components to your microservices, providing modular functionality without altering the core service itself. 
   9. **Saga Pattern**: Manages distributed transactions across multiple microservices, ensuring data consistency while maintaining the autonomy of your services. 
   10. **Event driven architecture pattern**: Leverages events to trigger actions in your services, promoting loose coupling between services and enabling real-time responsiveness. 
   11. **CQRS(Command Query Responsibility Separation)**: Separates the read and write operations in a microservice, improving performance, scalability, and maintainability. 
   12. **Configuration Externalization Pattern**: Provides a method to externalize the configuration from the code, enabling microservices to be reconfigured without the need for recompilation or redeployment. 
   13. 