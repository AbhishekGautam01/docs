# .NET Core

1. **.Net Core vs .Net Framework**
   * .Net Core: Open source, cross platform for cloud based and microservices apps
   * .Net Framework - Windows only
   * .Net Core provides common run times, libraries and tools used to build, debug and deploy apps to any OS
   * .net core comes with platform agnostic runtime. 
<br/>

2. **.Net Core Dependency Injection**
   * This is handled by built In DI Container. Container can register and resolve dependencies.
   * 3rd party DI tools can be configured like Ninject
   * Way to register Dependencies:
     * In Startup `configureServices` method
     * Attributes on Classes & Properties
     * Using ServiceProvider
   * Accessing Dependencies
     * Property Injection
     * Method Injection
        ```csharp
        public void ProcessData(IDataService dataService)
        {
            Console.WriteLine("Processing data...");
            dataService.GetData();
        }
        ```
     * Constructor Injection
<br/>

3. **What is kestrel and how does it differ from IIS?**
    * Kestrel is a cross-platform, lightweight web server used by default in .Net Core. 
    * It is designed to work with a reverse proxy server such as IIS or Nginx which handles load balancing
    * IIS is a web server specific to windows.
>**Reverse Proxy**: It is a server that sits between client devices and a web server, forwarding client request to the web server and then returning the server's response back to client. Clients are typically not aware of the actual web server, it is also used for load balancing as it distributes load to multiple backend server. 
<br/>

4. **What is purpose of Middlewares?**
   * They are responsible for processing requests and generating responses in the web application pipeline.
   * Handles cross cutting concerns like `authentication, caching, logging, and routing`
   * It is used to define how requests and responses are processed. 
   * Middleware Order 
     * app.UseExceptionHandler()
     * app.UseHsts()
     * app.UseHttpsRedirection()
     * app.UseStaticFiles()
     * app.UseCookiePolicy
     * app.UseRouting
     * app.UseCors()
     * app.UseAuthentication()
     * app.UseAuthorization()
     * app.UseSession()
     * app.UseCustomMiddleware()
     * app.UseEndpoints()
   * `app.Run()`: Executed at the end of pipeline. Generally acts as a terminal middleware and is added at the end of the request pipeline as it cannot call the next middleware
   * `app.Use()`: This is used to configure multiple middlewares. We can include the next request delegate in the pipeline `await next()`
   * `shortcircuiting`: By not calling the next() parameter
   * `app.Map()`: Map branches the request pipeline based on matches of the given request path. If the request path starts with given path, the branch is executed.
   * A `Request Delegate`is a function that processes and handles incoming HTTP request. Its the core building block of the request processing pipeline which is essentially a series of middleware components
   * **Custom Middleware**: It is encapsulated in a class and exposed with an extension method. We need to have `InvokeAsync`
    ```csharp
    public class LogURLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogURLMiddleware> _logger;
        public LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LogURLMiddleware>() ??
            throw new ArgumentNullException(nameof(loggerFactory));
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            await this._next(context);
        }
    }
    public static class LogURLMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogURLMiddleware>();
        }
    }
    ```
<br/>

5. **What is difference between asynchronous and synchronous programming?**
   * Blocks the execution of source code until a task is completed.
   * Async programming allows the execution of code to continue while a task is being processed in the background.
   * Async is for long running operations which would otherwise block the application main's thread.
<br/>

6. **Background work in ASP.NET Core application?**
   * `IHostedService` defined a background task or service as part of app's lifetime.
   * Typically used for monitoring, logging or data processing tasks that must run continuously.
   * These are added using ServiceCollection & started and stopped by app's host.
     * `StartAsync`
     * `StopAsync`
   * They are registered using `services.AddHostedService<MyBackgroundService>();`
   * Code Snippet
    ```csharp
    public class MyBackgroundService : IHostedService, IDisposable
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Background service is starting.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Console.WriteLine("Background task is running...");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Background service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

    ```
<br/>

7. **How does ASP.NET Core handle concurrency and parallelism**
   * **Async Programming**: Async programming using async await . Allows to execute multiple tasks without blocking the main thread.
   * **Parallel Programming**: using Parallel Class and TPL. Allows multiple task to be executed concurrently across multiple processors, improving application's performance. 
    ```csharp
    var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Parallel.ForEach processes each element of the collection concurrently
        Parallel.ForEach(numbers, number =>
        {
            // Simulate some time-consuming operation
            Task.Delay(100).Wait();

            // Process the element
            Console.WriteLine($"Processed {number} on thread {Task.CurrentId}");
        });
    ```
   * **Locking and synchronization**: Including lock keyword, interlocked class,, and monitor class. This allow multiple threads to access shared resources safely and prevent race conditions.
   * **Concurrency Control**: supports concurrency control through transaction memory and optimistic concurrency control pattern.
> Race conditions arise when two or more threads access shared resources concurrently, and at least one of them modifies the resource.
<br/>

8. **Response Caching in .net core**
   * We can cache response returned by the server for specific period. 
   * Response caching works by adding a caching layer between client and server. 
   * This caching layers checks if any response has been cached for the given request, if not found request is sent to server. 
   * Implemented by `[ResponseCache]` attribute which can be applied to action method in controller. 
     * We can define duration of cache, location of cache and cache key. By default caching location is on the client side but it can also be setup to a distributed or proxy cache
   * One drawback can be if not used properly then it may result in stale data. 
   * **Applying ResponseCache to an action method**
    ```csharp
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, NoStore = false)]
    public IActionResult CachedAction()
    {
        // Action logic here
        return View();
    }
    ```
    * **Applying ResponseCache to Controller**: Similar way but we can also pass `Location= ResponseCacheLocation.Any` 
    * **Global Configuration in ConfigureServices**
    ```csharp
     services.AddResponseCaching(options =>
    {
        options.MaximumBodySize = 1024; // Maximum size of the response body that will be cached.
        options.UseCaseSensitivePaths = true; // Treat URLs as case-sensitive when determining whether a response is in the cache.
    });

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // Other configurations...

        app.UseResponseCaching();

        // Other middleware...
    }

    ```
<br/>

9. **What id difference between middleware and filter?**
 * Middlewares are components between web server and application and processes requests and responses. 
 * Middlewares are executed in a pipeline and can modify the request or response before passing to next. 
 * Filters are used for **cross-cutting concerns** and execute code before or after the execution of actions. `[TypeFilter(typeof(CustomAuthorizeFilter))]`
   * AuthorizationFilter - `IAuthorizationFilter { OnAuthorization(AuthorizationFilterContext)}`
   * ActionFilter - Run before actions are executed. 
   * ResulFilter
   * ExceptionFilter
<br/>

10. **Problem Details And Exception Filters**
    * Problem details are standardized format for conveying details about errors in HTTP API response. RFC 7807 and provides a consistent way to communicate error information, including status codes, error types, human-readable descriptions. 
    * Global Error Handler can be Implemented using `IExceptionFilter {  OnException(ExceptionContext context) }`
<br/>

11. **Locking Mechanisms in C#**
    * .NET provides different classes and keywords to allow developers to create thread-safe code and lock specific code zones. 
      * **Lock/Monitor**: 
      * **Mutex**
      * **SemaphoreSlim**
<br/>

12. **How to make thread safe code?**
    * Ideally we need to avoid the need for thread-safe code. That will save you from some future headaches. 
    * If we attempt to avoid shared state and mutable structure and use pure function this will automatically be taken care of. 
    * We can use **ConcurrentCollections** as ConcurrentDictionary or use adequate locking mechanisms. 
<br/>

13. **Classes vs Struct**
    * Classes are passed by reference and structs are pass by value
    * Classes are hosted on heap and structs are allocated on stack
    * Class object can be created using new keyword
    * we can assign null value to a class variable but we cannot do this for a struct variable. 
    * Two class variables can point to same object but structs can't do it. 
    ```csharp
    struct Employee {
    public int id;
    }
    ... 
    // declare emp of struct Employee
    Employee emp;

    // access member of struct      
    emp.id = 1;
    ```
<br/>

14. **Class vs Record**
    * Records are immutable but classes are not. Records were introduced in C# 9.0
    * Records are good fit for becoming a value object in DDD as they are equatable and we don't have to override the method.
    * Records are defined using Record keyword and classes with class keyword.
    * Records should not have any state change after instantiation while classes change properties.
    * Records automatically define `Equals`, `ToString` and `GetHashCode` methods.
    * Records are compared using Value comparison but classes are reference comparison
    * Records are suitable for Database Rows, Value Objects and DTOs.
    ```csharp
    // Basic record definition
    public record Person(string FirstName, string LastName);

    // Record with additional properties and methods
    public record Employee : Person
    {
        public string Department { get; init; }

        // Constructor and additional method
        public Employee(string firstName, string lastName, string department) : base(firstName, lastName)
        {
            Department = department;
        }

        public string GetFullNameWithTitle() => $"Mr/Ms {FirstName} {LastName}";
    }

    class Program
    {
        static void Main()
        {
            // Creating instances of records
            var person = new Person("John", "Doe");
            var employee = new Employee("Jane", "Smith", "Engineering");

            // Deconstructing records
            var (firstName, lastName) = person;

            // Comparing records (structural equality)
            var isEqual = person == new Person("John", "Doe");

            // Copying records with modifications
            var updatedPerson = person with { LastName = "Johnson" };

            // Displaying information
            Console.WriteLine($"Person: {person.FirstName} {person.LastName}");
            Console.WriteLine($"Employee: {employee.FirstName} {employee.LastName}, Department: {employee.Department}");
            Console.WriteLine($"Deconstructed Person: {firstName} {lastName}");
            Console.WriteLine($"Person Equality: {isEqual}");
            Console.WriteLine($"Updated Person: {updatedPerson.FirstName} {updatedPerson.LastName}");
        }
    }

    ```
<br/>

15. **An endpoint returns a result of 5 seconds, but the requirement says 2 seconds is a max. How are you going to troubleshoot it?**
    * **Break it down**: Systems are composed of subsystems so we need to break them down and detect which one is causing slowness. Eg Network latency, external services , database/
    * **Measure it**: After detecting component we need to measure by using **code profilers, database profilers and logging**
    * Determine if slowness is general or slowness is specific to a case.
      * If General: Check Processor usage, memory usage, any other infra related problems
      * If specific: Tune the code and queries maybe use database indexing. 
<br/>

16. **Lazy Loading**
    * Lazy loading is an approach that helps us defer loading of object untill we need it and then store it in memory
      * It can minimize start up time.
      * Enabling apps to use less memory unless we load the object
<br.>

17. **What is difference between async calls and Parallel calls?**
    * Main difference lies in how we control Task awaiters. If we are launching async code instruction and not awaiting them then we are effectively loading them in parallel. 
    ```csharp
    var taskA = MyAsyncMethodA();
    var taskB = MyAsyncMethodB();
    Task.WaitAll(new [] {taskA, taskB});
    Var result = await MyAsyncMethodC(taskA.Result, taskB.Result);
    ```
<br/>

18. **How would you handle caching in a high traffic .NET application to optimize performance?**
    * Identify the frequently accessed parts in the application that are computationally expensive. like db queries, API calls, heavy calculations. 
    * Determine the appropriate caching duration. Depending on data we can use time base expiration or sliding expiration.. 
    * Consider implementing distributed cache if your app runs on multiple servers. This is to maintain data consistency across servers.
    * Invalidate or refresh cache when underlying data changes. like **Event based cache invalidation**
    * Additionally leverage caching frameworks like Redis or Memcached.
    * **Measure**:Cache hit ratios, response times, and over all system performance to fine-tune the caching strategy
<br/>

19. **How to secure sensitive data in a .NET app?**
    * **Encryption**: This can protect data at rest and in transit
    * **Protect credentials**: Store credentials securely and avoid hardcoding them in the source code. 
    * **Input Validation**: Validate and sanitize user input
    * **Principle of least privilege**: Assign minimum necessary privileges. 
    * **Secure Communication**: Use HTTPS/TLS for data transmission
    * **Regular patching**: Keep application dependencies up to date. 
    * **Auditing and logging**: Audit to track access of sensitive data
    * **Security Testing**:
<br/>

20. **Override Equals and GetHashCode**
    ```csharp
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Person otherPerson = (Person)obj;

            return Name == otherPerson.Name && Age == otherPerson.Age;
        }

        public override int GetHashCode()
        {
            // Implement a custom hash code based on the fields used in Equals
            return HashCode.Combine(Name, Age);
        }
    }
    ```
<br/>

21. **Describe various authentication and authorization mechanisms available in ASP.NET and explain wheyn you would use each**
    1. **Forms Auth**:
       1. Traditional web apps where users use username and password
       2. User submit cred via login form and ASP.NET issues an auth cookie to the client.
    2. **Windows Auth**:
       1. Intranet or enterprise apps where `windows accounts are used`
       2. Users are automatically authenticated based on logged-in windows identity.
    3. **Token-based Authentication(OAuth/OpenID Connect)**
       1. APIs that need to auth users across different services.
       2. Token is used to authorize subsequent requests to the application or API
    4. **Claims based**
       1. For Apps that require fine grain access control based on user attributes or roles. 
       2. Users are auth based on a set of claims
    5. **Role based Auth**
       1. Apps where access of users or resources based on user roles.
    6. **Policy based Auth**
       1. Policy-based authorization allows you to define custom authorization rules using a flexible policy language. Policies can be based on multiple factors such as roles, claims, and even custom conditions.
<br/>

22. **How to handle concurrency and ensure thread safety in a multi threaded .NET apps?**
    * Use synchronization mechanisms like locks, semaphores, monitor or mutex. This helps control shared access allowing only one thread to access them at a time. 
    * Immutable data structures like ImmutableList and ImmutableDictionary
    * Thread-safe types: Use types like ConcurrentDictionary, ConcurrentQueue, ConcurrentStack and ConcurrentBag/ 
    * Atomic operations: 
    * Applying thread-safe design patterns: Such as Producer-Consumer , Reader-Writer or Immutable objects
    * Avoid Shared State
<br/>

23. **Why use asynchronous methods?**
    * Improve responsiveness of your apps. 
    * This is particularly useful while working with I/O bound operations, such as accessing a database or a web service over network. 
    * Calling async method doesn't block the current thread. When async task complete it notifies the original thread. 
<br/>

24. **What is multithreading and why do we need it?**
    * It is ability of OS to execute multiple threads concurrently. Threads are similar to processes but they are ligher and share the same address space. 
      * It allows to use idle CPU time.
      * Multiple tasks run simultaneously.
      * It helps avoid race condition and deadlocks. 
<br/>

25. **Explain Host**
    * Host manages the app's life cycle and providing resources for it's execution. 
    * It is container that has your app and orchestrates its startup, execution and shutdown:
    * Host Manages
      * Config
      * DI
      * Logging
      * Lifetime management
      * Hosting Environment
      * Web Server Integration
      * Hosted Services
<br/>

26. **Explain Session and State management options**
    * These refer to techniques for storing and maintaining data across multiple user requests. 
    * This data can be user specific or application wide(like config)
    * Session state uses cookies to track users, while we can also use cache or db to hold global state.
    * We can use `HttpContext.Session`from `Microsoft.AspNetCore.Session`
    * Session uses Key:Value pair storage mechanisms.
<br/>

27. **Model Binding**
    * It allows to map incoming request data to parms in action method in controller automatically. 
<br/>

28. **Explain Model Binding**
    * Models: Represent the data and logic of your application. They define the entities and their relationships, encapsulate business rules, and handle data access. Model classes typically interact with databases or other data sources.
    * Views: Responsible for presenting the user interface. They use technologies like HTML, CSS, and Razor to render the data received from the models in a visually appealing way. Views do not know the application logic and only focus on presentation.
    * Controllers: Act as the entry point for user interaction and orchestrate the flow of the application. They receive user requests, process them using the models, and ultimately choose which view to render. Controllers interact with both models and views, but never directly with the user interface.
<br/>

29. **Routing in AspNetCore**
    * Routing is process of matching incoming HTTP requests to a particular action methods on a controller. It plays a crucial role in determining how URLs are processed and mapped. 
    * **Conventional Routing**: It is based on conventions and maps URLs to controller action based on a predefined pattern
    ```csharp
    services.AddControllers()

     app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    ```
    * **Attribute Based**: This allows us to define attributes directly on controllers and actions using attributes. `[Route("api/controller")]`
<br/>

30. **What problem DI solve?**
    * Tight Coupling
    * Code Rigidity
    * Testing Difficulties
    * Maintainability Challenges
<br/>

31. **How to access HttpContext Object in Asp.Net Core Apps**
    * Two Ways
      * **Dependency Inject**: Using `IHttpContextAccessor` injection and using property `IHttpContextAccessor.HttpContext`
      * **Direct Access in Controller**: Using HttpContext
<br/>

32. **Explain Cancellation Token**
    * Cancellation can be used for internal and external processes.
    * A common `Cancellation communication pattern` was introduced as CancellationToken.
<br/>

33. **How to enable CORS in .net**
    * Configure Services
    ```csharp
     services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
    {
        builder.WithOrigins("http://example.com")
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));
    ```

    * Applying on Controller and action methods
    ```csharp
    [EnableCors("MyPolicy")]
    ```
    * Applying it on every request
    ```csharp
    public void Configure(IApplicationBuilder app)
    {
        app.UseCors("MyPolicy");

        // ...

        // This should always be called last to ensure that
        // middleware is registered in the correct order.
        app.UseMvc();
    }
    ```