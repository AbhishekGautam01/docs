# Designing a URL Shortening Service like TinyURL 
**AIM** - This service will provide short aliases redirecting to long URLs 
**Similar Services** - bit.ly, goo.gl, qlink.me, etc. 
**Difficulty Level** - Easy 
<br/>

## Why do we need URL Shorting?
* Used to create shorter Aliases for long urls known as short links. 
* Short links save lots of space when displayed, printed, messaged or tweeted. 
* Prevents from mistyping URLs 
* This can optimize links across devices, tracking individual links to analyze audience and campaign performance. 

## Requirements and Goals of System 
> Note: Get exact scope of system before designing any solution. 

### Functional Requirements 
1. Generate shorter URL and short alias of it. 
2. On access of these short links they should go to the original URL 
3. Users should be able to pick custom URL for their links 
4. Links should expire after standard timespan. 
5. Users should be able to configure this timespan for their URL

### Non Functional Requirements 
1. High Availability 
2. URL redirection should be real time with minimum latency 
3. Short URL should not be predictable. 

### Extended Requirements 
1. Analytics
2. This service should be exposed as REST APIs to other services. 

## Capacity Estimation and Constraints 
* System will be **read-heavy**
* There will be more redirection compared to new Shortening 
* **Traffic Estimates** - 500M new URL shortened per month, 100:1 Read/Write ratio, 50B redirection per month. 
<br/>

* **Queries Per Second(New URL Shortening)** = 500 million / (30 days * 24 hours * 3600 Seconds) ~ 200 URLs/ Second

* **URL redirection Per Second** = 100 * 200 URLs/Second = 20K/s 
<br/>

* **Storage Estimates** - Data to be stored for 5 years, so 30 Billion Objects to be stored. Each Object is 500 Bytes (assumption) = **15TB storage**
<br/>

* **bandwidth Estimates** - For write request total data per second would be = **200 X 500B = 100KB/s**
For Read request , total outgoing data would be = **20K X 500B = 10MB/s**
<br/>

* **Memory Estimates** - If we implement caching for some hot URLs , if we use 80-20 rules, assuming 20% URLs generate 80% traffic. 20K request per second means **1.7 Billion request per day**  so memory needed to cache 20% of these would be **170GB = 0.2 X 1.7 Billion X 500B** 
<br/>

### Estimates Summary 

| Param | Estimates | 
| :----: | ----: |
| New URL | 200/s |
| URL redirection | 20K/s | 
| Incoming Data | 100KB/s | 
| Outgoing Data | 10MB/s | 
| Storage for 5 years | 15TB | 
| Memory for cache | 170GB | 

## System APIs 
> Post getting requirements, it's good idea to define the system APIs. 
* We can expose our service as SOAP/ Rest Endpoints
> **createURL(api_dev_key, original_url, custom_alias=None, user_name=None, expire_date=None)**
* Parameters: 
    1. api_dev_key(string): API developer key of registered account. This can be used for many things like rate limiting based on their quota. 
    2. original_url(string): Original URL to be shortened
    3. custom_alias(string): Optional; custom key for URL 
    4. user_name(string): Optional; user name to be used in the encoding
    5. expire_date(string): Optional; expiration date for shortened URL.
<br/>
* Returns: String - A successful insertion returns the shortened URL; otherwise it returns an error code. 
> deleteURL(api_dev_key, url_key)
1. url_key - Shortened URL to be retrieved. 
* A successful deletion should return "URL Removed"

#### Detecting and Preventing Misuse?
1. Any malicious user can effect our business by consuming all our keys. We can limit users via their api_dev_key. Each api_dev_key should be limited to a number opf URL creations over a period of time. 

## Database Design 
* DB schema would help us understand data flow across various components.
* Few observation about data to be stored: 
    1. Storage requirements needs us to store billion of records. 
    2. Each object is small (< 1K)
    3. No relationship between records apart from user
    4. We need read-heavy operations 

### Table Schema 
Table Name: URL 
| Column | Type | 
| :----| ----: |
| Hash | PK, varchar(16) | 
| OriginalURL | varchar(512) | 
| CreationDate | datetime | 
| ExpirationDate | datetime | 
| UserID | int | 
<br/>

Table Name: User 
| Column | Type | 
| :----| ----: |
| UserID | int, PK |
| Name | varchar(20) | 
| Email | varchar(32) | 
| CreationDate | datetime | 
| LastLogin | datetime | 
<br/>

### What kind of database to use 
* since we want to store huge amount of data with no or little relationships between objects - **NoSQL** store like **DynamoDB, Cassandra or Riak** is a better choice. 

## Basic System Design and Algorithm 
* We can have below two solutions for generating a url_key 
1. **Encoding actual URL** 
    * We can compute a unique has of the given URL. 
    * This hash can be then encoded to display 
    * We can use base36[a-z, 0-9] or base62[a-z, A-Z, 0-9]
    1. **What should be length of encoding?** 
        * Use base64 - 6 letter long string would result - 64^6 = ~ 68.7 billion 
        * Use base64, 8 letter long key would result in 64^8 ~ 281 trillion possibilities.
        * therefore we can go ahead with 6 letter long. 
        * If we use MD5 algorithm, we get 128 bit hash, now 128/6 ~ 21 we will have atleast 21 character string. 
    2. **What are some issues with our solution?**
        * If multiple users enter same URL they may get same shortened URL which is against requirement 
        * If parts of URL are identical  except the encoding, like some url may have ? same may have %3F
    3. **Workaround** 
        * we can append incrementing sequence number to each URL then make it unique and then generate hash. but this may lead to flow of this ever increasing sequence number. 
        * This incrementing sequence number may **impact performance**
        * another approach is to append unique userId, but for this user must signing or we must ask user for a unique key so we can use it to append but if doesn't enter unique key in first try he will have to repeat it until he succeeds. 
        <br/>

2. **Generating Keys Offline**
* We can have a standalone **Key Generation Service(KGS)** that generates random six-letter strings beforehand and stores them in a database. 
* This approach will make the process simple and fast. 
* Not only **we are not encoding URL** we will also not have to worry about collisions. 
    1. **Can Concurrency cause problem?** 
        * As soon as key is used it should be marked so it cant be re-used. If multiple servers are reading key from db then we might have two server reading same key. 
        * KGS can maintain two tables one for used keys and one for non used keys 
        * As soon as a server reads a key, KGS should move it to used keys table. 
        * KGS should also keep some keys in memory for fast access. 
        * If KGS dies before assigning the keys to server, we may loose some keys. 
        * KGS should hold a lock or must synchronize the data structure holding the keys before removing keys from it and giving it to server. 
    2. **KEY DB SIZE** 
        * 68.7 billion unique six letters keys  each requiring 1 byte to store. **412GB**
    3. **Key Generation Service As Single Point of Failure** 
        * We can have standby replicas of KGS which can take over if primary instance dies 
    4. **Can each app server cache some keys from Key-DB store** 
        * This would be good but here also we will have a chance of loosing some keys, but since we have huge number of keys this should be fine. 
    5. **How to perform Key LookUP** 
        * Key Lookup to get full URL 
        * If present issue an **HTTP 302 Redirect** status back to browser, Passing stored URL in browser. 
        * If the key is not present issue an **HTTP 404 Not Found** status. 
    6. Should we impose size limits on custom aliases.
        * Users can choose this and this is optional 
        * We can put a limit of 16 characters as this reflects with our db design as well 
        <br/>

## Data Replication and Partitioning
* We need partitioning to successfully be able to store billions of records. 
1. **Range Based Partitioning** - Based on first letter of hash key we can partition URLs 
We can also combine less frequently colouring letters into one db. 
We should come up with **static partitioning approach** so we can always store/find URL in predictable manner 
**PROBLEMS** 
This can lead to unbalanced db server. 
<br/>

2. **Hash Based Partitioning**
* take hash of object to store and then calculate which partition to use based upon the hash
* This approach can still lead to overloaded partitions, which can be solved by **Consistent Hashing** 

## Caching 
* We can use off the shelf cache solutions like Memcached, Redis, etc 
* Our service can first quickly check cache if the data is present or not
1. **How much memory should we have?** 
    * We can start by caching 20% of daily traffic and based on usage pattern we can adjust. 
2. **Which cache eviction policy to use?** 
    * **Least Recently Used**
    * We can use **Linked Hash Map** or similar data structure to store our URLs and hashes. 
    * We can **replicate our cache servers** to further distribute our load. 
3. **How can each replica be updated** 
    * Whenever there is a cache miss, our servers would be hitting a backend db whenever this happens, we can update the cache and pass the new entry to all cache replicas. 
    ![Img](./img/1.png)
<br/>

## Load Balancer 
* We can add this layer at 3 places
    1. Between client app and application server 
    2. Between application servers and db servers
    3. Between application servers and cache servers

* Initially, we could use a simple Round Robin approach that distributes incoming requests equally among backend servers. This LB is simple to implement and does not introduce any overhead. Another benefit of this approach is that if a server is dead, LB will take it out of the rotation and will stop sending any traffic to it.

* A problem with Round Robin LB is that we don’t take the server load into consideration. If a server is overloaded or slow, the LB will not stop sending new requests to that server. To handle this, a more intelligent LB solution can be placed that periodically queries the backend server about its load and adjusts traffic based on that.

## DB Cleanup or Purging 
* if we actively look and purge records it would add pressure on our db server 
* We can use **lazy cleanup** some records may exist for longer but will never be returned to users. 
* **CLEAN UP APPROACH**
    1. Whenever user tries to read an expired link, we can delete the link and return an error to the user
    2. A separate cleanup service can run periodically and remove expired links from cache and db. 
    3. We can have default expiration time, let say 2 years. 
    4. After removing an expired link, we can put the key back in the key DB to be reused. 
    5. Should we remove keys which have not be visted in quite sometime, this can be tricky. but as storage is getting cheaper, this might not concern us. 
    ![img](./img/12.png)

## Telemetry 
* Some statistics worth tracking: country of the visitor, date and time of access, web page that refers the click, browser, or platform from where the page was accessed.

## Security and Permissions 
* Can users create private set of URLS for specific users. 
* We can store the permission level (public/private) with each URL in the database. We can also create a separate table to store UserIDs that have permission to see a specific URL. If a user does not have permission and tries to access a URL, we can send an error (HTTP 401) back. Given that we are storing our data in a NoSQL wide-column database like Cassandra, the key for the table storing permissions would be the ‘Hash’ (or the KGS generated ‘key’). The columns will store the UserIDs of those users that have the permission to see the URL.
