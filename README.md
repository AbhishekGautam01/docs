# Index 
1. [`Agile`](./README.md#agile)
2. [`Database`](./README.md#database)
   1. [`SQL vs NoSQL`](./README.md#database)
   2. [`SQL`](./README.md#sql)
   3. [`Mongo DB`](./README.md#mongo-db)
   4. [`Cosmos DB`](./README.md#cosmos-db)
3. [`System Design`](./README.md#system-design)
   1. [`Microservices`](./README.md#microservices)
   2. [`SOLID`](./README.md#solid)
   3. [`High Level Design`](./README.md#high-level-system-design)
   4. [`Low Level Design`](./README.md#low-level-design)
4. [`Testing`](./README.md#testing)
   1. [`Postman API Automation Testing`](./README.md#postman-api-automation-testing)
<br/>

# Agile
1. [`Agile Story Splitting Workflow`](./agile/Story-Splitting-Flowchart.pdf)

# [`Database`](./databases/)
1. **[`Data Storage on all cloud platforms`](./databases/sql-vs-nosql-on-all-cloud.jpeg)**
2. **[`SQL vs NoSQL`](./databases/nosql-vs-sql/main.md)**
## [`SQL`](./databases/sql/)
   0. [`Index`](./databases/sql/main.md#index)
      1. [`History of Data`](./databases/sql/main.md#history-of-data)
      2. [`Types of Data`](./databases/sql/main.md#types-of-database)
      3. [`SQL Fundamentals`](./databases/sql/main.md#sql-fundamentals)
      4. [`Relational Models`](./databases/sql/main.md#relational-model)
      5. [`OTLP vs OLAP`](./databases/sql/main.md#otlp-vs-olap)
      6. [`Command Classification`](./databases/sql/main.md#commands-classification)
   1. [`CAP Theorem`](./databases/sql/0.1.CAP.md)
   2. [`ACID Transactions`](./databases/sql/0.ACID.md)
   3. [`DDL Operations`](./databases/sql/1.DDL.md)
   4. [`DML Operations`](./databases/sql/2.DML.md)
   5.  [`Tables`](./databases/sql/Tables.md)
   6. [`Constraints`](./databases/sql/Constraints.md)
   7.  [`Keys`](./databases/sql/Keys.md)
   8.  [`Joins`](./databases/sql/Joins.md)
   9.  [`Sub Query`](./databases/sql/SubQuery.md)
   10. [`Union`](./databases/sql/Union.md)
   11. [`Built In Functions`](./databases/sql/Built-In%20Function.md)
   12. [`CTE - Common Table Expressions`](./databases/sql/CTE.md)
   13. [`Views`](./databases/sql/Views.md)
   14. [`Indexing`](./databases/sql/Indexing.md)
   15. [`Locking`](./databases/sql/Locking.md)
   16. [`Partitioning`](./databases/sql/Partitioning.md)
   17. [`Ranking`](./databases/sql/Ranking.md)
   18. [`Sample-Queries-Examples`](./databases/sql/sample-queries.md)
   19. [`Seeding Database Script`](./databases/sql/seed-db-script.sql)
   20. [`Sharding`](./databases/sql/Sharding.md)
<br/>

## [`Mongo DB`](./databases/mongo-db/)
<br/>

## [`Cosmos DB`](./databases/cosmos-db/)
1. **[`Walkthrough`](./databases/cosmos-db/1-walkthrough.md)**
   1. [`Categories of NoSQL Databases`](./databases/cosmos-db/1-walkthrough.md#categories-of-nosql-databases)
   2. [`CosmosDb Features`](./databases/cosmos-db/1-walkthrough.md#azure-cosmos-db-features)
   3. [`Multi API & Multi Model`](./databases/cosmos-db/1-walkthrough.md#multi-model--multi-apis)
   4. [`5 Well Defined Consistency Levels`](./databases/cosmos-db/1-walkthrough.md#5-well-defined-consistency-levels)
   5. [`Resource Hierarchy`](./databases/cosmos-db/1-walkthrough.md#resource-hierarchy)
   6. [`RUs`](./databases/cosmos-db/1-walkthrough.md#request-unitsrus)
   7. [`Database Partitioning`](./databases/cosmos-db/1-walkthrough.md#database-partitioning)
2. **[`Database Setup`](./databases/cosmos-db/2-SetUp.md)**
3. **[`Schema Design Strategies`](./databases/cosmos-db/3-Schema_Design-Strategies.md)**
4. **[`Real World Data Modeling Example`](./databases/cosmos-db/4-real-world-example.md)**


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
0. [`General Tips`](./system-design/system-design/hld/0_general_tips.md)
1. [`Appendix`](./system-design/high-level-design/appendix/)
   1. **[`Load Balancers`](./system-design/high-level-design/appendix/1-load-balancer.md)**
      1. [`Terminologies`](./system-design/high-level-design/appendix/1-load-balancer.md#terminologies)
      2. [`How Load Balancer Words`](./system-design/high-level-design/appendix/1-load-balancer.md#how-load-balancers-works)
      3. [`Uses`](./system-design/high-level-design/appendix/1-load-balancer.md#uses-of-load-balancer)
      4. [`Load Balancing Algorithms`](./system-design/high-level-design/appendix/1-load-balancer.md#load-balancing-algorithms)
         1. [`Round Robin`](./system-design/high-level-design/appendix/1-load-balancer.md#round-robin---the-simplest)
         2. [`Least Connections`](./system-design/high-level-design/appendix/1-load-balancer.md#least-connections)
         3. [`Weighted Round Robins`](./system-design/high-level-design/appendix/1-load-balancer.md#weighted-round-robin)
         4. [`Weighted least Connections`](./system-design/high-level-design/appendix/1-load-balancer.md#weighted-least-connections)
         5. [`IP hasing`](./system-design/high-level-design/appendix/1-load-balancer.md#ip-hashing)
         6. [`Least Response Time`](./system-design/high-level-design/appendix/1-load-balancer.md#least-response-time)
         7. [`Custom Load`](./system-design/high-level-design/appendix/1-load-balancer.md#custom-load)
         8. [`Random`](./system-design/high-level-design/appendix/1-load-balancer.md#random)
         9. [`Least Bandwidth`](./system-design/high-level-design/appendix/1-load-balancer.md#least-bandwidth)
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


# [`Testing`](./testing/)
## [`Postman API Automation Testing`](./testing/postman/Index.md)
1. [`Overview.md`](./testing/postman/testing/postman/doc/0-overiview.md)
    1. [`API - Application Programming Interface`](./testing/postman/testing/postman/doc/0-overiview.md#API--Application-Programming-Interface)
    2. [`First API Call using Postman`](./testing/postman/testing/postman/doc/0-overiview.md#First-API-Call-using-Postman)
    3. [`Most common issues with Postman`](./testing/postman/testing/postman/doc/0-overiview.md#Most-common-issues-with-Postman)
    4. [`Postman web`](./testing/postman/testing/postman/doc/0-overiview.md#Postman-web)
    5. [`Http`](./testing/postman/testing/postman/doc/0-overiview.md#Http)
    6. [`Postman Landscape`](./testing/postman/testing/postman/doc/0-overiview.md#Postman-Landscape)
    <br/>
2. [`Creating REST API requests with Postman`](./testing/postman/testing/postman/doc/1-rest-request-with-postman.md)
    1. [`Storing Configuration in Variables`](./testing/postman/testing/postman/doc/1-rest-request-with-postman.md#Storing-Configuration-in-Variables)
    1. [`Modifying Collection variables`](./testing/postman/testing/postman/doc/1-rest-request-with-postman.md#Modifying-Collection-variables)
    1. [`Get Request`](./testing/postman/testing/postman/doc/1-rest-request-with-postman.md#Get-Request)
    1. [`Visualizing Response`](./testing/postman/testing/postman/doc/1-rest-request-with-postman.md#Visualizing-Response)
    1. [`Query Parameter`](./testing/postman/testing/postman/doc/1-rest-request-with-postman.md#Query-Parameter)
    1. [`Shortcuts`](./testing/postman/testing/postman/doc/1-rest-request-with-postman.md#Shortcuts)
    1. [`Path Variables`](./testing/postman/testing/postman/doc/1-rest-request-with-postman.md#Path-Variables)
    1. [`Post`](./testing/postman/doc/1-rest-request-with-postman.md#Post)
    1. [`GET vs POST`](./testing/postman/doc/1-rest-request-with-postman.md#GET-vs-POST)
    1. [`API Authentication`](./testing/postman/doc/1-rest-request-with-postman.md#API-Authentication)
    1. [`Using Random data in request`](./testing/postman/doc/1-rest-request-with-postman.md#Using-Random-data-in-request)
    1. [`Http Headers`](./testing/postman/doc/1-rest-request-with-postman.md#Http-Headers)
    1. [`Headers vs query param vs path param`](./testing/postman/doc/1-rest-request-with-postman.md#Headers-vs-query-param-vs-path-param)
    1. [`Sharing postman collection`](./testing/postman/doc/1-rest-request-with-postman.md#Sharing-postman-collection)
    1. [`Patch Request`](./testing/postman/doc/1-rest-request-with-postman.md#Patch-Request)
    1. [`HEAD Request Message`](./testing/postman/doc/1-rest-request-with-postman.md#HEAD-Request-Message)
    <br/>

3. **[`Trello API Testing`](./testing/postman/doc/2-trello-api.md)**
<br/>

4. **[`API Test Scripts`](./testing/postman/doc/3-test-scripts.md)**
<br/>

5. **[`Test Scripts with Variables & Variables Scopes`](./testing/postman/doc/4-test-scripts-with-variables.md)**
    1. [`Types of Variables`](./testing/postman/doc/4-test-scripts-with-variables.md#Types-of-Variables)
    1. [`Accessing variables in the scripts`](./testing/postman/doc/4-test-scripts-with-variables.md#Accessing-variables-in-the-scripts)
    1. [`Global Variables`](./testing/postman/doc/4-test-scripts-with-variables.md#Global-Variables)
    1. [`Environment Variables`](./testing/postman/doc/4-test-scripts-with-variables.md#Environment-Variables)
    1. [`Pre-request scripts`](./testing/postman/doc/4-test-scripts-with-variables.md#Pre-request-scripts)
    1. [`Variables types`](./testing/postman/doc/4-test-scripts-with-variables.md#Variables---types)
    1. [`Setup different URL to test against different environments`](./testing/postman/doc/4-test-scripts-with-variables.md#Setup-different-URL-to-test-against-different-environments)
    1. [`Debugging tests`](./testing/postman/doc/4-test-scripts-with-variables.md#Debugging-tests)
<br/>

6. [`Advance Assertions`](./testing/postman/doc/5-advance-assertions.md)
    1. [`Chai Assertion Library`](./testing/postman/doc/5-advance-assertions.md#chai-assertion-library)
    1. [`Assertions`](./testing/postman/doc/5-advance-assertions.md#assertions)
    1. [`Assertions on Array`](./testing/postman/doc/5-advance-assertions.md#assertions-on-array)
    1. [`Assertions on nested objects`](./testing/postman/doc/5-advance-assertions.md#assertions-on-nested-objects)
    1. [`Testing Headers & Cookies`](./testing/postman/doc/5-advance-assertions.md#testing-headers--cookies)
<br/>

7. [`Automatically running tests`](./testing/postman/doc/6-automatically-running-tests.md)
    1. [`Postman Collection runner`](./testing/postman/doc/6-automatically-running-tests.md#postman-collection-runner)
    1. [`Postman Monitor`](./testing/postman/doc/6-automatically-running-tests.md#postman-monitor)
    1. [`Automating with Newman`](./testing/postman/doc/6-automatically-running-tests.md#automating-with-newman)
        1. [`Installing new man`](./testing/postman/doc/6-automatically-running-tests.md#installing-new-man)
        1. [`Running a collection in postman`](./testing/postman/doc/6-automatically-running-tests.md#running-a-collection-in-postman)
        1. [`Accessing collections from newman`](./testing/postman/doc/6-automatically-running-tests.md#accessing-collections-from-newman)
        1. [`Specifying environments with newman`](./testing/postman/doc/6-automatically-running-tests.md#specifying-environments-with-newman)
        1. [`Generating Html reports from newman`](./testing/postman/doc/6-automatically-running-tests.md#generating-html-reports-from-newman)
<br/>

8. [`Workflows and scenarios`](./testing/postman/doc/8-workflows-and-scenarios.md)
    1. [`Multiple worksflows within same collection : https://www.youtube.com/watch?v=FWYKOR0Zj28`](./testing/postman/doc/8-workflows-and-scenarios.md#multiple-worksflows-within-same-collection--httpswwwyoutubecomwatchvfwykor0zj28)