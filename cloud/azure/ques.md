* **Web apps vs function apps vs logic apps**
  * Web Apps - PaaS used to deploy various Web apps, backend services, they provide fully managed env and support for various programming language.
  * Function Apps - Small server components(function code) running in azure based on events and trigger. The infra is fully managed by azure.
  * Azure Logic Apps: It is used for creating workflows that connect with various services and data sources. They provide a visual designer 
<br/>

* **Key Components of ARM - Azure Resource Manager**
  * Resource groups: logical grouping of related resources. 
  * ARM Templates: JSON Files that define `resources, configurations, and dependencies` for azure deployment
  * ARM API: Restful API for managing azure resources programmatically
  * RBAC: Role based access control. 
<br/>

* **How to access readiness of an application for migrating to azure?**
  * **Compatibility Analysis**: `application's architecture, technology stack, and dependencies ` should be compatible with azure resources
  * **Performance & Scalability**: determine apps `response times, throughput, and resource utilization.` and check if azure auto-scale, load balancing can benefit it.
  * **Data migration**: Access type & size of data and choose the right azure service.
    * Azure Cosmos, SQL Server, Blob, Table Storage
    * Plan for data migration, including data transfer methods, data transformation, and data synchronization.
  * **Security & configuration**: Review the application's security requirements, such as authentication, authorization, encryption, and data protection. Ensure chosen azure service provides them
  * **Networking and connectivity**: Plan apps  `bandwidth, latency, and connectivity to on-premises or other cloud resources.`
    * Azure Networking services Virtual Networks, ExpressRoute, or VPN Gateway
  * **Cost estimation**:Estimate cost of running apps in azure. compute, storage, networking, and data transfer costs should be included. Use azure pricing calculator.
  * **Migration Strategy**
    * rehosting (lift-and-shift), 
    * refactoring (re-architecting), or 
    * rebuilding (re-platforming). 
<br/>

* **Azure Service Bus vs Event Hub vs Event Grid**
  * Service Bus - fully managed message broker which supports both `point-to-point` & `publish-subscribe` comm model.
  * Event hub - big data streaming platform and event ingestion service. Can process millions of messages per second. It is for real-time data processing and analytics.
  * Event Grid - fully managed event routing service that enables event-driven, reactive programming. It connects event sources with event handlers using a publish-subscribe model and supports filtering and routing based on event types and data.
<br/>

* **Azure Active Directory AAD**
  * now Entra ID - cloud based identity and access management service. 
  * It provides provides single sign-on (SSO), multi-factor authentication, and identity protection for applications and services.
  * Supports modern auth protocols like OAuth 2.0 and OpenID Connect.
<br/>

* **Azure VMs**
  * IaaS - Infra as a Service.
  * VMs provide more control over the underlying infrastructure, including the operating system, networking, and storage. 
  * VMs are good for apps that need specific software or version which are not provided by other azure compute resources like web apps, functions.
<br/>

* **Azure Blob**
  * It is object storage service for unstructured data like text, images, videos, etc. 
    * Data Replication
    * Support for hot, cool, and archive access tiers to optimize storage costs based on data access patterns.
    * Integration with Azure Content Delivery Network (CDN) for global content distribution.
    * Data encryption support
<br/>

* **Monitoring, Logging & Alerting in Azure**
  * **Use Azure Monitor**: 
  * **Enable diagnostic settings**: 
  * **Utilize log analytics**: 
  * **Implement AppInsights**:
  * **Set Up Alert**:
  * **Monitor security**: Azure Security Center (now called Microsoft Defender for Cloud) for continuous security monitoring, threat detection, and compliance assessment.
<br/>

* **AKS**
  *  managed container orchestration service
  *  simplifies the deployment, scaling, and management of containerized applications by providing
     *  fully managed Kubernetes control plane
     *  Integrations with Azure Active Directory, Azure Monitor, and Azure Policy.
     *  Kubernetes dashboard and the 
     *  kubectl command-line interface. 
<br/>

* **Azure CosmosDB**
  * globally distributed, 
  * multi-model database service (`document, key-value, graph, and column-family.`) designed for 
    * low-latency, 
    * high-throughput, and 
    * scalable applications.
  * Global distribution with automatic data replication
  * Tunable consistency levels - to balance consistency & performance
  * support for partitioning, indexing, and querying data.
<br/>

* **Azure Data Factory**
  * Data integration service 
  * Allows us to create, schedule, and manage data workflows for moving and transforming data from various sources to various destinations. 
  * UI for designing pipeline
  * Support for various data sources and data sinks(destinations)
  * Built-in data transformation activities, such as data movement, data flow, and data lake analytics.
  * Integration with Azure Machine Learning and Azure Databricks
<br/>

* **Azure data security and privacy**
  * data encryption
    * data at rest
    * in-transit
  * network isolation
  * access control
  * azure complies with `GDPR, HIPAA, and PCI DSS.`
<br/>

* **Azure auditing, monitoring and compliance**
  * Azure Monitor,
  * Azure Security Center, and 
  * Azure Policy. 
  * These tools help you detect and respond to security threats, enforce compliance policies, and generate audit reports for regulatory purposes.
<br/>

* **Azure Storage Service Encryption (SSE)**
  * Automatically encrypts data at rest for - `Azure Blob Storage, File Storage, Table Storage, and Queue Storage.`
  * SSE uses:
    * Azure-managed encryption keys or 
    * customer-managed keys to encrypt data before it is written to storage and decrypts it when it is read.
<br/>

* **What is Azure Load Balancing**
  * network service that distributes incoming network traffic across multiple resources, such as VMs, to ensure high availability, scalability, and low latency. 
  * Azure Load Balancer supports both 
    * Layer 4 (TCP/UDP) and 
    * Layer 7 (HTTP/HTTPS) traffic and provides features such as:
      * Health probes for monitoring 
      * Load Balancing rules
      * Session persistence for maintaining client connections to the same resource during a session.
<br/>

* **Azure ExpressRoute**
  * dedicated, private network connection between your on-premises infrastructure and Azure data centers
<br/>

* **Azure Backup**
  * Used for backup & restore:
    *  VMs, databases, and file shares
 * Supporting incremental backups, which reduce storage and network costs by only backing up changed data.
 * Encrypting backup data at rest and in transit 
 * Offering flexible retention policies and recovery options
<br/>

* **Your company is planning to migrate an existing web application to Azure. The application consists of a front-end web server, a back-end database server, and a file storage system. Describe the Azure services and components you would recommend for each part of the application and explain your choices.**
  * **Front-end web server**:
    * App Service
    * Azure CDN - to server static content of project
  * **Back-end web server**:
    * SQL Db- 
  * **File storage system**:
    * Azure Blob Storage:  It can store and serve large amounts of unstructured data, such as images, videos, and documents. 
      * Data can be organized in containers and accessed through REST APIs
    * Azure Files:  shared file system accessible by multiple virtual machines, Azure Files provides fully managed, scalable file shares in the cloud, accessible via Server Message Block (SMB) protocol
  * **Identity and Access Management**
    * AAD
  * **Monitoring and Log Analytics**
    * Azure Monitor and 
    * Azure Log Analytics
  * **Networks**: 
    * Azure Virtual Network: Create a Virtual Network to isolate and securely connect your Azure resources. 
  * **Security**
    * Azure Security Center
<br/>

* **You are tasked with designing a serverless architecture for a new image processing application in Azure. The application should automatically generate thumbnails for images uploaded to a storage account and store the thumbnails in a separate container. Explain how you would implement this solution using Azure Functions and other Azure services.**
  * Azure Storage Account: For storing original images. 
  * Azure Blob Storage trigger in Func App
  * Azure Function for image processing
    ```csharp
    public static void Run(
    [BlobTrigger("input-container/{name}", Connection = "AzureWebJobsStorage")] Stream imageStream,
    [Blob("output-container/{name}", FileAccess.Write)] Stream imageOutput,
    string name,
    ILogger log)
    {
        // Perform image processing (e.g., generate thumbnails) using imageStream
        // Write the processed image to imageOutput
    }

    ```
  * Output storage container
  * scale the azure function
  * monitoring and logging
  * access control
<br/>

* **A client wants to implement a multi-region disaster recovery strategy for their Azure-based e-commerce application. The application consists of a web front-end, a REST API, and an SQL database. Describe the steps you would take to ensure the application can failover to a secondary region in case of a regional outage.**
  * Assessment of Azure Regions:
    * Select primary and secondary region(consider proximity to users, regulatory compliance, and service availability.)
  * Azure Traffic Manager:
    * Distributes traffic across multiple regions
    * Configure it with a failover routing method so that if the primary region becomes unavailable, traffic is re-routing
  * Azure App Services
    * For backend
  * Azure API Management or API gateway
    * Deploy APIs in primary and  secondary region
  * Azure SQL Database:
  * Azure Traffic Manager Probing:
    * Configure health probes in traffic manager
  * Azure Database Failover Groups:
    * If using Azure SQL set failover groups
  * Azure Site Recovery
    * For additional redundancy and failover automation, consider using Azure Site Recovery.
  * Monitoring and Alerts
  * Documentation and runbook
<br/>

* **Your company has an Azure-based application that processes sensitive customer data. The security team has requested that all data stored in Azure must be encrypted both at rest and in transit. Explain how you would implement encryption for data stored in Azure Blob Storage and data transmitted between Azure services.**
  * Data @ REST(In Blob)
    * Azure Storage Service Encryption (SSE):
      * Microsoft-managed keys (SSE with Microsoft-managed keys)
      * Customer Managed Keys
    * Azure Disk Encryption:
      * If app uses VM which have data disks
    * Data in TRANSIT 
      * Azure Virtual Network
        * connect your Azure services using Virtual Networks to create a private network for secure communication.
      * Use HTTPS for web endpoints
      * Azure Private Links
        * Use Azure Private Link to access Azure services (like Azure Blob Storage) over a private network connection
      * TLS(Transport Layer Security)
        * All comm uses latest version of TLS
      * Azure Key Vault 
<br/>

* Further Reading: https://anywhere.epam.com/en/blog/azure-interview-questions 