# EF Core
* **Features**
  * **Cross Platform**: Windows , Linux & Mac
<br/>

  * **Modelling**: EDMs(Entity Data Models) are typically created based on POCOs. This will be used when querying/saving data.
<br/>

  * **Querying**: Allows to retrieve data from underlying databases using LINQ
<br/>

  * **Change Tracking**
    * By using the `SaveChanges` method of the context, EF Tracks changes to the entities and their relationships and ensures the correct updates are performed on the database. 
    * Change tracking helpsto generate efficient SQL statements for insert, updates, and delete based on the modifications detected. 
    * Change tracking is enabled by default but can be disabled by `AutoDetectChangesEnabled` prop of DbContext to false.
    * **Change Tracking States**
      * **Added**: New record to be inserted into db
      * **Unchanged**: entity being tracked hasn't changes since queried from db
      * **modified**: Some of properties are modified
      * **Deleted**: entity being tracked represents a record to be deleted from the database
      * **Detached**: Entity is not being tracked by EF
        ```csharp
        using (var context = new YourDbContext())
        {
            // Querying an existing person from the database
            var person = context.People.Find(1);

            // Change the person's age
            person.Age = 30;

            // Check the state of the person entity
            var entry = context.Entry(person);
            Console.WriteLine($"Entity State: {entry.State}");

            // Save changes to the database
            context.SaveChanges();
        }
        ```
    * **Disabling change tracking**:
    ```csharp
    var people = context.People.AsNoTracking().ToList();
    ```
<br/>

  * **Saving**: `SaveChanges()` and `SaveChangesAsync()`
<br/>

  * **Concurrency**: EF provides built-in support for Optimistic Concurrency to prevent an unknown user from overwriting data from the database.
    * implemented using a version number or timestamp column in the database. 
    ```csharp
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        // Optimistic Concurrency property
        public byte[] RowVersion { get; set; }
    }

    public class YourDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.RowVersion)
                .IsConcurrencyToken(); // Configures RowVersion as a concurrency token
        }
    }

    using (var context = new YourDbContext())
    {
        // Assume you have a product with Id = 1 in the database
        var product = context.Products.Find(1);

        // User 1 retrieves the product and modifies it
        product.Price = 19.99;

        // Save the changes
        try
        {
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // Handle concurrency conflict
            var entry = ex.Entries.Single();
            var databaseValues = entry.GetDatabaseValues();
            var databaseRowVersion = (byte[])databaseValues["RowVersion"];

            // You can compare the current client's RowVersion with the one in the database
            // and take appropriate action, such as showing a conflict resolution UI to the user
            // or automatically resolving it based on your application's logic.

            // For simplicity, let's say we'll just update the RowVersion and try saving again
            product.RowVersion = databaseRowVersion;
            context.SaveChanges();
        }
    }


    ```
<br/>

  * **Transaction**
<br/>

  * **Caching**: First-level caching of entities is supported out of the box in the EF
<br/>

  * Built In Convention
<br/>

  * Configuration 
<br/>

  * Migration
<br/>

* **PROS**
    * Microsoft supported open-source ORM for .net apps
    * Auto-migrations, it is simple t create a database or modify it.
    * Unique syntax for all object queries whether they are databases or not. 
* **CONS**
  * Slower form of ORM because
---

* **Explain different parts of entity data model:**
  * EDM Has:
    * Conceptual Model: aka Conceptual data definition language layer. It consists of model classes and their relationships. 
    * Mapping Model: aka Mapping Schema Definition Language Layer. Informatio about how the conceptualmodel is mapped ot the storage model
    * Storage Model: aka Storage space definition language layer. It represents storage area in the backend. aka database design model that is composed of keys , tables and stored procedures. 
<br/>

* **Entity Framework Approaches**
  * Code First: Classes are used to create models and relationships which are then used to create database.
  * Model First: It uses ORM to build model classes and their relationships. Following the successful creation of the model classes and relationships, the physical database is created using these models.
  * Database First: build entity models based on existing databases and reduce the amount of code required.
<br/>

* **Ways to increase performance**
  * Choose right collection for data manipulation. 
  * Do not put all DB objects into one entity model 
  * When enity is no longer required, it tracing should be disabled. 
  * Dont fetch all fields unless needed. 
  * Use compiled queries whenever needed.
<br/>

* **How EF Core supports transactions?**
  * Each `SaveChanges()` is it's own small transaction but multiple `SaveChanges()` are independent. To have transactions:
  * **Transaction Management**: EF allows you to call SaveChanges() within the context of a transaction. All changes made to the entities tracked by the context will be persisted when SaveChanges is called.

  ```csharp
    using (var dbContext = new YourDbContext())
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                // Perform database operations within the transaction

                // Save changes within the transaction
                dbContext.SaveChanges();

                // Commit the transaction if all operations succeed
                transaction.Commit();
            }
            catch (Exception)
            {
                // Rollback the transaction in case of an exception
                transaction.Rollback();
            }
        }
    }

  ```
<br/>

* **What is deferred execution?**
  * Queries are not executed immediately when they are defined, but rather they are executed when the data is actually needed. 
  * Using IQueryable we can build queries with deferred execution. Hence until the `ToList()` or `FirstOrDefault()` is called.
  * This enables optimizations like batching and avoiding unnecessary database calls
    ```csharp
    using (var dbContext = new YourDbContext())
    {
        var query = dbContext.Products.Where(p => p.Price > 50);

        // At this point, the query is defined, but no database call is made yet.

        var result = query.ToList(); // The actual database query is executed here.
    }
    ```
<br/>

* **Dbset vs DbContext**
  * DbSet: Entity is represented by DbSet and used for CRUD operations
  * DbContext: Primary goal is bridge gap between entity or domain classes and the database and communicate with database.
<br/>

* **Eager vs Lazy vs Explicit Loading**
  * Eager: When the related data is loaded along with the main entity in every single database query. This is to reduce number of db trips. 
    ```Csharp
    using (var dbContext = new YourDbContext())
    {
        // Eager loading using Include method
        var orders = dbContext.Orders.Include(o => o.Customer).ToList();

        // Now, each Order entity will have its associated Customer entity loaded as well.
    }

    ```
  * Explicit Loading:
    * Load related data on demand when it is explicitly requested.  
  ```csharp
    using (var dbContext = new YourDbContext())
    {
        var order = dbContext.Orders.Find(1);

        // Explicit loading using the Entry method
        dbContext.Entry(order).Reference(o => o.Customer).Load();

        // Now, the Customer related to the specific Order is loaded.
    }

  ```
  * Lazy Loading: Data is automatically loaded from he database when the property that represents the related data is accessed. 
  ```csharp
  public class YourDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading
        }
    }
  ```
  **Guidelines to select the right loading**
  * When you know you will use related entities with your main entity everywhere, use Eager Loading.
  * You should use Lazy Loading whenever you have one-to-many collections.
  * Use lazy loading only if you are sure you won't need related entities right away.
  * When you are unsure about whether or not an entity will be used, use explicit loading after you have turned off Lazy Loading
<br/>

* **Explain How to avoid SQL Injection attacks in EF Core**
  * **Use Parameterized Queries**:
  ```csharp
  // Example using LINQ
    var username = "user123";
    var user = dbContext.Users.Where(u => u.UserName == username).FirstOrDefault();
  ```
  * **Using Stored Procedure**
  * **Avoid RAW SQL Concatenation**
  * **Use Stored Procedure**
<br/>

* **EF Core Optimizations**
  * Use Projections (Select). `var result = dbContext.Products.Select(p => new { p.Id, p.Name }).ToList();`
  * Use AsNoTracking for read-only operations
  * Batching queries with chunking
  * Avoid N+1 Query problem by using Include
  * Use Connection resilience and retry policies
  * database connection pooling


## Setting up concurrency in ef core
* Concurrency conflicts occur when one user retrieves an entity's data to modify it and then another user updates the same entity data before the first user's changes are written to database. We can handle it. 
* **Last In Wins**
  * In some cases there is 1 version of truth so it doesn't matter if user overwrite changes. 
  * Eg 2 users attempting to update final score. 
  * There is no need for any concurrency management strategy here. 
* **Pessimistic Concurrency**
  * It involves locking database records to prevent other users from being able to access/change them until the lock is released. 
  * However not all dbs supports this functionality to lock records. 
  * This add complexity and make program resource intensive. 
  * EF provides no support for pessimistic concurrency control. 
  * It is not possible in disconnected scenarios such as web apps. 
* **Optimistic Concurrency**
  * For concurrency conflict detection we can follow one of 2 approaches
    * **Configuring existing properties as concurrency token**
      * This can be done by adding `[ConcurrencyCheck]` attribute to specific properties or using `IsConcurrencyToken()` in model builder.
      ```csharp
      public class Author
      {
          public int AuthorId { get; set; }
          [ConcurrencyCheck]
          public string LastName { get; set; }
          public ICollection<Book> Books { get; set; }
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.Entity<Author>()
              .Property(a => a.LastName).IsConcurrencyToken();
      } 
      ```
      * Any properties added as concurrency token will be added in where clause of `update` or `delete` statements. 
      * When SQL command is executed, EF Core would expect one row that matches original value. 
      * If values were changed in between and no row found then `DbUpdateConcurrencyException` comes.
      * This property can be applied to as many non primary keys as needed.
    * **Adding a rowVersion property to act as concurrency token**
      * different db offers different type for this column, `rowVersion` data type for this purpose. 
      * This column stores an incrementing version. 
      * This property must be `byte[]` in model and can be annotated by `[TimeStamp]`
      ```csharp
      public class Author
      {
          public int AuthorId { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public ICollection<Book> Books { get; set; }
          [TimeStamp]
          public byte[] RowVersion { get; set; }
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.Entity<Author>()
              .Property(a => a.RowVersion).IsRowVersion();
      } 
      ```