# Azure Functions
* Allows to deploy function and manages the infra for us. 
* It provides many `event driven triggers and bindings`
* Some Common Trigger
  * Processing file upload: Trigger Function on Blob Update or Add
  * Process data in real time: Capture and transform data from IoT Source Stream. 
  * Infer on data model: Pull text from queue and push to AI services.
  * Run a schedule task: time triggered; like executing scheduled data clean up job
  * Build a scalable web api: We can implement REST Apis in our function app using HTTP trigger
  * Build a serverless workflow: Create event driven workflow from a series of function using durable function
  * Respond to DB Changes: Run a function when data gets added or modified in Azure Cosmos DB. CosmosDB uses change feed to notify about change
  * Create reliable messaging system: Processes message queues using Queue Storage, Service Bus and Event Hub
* **Monitoring**: Azure Monitor and Azure App Insights
* Azure Functions hosting, you can also host containerized function apps in containers that can be deployed to Kubernetes clusters or to Azure Container Apps.

## Durable Function
*  extension of Azure Functions that lets you write stateful functions in a serverless compute environment
*   lets you define stateful workflows by writing orchestrator functions and stateful entities by writing entity functions using the Azure Functions programming model.
*   It is used for
    *   **Function Chaining**: Func running in specific order using output of previous function
    *   **Fan out/ Fan in**: We run multiple function in parallel and then aggregate responses from all.
    *   

## Cold Start Behavior
* Apps may scale to 0 when idle for sometime this means some requests will have additional latency at startup. 
* Consumption Plan has Cold Start
* Premium, Dedicated plan has no cold start issue.

## Scaling
* Consumption Plan - Pay as you use
  * Event based scaling - Function hosts are added/removed based on number of incoming events
* Premium Plan - Auto scale based on demand using pre-warmed workers. 
  * It has longer timeout than consumption plan
* Dedicated
  * Run a function within a App Service plan.

# Scaling Azure Functions to Make 500,000 Requests to Weather.com in Under 3 Minutes
* URL: https://madeofstrings.com/2019/01/09/scaling-azure-functions-to-make-500000-requests-to-weather-com-in-under-3-minutes/ 
