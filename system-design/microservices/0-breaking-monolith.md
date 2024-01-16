# How to Break a Monolith into Microservices 🚀

## Step 1: Analyzing the current system 🔍
* *Analyze everything that your application is doing.* 
* *Very important to understand all the responsibilities that your monolith has accumulated over time.*

### White-boarding 📝
* **White boarding with both product & engineering.**. 
* Don't get into too much detail at this stage discussing each endpoint. 
* ***Outcome***: High Level Functionality & key parts of the application+ support functionality + existing auditing details when working in regulatory.

### 📍Identify key domains 🆔
* Splitting monolith should be done in a way to **idependently** release them
* Starting with DDD may help avoid spaghetti mess of dependencies and maintaining multiple components with every release.
* Outline the supporting functionality
  * Auditing
  * Logging
  * Authentication
  * Document Storage
<br/>

### ☠️😵Hardest Challenge😵☠️
  *  `Databases` -Each microservice should be managing it's own database.
  * Think about data ownership when outlining your domains.
  * 2 microservices access data via APIs - look at how you join data this can help outline your domain
  * When a microservice has to reference data from another microservice it should be through Ids. 
    * Eg. We can reference UserId but `source of truth` of the user data will remain in user microservice.

### .🎯 Picking the right candidates
  * Don't make a big bang 💥 i.e. never completely switch from one architecture to another.
  * **Better approach**: Make incremental changes towards your ideal architecture. 
  > *There is only one way to eat an elephant: a bit at a time*
  * try to start with a PoC by picking a small part of your system that isn't so critical and is well isolated. so if some problem occur no one start yelling as soon as it goes offline 😂
  * A good candidate can also be new features. As new feature should be a microservices anyways. Not doing this, will lead to extra time migrating this later.
  * First microservice will have lot of infrastructure setup - try re-using parts of infra or use templates for creating new service.
  * try with smaller parts of system which has least dependencies, this will help team gain confidence to move to bigger parts.
  * Services that need frequent change are good candidates because developers will be able to deliver value faster.
  * ⛔⛔ Business hat big migration projects as they slow down dev of new features. Early delivery of features may be business more sympathetic towards project.

### ✨New Or Reuse✨
  * Don't be tempted to copy existing code, it may work for small well-defined classes.
  * Go over functionality and analyze the scope of refinement.
  * If existing project is old, refresh the tech stack. 
  * If you want to use some functionality from monolith, try to to expose a new endpoint from your monolith. 
  * Add an **anti-corruption** layer between the microservice and monolith to ensure we don't couple them together. 
    * It is used to ensure clean separation and minimizing dependencies between them. 

## 🤔Migration Strategies
* To avoid big bang 💥 strategies should be well thought. 
### 👴 Old Data
  * Depending on complexity & size of data you may need to develop migrations tools. 
  * Include it in estimates
  * Migration will also depend on how it has to be access.

### 👶New Data
  * Any new data will be written to the microservices database.
  * If using incremental IDs they should start with higher number than existing Ids.

### ✈️ In-Flight Data
  * Important to manage old & new data access and your in-flight data may want reference of old data to complete some processing

### 🚦Controlling Traffic
  * To migrate traffic from monolith to the microservice can be done
    * **Simplest**: Call the microservices from the monolith. It might be done when data migration is still going on. 
      * Decouple functionality into new microservice
      * Add code to monolith to call the microservice. This can include the option to fall back to the original data store when data can' be found.
      * Migrate old data from monolith to microservice
      * remove the old code path from monolith
    * **Conservative Approach**: 
      * Shadow request(Duplicate) to the microservice while still serving the users from monolith. **Allows to test in production** without impacting users.
      * Divert small percentage of traffic to the new microservice. Depending on type of users like free plan user may get ddiverte
      * Increase the amount of traffic while monitoring the progress until you get to 100%.
      * Migrate any data from old db
      * Remove the old code path from monolith

# 💭 Final Thoughts
  * It may take years and it is not uncommon for business to give up halfway through. Hence piece meal approach is often better than trying to change everything at once.
  * 