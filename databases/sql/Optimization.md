# Optimization

* The main aim is to 
  * find a way to decrease the response time of the query, 
  * prevent the excessive consumption of resources, and 
  * identify poor query performance.
* Monitoring metrics can be used to evaluate query runtime, detect performance pitfalls, and show how they can be improved. 
  * **Query Execution Plan**: A SQL Server query optimizer executes the query step by step, scans indexes to retrieve data, and provides a detailed overview of metrics during query execution.
  * **Input/Output statistics**: Used to identify the number of logical and physical reading operations during the query execution that helps users detect cache/memory capacity issues.
  * **Buffer cache**: Used to reduce memory usage on the server.
  * **Latency**: Used to analyze the duration of queries or operations.
  * **Indexes**: Used to accelerate reading operations on the SQL Server.
  * **Memory-optimized tables**: Used to store table data in memory to make reading and writing operations run faster.

## TIP 1: Add Missing Index
* In SQL Server the profiler, If it detects the missing index that may be created to optimize performance, the execution plan suggests this in the warning section
* Nested Loops must be indexed, as they take the first value from the first table and search for a match in the second table.

## Tip 2: Check for un-used index
* In case of implicit conversion of data while filtering the indexes are not used. 
* Like in this query: `SELECT * FROM TestTable WHERE IntColumn = '1';` 
* We can avoid this using explicit case `Cast()` function
* `SELECT * FROM TestTable WHERE IntColumn = CAST(@char AS INT);`

## Tip 3: Avoid using multiple OR in filter predicate
* When you need to combine two or more conditions, it is recommended to eliminate the usage of the OR operator or split the query into parts separating search expressions
* SQL Server can not process OR within one operation. Instead, it evaluates each component of the OR which, in turn, may lead to poor performance.
* Like the query : `SELECT * FROM USER WHERE Name = @P OR login = @P;`
* This can be changed using Using `SELECT * FROM USER WHERE Name = @P UNION SELECT * FROM USER WHERE login = @P;`

## TIP 4: Use wildcards at the end of a phrase only

## TIP 5: Avoid too many JOINS

## TIP 6: Avoid using Select Distinct
* As it has large volume of data the query has to work with

## TIP 7: Use Select <columns> instead of Select * 

## TIP 8: Restrict the number of records fetched by using Select TOP
