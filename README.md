# Index 
0. [`Agile Story Splitting Workflow`](./agile/Story-Splitting-Flowchart.pdf)
   
# [`System Design`](./system-design/)
## [`Microservices`](./system-design/microservices/)
1. **[`Microservices Index`](./system-design/microservices/index.md)**
      1. [`Categories of Microservices Patterns`](./system-design/microservices/index.md#category-0f-microservices-patterns)
      2. [`Mind Map`](./system-design/microservices/index.md#mind-map-microservice-patterns)
      3. [`Data Management Patterns`](./system-design/microservices/index.md#data-management-patterns)
      4. [`Design & Implementation Patterns`](./system-design/microservices/index.md#design--implementation-pattern)
      5. [`Messaging Patterns`](./system-design/microservices/index.md#messaging-patterns)
      6. [`Catalog of microservices Patterns`](./system-design/microservices/index.md#catalog-0f-microservices-patterns)
<br/>

1. **[`Mind Mapping Microservices Patterns Part 1`](./system-design/microservices/0-microservices-concerns-pt1.md)**
   1. [`How to decompose the application into microservices`](./system-design/microservices/0-microservices-concerns-pt1.md#how-to-decompose-the-application-into-microservices)
   2. [`Decomposition Design Pattern`](./system-design/microservices/0-microservices-concerns-pt1.md#decomposition-design-pattern)
   3. [`Database Architecture`](./system-design/microservices/0-microservices-concerns-pt1.md#database-architecture)
   4. [`Data Consistency Pattern`](./system-design/microservices/0-microservices-concerns-pt1.md#data-consistency-pattern)
   5. [`Data Querying Pattern`](./system-design/microservices/0-microservices-concerns-pt1.md#data-querying-patterns)
   6. [`Service Deployments`](./system-design/microservices/0-microservices-concerns-pt1.md#service-deployment)
   7. [`Accessing API Clients`](./system-design/microservices/0-microservices-concerns-pt1.md#accessing-api-clients)
   8. [`Microservices Communication`](./system-design/microservices/0-microservices-concerns-pt1.md#how-services-communicate-with-each-other)
<br/>

1. **[`Mind Mapping Microservices Pattern Part 2`](./system-design/microservices/0-microservices-concerns-pt2.md)**
   1. [`Non Functional Requirements`](./system-design/microservices/0-microservices-concerns-pt2.md#what-is-happening-within-services)
   2. [`Are service behaving well`](./system-design/microservices/0-microservices-concerns-pt2.md#are-services-behaving-well)
   3. [`Resilience`](./system-design/microservices/0-microservices-concerns-pt2.md#how-to-make-services-more-resilient)
<br/>

1. **[`Orchestration vs Choreography`](./system-design/microservices/0-orchestration-vs-choreography.md)**
   1. [`Orchestration`](./system-design/microservices/0-orchestration-vs-choreography.md#orchestration)
   2. [`Choreography`](./system-design/microservices/0-orchestration-vs-choreography.md#choreography)
<br/>
 
1. **[`Strangler Fig Pattern`](./system-design/microservices/1-strangler-fig-pattern.md)**
<br/>

## [`SOLID`](./system-design/solid/)
1. [`Single Responsibility`](./system-design/solid/index.md#s-single-responsibility-principle)
2. [`Open Closed Principle`](./system-design/solid/index.md#o-open-closed-principle)
3. [`Liskov Substitution`](./system-design/solid/index.md#l-liskov-substitution-principle)
   1. [`LSP In Depth`](./system-design/solid/LSP.md)
4. [`Interface Segregation`](./system-design/solid/index.md#i-interface-segregation-principle)
5. [`Dependency Inversion`](./system-design/solid/index.md#d---dependency-inversion-principle)
6. [`Dependency Injection vs Inversion of Control`](./system-design/solid/di-ioc-di.md)
7. [`Documentation`](./system-design/solid/SOLID.docx)
<br/>

## [`High Level System Design`](./system-design/hld/)
0. [`General Tips`](./system-design/hld/0_general_tips.md)
1. [`Appendix`](./high-level-design/appendix/)
   1. **[`Load Balancers`](./high-level-design/appendix/1-load-balancer.md)**
      1. [`Terminologies`](./high-level-design/appendix/1-load-balancer.md#terminologies)
      2. [`How Load Balancer Words`](./high-level-design/appendix/1-load-balancer.md#how-load-balancers-works)
      3. [`Uses`](./high-level-design/appendix/1-load-balancer.md#uses-of-load-balancer)
      4. [`Load Balancing Algorithms`](./high-level-design/appendix/1-load-balancer.md#load-balancing-algorithms)
         1. [`Round Robin`](./high-level-design/appendix/1-load-balancer.md#round-robin---the-simplest)
         2. [`Least Connections`](./high-level-design/appendix/1-load-balancer.md#least-connections)
         3. [`Weighted Round Robins`](./high-level-design/appendix/1-load-balancer.md#weighted-round-robin)
         4. [`Weighted least Connections`](./high-level-design/appendix/1-load-balancer.md#weighted-least-connections)
         5. [`IP hasing`](./high-level-design/appendix/1-load-balancer.md#ip-hashing)
         6. [`Least Response Time`](./high-level-design/appendix/1-load-balancer.md#least-response-time)
         7. [`Custom Load`](./high-level-design/appendix/1-load-balancer.md#custom-load)
         8. [`Random`](./high-level-design/appendix/1-load-balancer.md#random)
         9. [`Least Bandwidth`](./high-level-design/appendix/1-load-balancer.md#least-bandwidth)
<br/>

## [`Low Level Design`](./system-design/lld/)
1. [`Appendix`](./system-design/lld/)
   1. [`Object Oriented Basic`](./system-design/lld/1-OO-basics.md)
   2. [`Object Oriented Design & Analysis`](./system-design/lld/2-OO-design-and-analysis.md)
   3. [`UML`](./system-design/lld/3-UML.md)
   4. [`Use Case Diagram`](./system-design/lld/4-use-case-diagram.md)
   5. [`Class Diagram`](./system-design/lld/5-class-diagram.md)
   6. [`Sequence Diagram`](./system-design/lld/6-sequence-diagram.md)
   7. [`Activity Diagram`](./system-design/lld/7-activity-diagrams.md)
2. **[`Hotel Management System Design`](./system-design/lld/hotel-management/index.md)**
<br/>

## `Useful System Design Links`
[`High Scalability(Learn System Design)`](http://highscalability.com/)
[`Designing Data Intensive Application Book`](https://www.oreilly.com/library/view/designing-data-intensive-applications/9781491903063/)
[``OOD``](https://akshay-iyangar.github.io/system-design/)
[``SD``](https://github.com/Jeevan-kumar-Raj/Grokking-System-Design)

# DSA Theory
## Algorithms
1. [`Sorting`](./data-structure-algo/algorithm/sorting/main.md)
   1. [`Bubble Sort`](./data-structure-algo/algorithm/sorting/bubble-sort.md)
   2. [`Insertion Sort`](./data-structure-algo/algorithm/sorting/insertion-sort.md)
   3. [`Merge Sort`](./data-structure-algo/algorithm/sorting/merge-sort.md)
   4. [`Quick Sort`](./data-structure-algo/algorithm/sorting/quick-sort.md)
   5. [`Recursive Bubble Sort`](./data-structure-algo/algorithm/sorting/recursive-bubble-sort.md)
   6. [`Section Sort`](./data-structure-algo/algorithm/sorting/selection-sort.md)
2. [`Searching`](./data-structure-algo/algorithm/searching/main.md)
   1. [`Binary Search`](./data-structure-algo/algorithm/searching/binary-search.md)
   2. [`Exponential Search`](./data-structure-algo/algorithm/searching/exponential-search.md)
   3. [`Fibonacci Search`](./data-structure-algo/algorithm/searching/fibonacci-search.md)
   4. [`Interpolation Search`](./data-structure-algo/algorithm/searching/interpolation-search.md)
   5. [`Jump Search`](./data-structure-algo/algorithm/searching/jump-search.md)
   6. [`Sub List Search`](./data-structure-algo/algorithm/searching/sublist-search.md)
## Data Structure
1. [`Singly Linked List`](./data-structure-algo/data-structure/singly-linked-list.md)
2. [`Doubly Linked List`](./data-structure-algo/data-structure/doubly-linked-list.md)
3. [`LRU Cache`](./data-structure-algo/data-structure/lru-cache.md)
4. [`LFU Cache`](./data-structure-algo/data-structure/lfu-cache.md)
5. [`Binary Heap`](./data-structure-algo/data-structure/binary-heap.md)


# DSA Problem Solved
1. Array 
   1. [`Basic`](./data-structure-algo/src/arrays/basic.dib)
      1. [`Left Circular Rotation`](./data-structure-algo/src/arrays/basic.dib)
      2. [`Right Circular Rotation`]
      3. [`Target Two Sum`]
      4. [`Convert 1D Array to 2D Array`]
      5. [`Reverse`]
      6. [`Find Second Largest`]
      7. [`Merge Sorted Array`]
      8. [`Get Unique Elements`]
      9. [`Get Max & Min`]
2. Numbers
   1. [`Basic`](./data-structure-algo/src/numbers/basic.dib)
      1. [`Check Of Prime`](./data-structure-algo/src/numbers/basic.dib)
      2. [`Sum Of Digits`](./data-structure-algo/src/numbers/basic.dib)
      3. [`Find Angle in time`](./data-structure-algo/src/numbers/basic.dib)
      4. [`Find Nth Fibonaci`](./data-structure-algo/src/numbers/basic.dib)
      5. [`Reverse`](./data-structure-algo/src/numbers/basic.dib)
      6. [`Find missing numbers`](./data-structure-algo/src/numbers/basic.dib)
      7. [`Factors`](./data-structure-algo/src/numbers/basic.dib)
      8. [`Power`](./data-structure-algo/src/numbers/basic.dib)
      9. [`GCD`](./data-structure-algo/src/numbers/basic.dib)
      10. [`Palindrome`](./data-structure-algo/src/numbers/basic.dib)
      11. [`Check Arm strong number`](./data-structure-algo/src/numbers/basic.dib)

# Grokking Patterns for System Design 
1. [`Warmup`](./dsa/grokking-interview-patterns/0-warmup.md)
   1. [`Contains Duplicate`](./dsa/grokking-interview-patterns/0-warmup.md#problem-1-contains-duplicate)
   2. [`Pangram`](./dsa/grokking-interview-patterns/0-warmup.md#problem-2-pangram)
   3. [`Reverse Vowels`](./dsa/grokking-interview-patterns/0-warmup.md#problem-3-reverse-vowels)
   4. [`Check Palindrome`](./dsa/grokking-interview-patterns/0-warmup.md#problem-4-check-palindrome)
   5. [`Check Anagram`](./dsa/grokking-interview-patterns/0-warmup.md#problem-5-check-anagram)
   6. [`Shortest Word Distance`](./dsa/grokking-interview-patterns/0-warmup.md#problem-6-shortest-word-distance)
   7. [`Good Pairs`](./dsa/grokking-interview-patterns/0-warmup.md#problem-7-good-pairs)
   
2. [`Two Pointers`](./dsa/grokking-interview-patterns/1-two-pointers.md)
   1. [`Target Sum Two Numbers`](./dsa/grokking-interview-patterns/1-two-pointers.md#target-sum)
   2. [`Find Non Duplicate instances`](./dsa/grokking-interview-patterns/1-two-pointers.md#find-non-duplicate-instances)
   3. [`Squaring Sorted Array`](./dsa/grokking-interview-patterns/1-two-pointers.md#squaring-sorted-array)
   4. [`Triplet Sum to Zero`](./dsa/grokking-interview-patterns/1-two-pointers.md#triplet-sum-to-zero)
   5. [`Triplet Sum close to target`](./dsa/grokking-interview-patterns/1-two-pointers.md#triplet-sum-closed-to-target)
   6. [`Triplet with smallest Sum`](./dsa/grokking-interview-patterns/1-two-pointers.md#triplets-with-smallest-sum)