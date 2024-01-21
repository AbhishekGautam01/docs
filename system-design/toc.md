# Table of Contents

- [Table of Contents](#table-of-contents)
- [`SOLID`](#solid)
- [`Low Level Design`](#low-level-design)
  - [`Basics Concepts`](#basics-concepts)
  - [LLD Designs](#lld-designs)
- [`High Level System Design`](#high-level-system-design)
  - [`Appendix`](#appendix)
  - [`HLD Designs`](#hld-designs)
- [`Microservices`](#microservices)
    - [`DDD`](#ddd)
    - [`Hexagonal Architecture`](#hexagonal-architecture)
    - [Pattern](#pattern)
- [`Design Patterns`](#design-patterns)


# [`SOLID`](./solid/)
1. [`Single Responsibility`](./solid/index.md#s-single-responsibility-principle)
2. [`Open Closed Principle`](./solid/index.md#o-open-closed-principle)
3. [`Liskov Substitution`](./solid/index.md#l-liskov-substitution-principle)
   1. [`LSP In Depth`](./solid/LSP.md)
4. [`Interface Segregation`](./solid/index.md#i-interface-segregation-principle)
5. [`Dependency Inversion`](./solid/index.md#d---dependency-inversion-principle)
6. [`Dependency Injection vs Inversion of Control`](./solid/di-ioc-di.md)
7. [`Documentation`](./solid/SOLID.docx)

# [`Low Level Design`](./lld/)

## `Basics Concepts`
1. [`OO Basic`](./lld/1-OO-basics.md)
2. [`OO Design & analysis`](./lld/2-OO-design-and-analysis.md)
3. [`UML`](./lld/3-UML.md)
4. [`Use Case Diagram`](./lld/4-use-case-diagram.md)
5. [`Class Diagram`](./lld/5-class-diagram.md)
6. [`Sequence Diagram`](./lld/6-sequence-diagram.md)
7. [`Activity Diagram`](./lld/7-activity-diagrams.md)

## LLD Designs
1. [`Hotel Management`](./lld/hotel-management/index.md)

# [`High Level System Design`](./hld/)
0. [`General Tips`](./hld/0_general_tips.md)
1. [`Functional vs Non Functional Estimates`](./hld/1-functionalvsNFR.md)
2. [`Master Template`](./hld/master-template.md)

## [`Appendix`](./hld/appendix/)
   1. **[`Load Balancers`](./hld/appendix/1-load-balancer.md)**
      1. [`Terminologies`](./hld/appendix/1-load-balancer.md#terminologies)
      2. [`How Load Balancer Words`](./hld/appendix/1-load-balancer.md#how-load-balancers-works)
      3. [`Uses`](./hld/appendix/1-load-balancer.md#uses-of-load-balancer)
      4. [`Load Balancing Algorithms`](./hld/appendix/1-load-balancer.md#load-balancing-algorithms)
         1. [`Round Robin`](./hld/appendix/1-load-balancer.md#round-robin---the-simplest)
         2. [`Least Connections`](./hld/appendix/1-load-balancer.md#least-connections)
         3. [`Weighted Round Robins`](./hld/appendix/1-load-balancer.md#weighted-round-robin)
         4. [`Weighted least Connections`](./hld/appendix/1-load-balancer.md#weighted-least-connections)
         5. [`IP hasing`](./hld/appendix/1-load-balancer.md#ip-hashing)
         6. [`Least Response Time`](./hld/appendix/1-load-balancer.md#least-response-time)
         7. [`Custom Load`](./hld/appendix/1-load-balancer.md#custom-load)
         8. [`Random`](./hld/appendix/1-load-balancer.md#random)
         9. [`Least Bandwidth`](./hld/appendix/1-load-balancer.md#least-bandwidth)
   2. [`Distributed Systems`](./hld/appendix/3-distributed-systems.md)
   3. [`Polling Web Sockets & Server Sent Events`](./hld/appendix/15-polling-websockets-serverevents.md)
   4. [`Heart Beat`](./hld/appendix/17-heartbeat.md)
   5. [`Consistent Hashing`](./hld/appendix/consistent-hashing.md)
   6. [`Data Partitioning`](./hld/appendix/data-partitioning.md)
   7. [`Encoding`](./hld/appendix/encoding.md)

## `HLD Designs` 

1. [`URL Shortener`](./hld/url-shortner.md)
2. [`Netflix`](./hld/netflix/netflix-arch-review.md)
3. [`Trading System`](./hld/trading-system/index.md)
4. [`Fantasy Sports`](./hld/fantasy-sports/scaling@dream11.md)

# [`Microservices`](./microservices/)
1. [`Breaking Monolith`](./microservices/0-breaking-monolith.md)
<br/>

1. **[`Microservices Index`](./microservices/index.md)**
      1. [`Categories of Microservices Patterns`](./microservices/index.md#category-0f-microservices-patterns)
      2. [`Mind Map`](./microservices/index.md#mind-map-microservice-patterns)
      3. [`Data Management Patterns`](./microservices/index.md#data-management-patterns)
      4. [`Design & Implementation Patterns`](./microservices/index.md#design--implementation-pattern)
      5. [`Messaging Patterns`](./microservices/index.md#messaging-patterns)
      6. [`Catalog of microservices Patterns`](./microservices/index.md#catalog-0f-microservices-patterns)
<br/>

1. **[`Mind Mapping Microservices Patterns Part 1`](./microservices/0-microservices-concerns-pt1.md)**
   1. [`How to decompose the application into microservices`](./microservices/0-microservices-concerns-pt1.md#how-to-decompose-the-application-into-microservices)
   2. [`Decomposition Design Pattern`](./microservices/0-microservices-concerns-pt1.md#decomposition-design-pattern)
   3. [`Database Architecture`](./microservices/0-microservices-concerns-pt1.md#database-architecture)
   4. [`Data Consistency Pattern`](./microservices/0-microservices-concerns-pt1.md#data-consistency-pattern)
   5. [`Data Querying Pattern`](./microservices/0-microservices-concerns-pt1.md#data-querying-patterns)
   6. [`Service Deployments`](./microservices/0-microservices-concerns-pt1.md#service-deployment)
   7. [`Accessing API Clients`](./microservices/0-microservices-concerns-pt1.md#accessing-api-clients)
   8. [`Microservices Communication`](./microservices/0-microservices-concerns-pt1.md#how-services-communicate-with-each-other)
<br/>

1. **[`Mind Mapping Microservices Pattern Part 2`](./microservices/0-microservices-concerns-pt2.md)**
   1. [`Non Functional Requirements`](./microservices/0-microservices-concerns-pt2.md#what-is-happening-within-services)
   2. [`Are service behaving well`](./microservices/0-microservices-concerns-pt2.md#are-services-behaving-well)
   3. [`Resilience`](./microservices/0-microservices-concerns-pt2.md#how-to-make-services-more-resilient)
<br/>

1. **[`Orchestration vs Choreography`](./microservices/0-orchestration-vs-choreography.md)**
   1. [`Orchestration`](./microservices/0-orchestration-vs-choreography.md#orchestration)
   2. [`Choreography`](./microservices/0-orchestration-vs-choreography.md#choreography)
<br/>

### [`DDD`](./microservices/ddd/0-getting-started.md)
### [`Hexagonal Architecture`](./microservices/hexagonal/0-introduction.md)


### Pattern

1. [`Circuit Breaker`](./microservices/circuit-breaker/index.md)
   1. [`Performance & Special Considerations`](./microservices/circuit-breaker/special-considerations.md)
2. [`CQRS`](./microservices/cqrs/index.md)
   1. [`Architecture`](./microservices/cqrs/1-architecture.md)
   2. [`Inner Working`](./microservices/cqrs/2-inner-working.md)
   3. [`Performance & Special Consideration`](./microservices/cqrs/3-special-considerations.md)
3. [`Event Driven`](./microservices/event-driven/)
   1. [`Introduction`](./microservices/event-driven/index.md)
   2. [`Architecture`](./microservices/event-driven/1-architecture.md)
   3. [`Performance & Special Considerations`](./microservices/event-driven/2-special-consideration.md)
   4. [`Use Cases`](./microservices/event-driven/3-use-cases.md)
   5. [`Handling Failures`](./microservices/event-driven/4-handling-failure.md)

# [`Design Patterns`](./design-patterns/)
1. [`Overview`](./design-patterns/0-design-pattern-overview.md)
2. [`Last min revision notes`](./design-patterns/last-min-revision-all-desgin-pattern.pdf)
3. [`Source Code`](./design-patterns/src/)
4. [`Behavioral`](./design-patterns/behavioural/)
   1. [`Strategy`](./design-patterns/behavioural/strategy.md)
5. [`Creational`](./design-patterns/creational/)
   1. [`Builder`](./design-patterns/creational/builder.md)
   2. [`Singleton`](./design-patterns/creational/singleton.md)
6. [`Structural`](./design-patterns/structural/)
   1. [`Adapter`](./design-patterns/structural/adapter.md)
   2. [`Decorator`](./design-patterns/structural/decorator.md)