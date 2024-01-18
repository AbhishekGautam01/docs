# LINQ Interview Questions

* **LINQ?**
  * linq- Language Integrated Query
  * Provides simple data access and querying from in-memory, databases, objects, XML, documents, etc.

* **Different Methods to write LINQ?**
  * Expression Syntax or Query Syntax
  * Method Extension Syntax 
<br/>

* **For vs ForEach loop performance comparison**
  
| FOR | FOREACH |
| :---: | :---: |
| For has constant memory overhead, as it requires memory for only loop variable | For each has higher memory requirement due to an enumerator object to iterate over collections | 
| Allows more control over loop conditions | | 
| It is more efficient when dealing with index based access | It is less performant than for loop in some scenarios where indexed based access is considered | 
| For arrays for loop is preferred | For generic collection foreach loop | 
| For loop has fine grain control | Foreach loop has code readability | 
|  | Modifying a collection during loop can lead to runtime exception |
<br/>

* **Yeild Keyword and Yield return**
  * Yield keyword is used with return to create an iterator or generator method. 
  * This is useful when we want to generate a sequence of value without generating the entire sequence at once. 
  * When yield return is encounter the method is stopped and value is returned to the caller.
  * **Usage**
    * Lazy Evaluations: yield allows lazy evaluation, generating value whenever needed. 
    * Reduces memory usage
    * readability 
<br/>

* **First(), FirstOrDefault() , Single() or SingleOrDefault**
  * First - Returns 1st element or exception if not found
  * FirstOrDefault - Returns 1st element or null if not found
  * Single - Return 1st element, throws exception is no or more than one matching element found
  * SingleOrDefault - Returns the single matching element, if no matching element found then default value is returned, if more than 1 matching element found then exception.
<br/>

* **Anonymous Function**
  * Function which does not have any name. 
  ```csharp
  delegate int func(int a, int b);

  func f1 = delegate(int a, int b){
    return a + b;
  }
  ```
<br/>

* **Deffered vs Lazy**
  * Lazy - Don't work until you have to 
  * Deferred - don't compute result until user wants it
<br/>

* **What are compiled queries?**
  * Queries that are pre compiled and cached. 
  * This is good for queries which run frequently. 
  * These save the query compilation time
    ```csharp
    private static readonly Func<MyDbContext, int, IQueryable<User>> compiledQuery =
        CompiledQuery.Compile((MyDbContext context, int userId) =>
            from user in context.Users
            where user.UserId == userId
            select user);
    ```
<br/>

* Skip - Skips n elements
* skipWHile - skips element untill condition is meant
* First - returns first element
* Take(1) - returns a sequence of elements containing 1 element
* SelectMany - flattens the query which return list of list

<br/>

* **IEnumerable vs IList**
  * IList inherits from IEnumerable . Both have differed execution means query will not give result until looped.
  * IEnumerable is read-only where as IList is read/write
  * IEnumerable needs iteration to return number of element
  * IList has readonly property of count so without iteration we can get the count. 
* **IEnumerable vs List**
  * List is entire collection in memory
  * IEnumerable gets one element at a time using the enumerator. 
  * List executes the query as soon as it is called where as IEnumerable defers the query execution until data is access.
  * IEnumerable is better when we want to loop once, List is better when we want to loop multiple times
* **IQueryable vs IEnumerable**
  * IQueryable comes from System.LINQ and is suitable for querying data out of memory objects(like remote database)
  * IEnumerable is good for in memory database.
  * IQueryable runs filter on server side and IEnumerable runs filters on code side.
  * Both support deferred execution but IQueryable also supports lazy loading suitable for pagination
  * 