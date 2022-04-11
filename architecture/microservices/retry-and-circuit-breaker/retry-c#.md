  # Retry Pattern in C#
  * External services may not be available at all times due to various reasons. 
  * So for all outbound calls we need to have a retry mechanism before throwing exceptions. 
  * We shouldn't retry everything and not retry 100s of time
  * 

### Important Considerations 
* Retry logic should not obscure the actual application logic making code harder to understand later.
* Retry logic is probably a cross cutting concern and should be centralized. Avoid duplicating that retry looping code.
* You may want to be able to configure the retry behavior without recompilation. As under load, we **disable retry and fail fast** 
* Use it with care, badly implemented or miss-configured and it can add even more load to a failing system.

## Simple synchronous retry helper 
See [SynchronousRetryHelper.cs](./SynchronousRetryHelper.cs)

## Asynchronous Retry Helper 
* Whenever you have an async method or a method that returns a task you must capture the returned task and await it. **Go Async All The Way Down** and avoid any calls to **Task.Wait() or Task.WaitAll()**

### Solution Considerations 
* Return a Task so that the caller can await the RetryHelper to complete or fail.
* Await the async lambda so the result or exception is passed back properly.
* Add a generics overload to allow callers to only retry a particular type of exception. (This could also be applied to the synchronous version).

* See [AsyncRetryHelper.cs](./AsyncRetryHelper.cs)

## Implementing Retry with Polly 
> **ABOUT POLLY** it is open source framework that allows developers to express **transient exception and fault handling policies such as Retry, Retry Forever, Wait and Retry, or Circuit Breaker** in a fluent manner
* Created by **[Micheal Woldenden](https://github.com/michael-wolfenden)**
  ````
  var httpClient = new HttpClient();
  var maxRetryAttempts = 3;
  var pauseBetweenFailures = TimeSpan.FromSeconds(2);

  var retryPolicy = Policy
      .Handle<HttpRequestException>()
      .WaitAndRetryAsync(maxRetryAttempts, i => pauseBetweenFailures);

  await retryPolicy.ExecuteAsync(async () =>
  {
      var response = await httpClient
        .DeleteAsync("https://example.com/api/products/1");
      response.EnsureSuccessStatusCode();
  });
  ````
* It takes async lambda containing the delegate to be retried

### Implementing Exponential Back-off 
* With this retry policy the delays between attempts increase with the number of failures. 
  ```
  Policy
  .Handle<HttpRequestException>()
  .WaitAndRetryAsync(new[]
  {
    TimeSpan.FromSeconds(2),
    TimeSpan.FromSeconds(4),
    TimeSpan.FromSeconds(8)
  });
  ```

### Calculating delay at runtime 
  ```
  Policy
  .Handle<HttpRequestException>()
  .WaitAndRetryAsync(3, retryAttempt => 
    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) 
  );
  ```

> **NOTE** if you use the `Policy.ExecuteAsync` asynchronous execution API, you must use the `WaitAndRetryAsync` policy creation method and not the `WaitAndRetry` variant. Vice versa, if you use the non async `Execute` version you have to use the corresponding non async `WaitAndRetry` fluent policy builder.