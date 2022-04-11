# Data Partitioning
> **DEFINITION**: It is technique to break up big database into many smaller parts across multiple machines to improve manageability, performance, availability and load balancing. 

# Partitioning Methods
* Below are three most popular schemes: 
    1. **Horizontal partitioning/ Data Sharding / Range Based Partitioning**
        - 
        - Putting Different rows in different tables. 
        - Example: ZipCode < 10000 in one table, >10000 in another table
        - If partition isn't chosen carefully, we can have **unbalanced server**
        - This can be good for evenly distributed data
    2. **Vertical Partitioning**
        - 
        - We divide our data to store tables related to a specific feature in their own server. 
        - Easy to implement and low impact on app
        -  Problem is on additional growth, then it may be necessary to further partition a feature specific DB across various servers
    3. **Directory Based Partitioning** 
        -
        - Loosely coupled approach to work around issues mentioned in above schemes is to create a lookup service which knows about your current partitioning scheme and abstracts it away from db access code. 
<br/>

# Partitioning Criteria 
* **Key or Hash Based Partitioning** 
    - 
    - We apply hash function to some key attributes of the entity we are storing. that yields the partition number. 
    - **Example** We have 100 DB server, and ID is incremented by 1, then to get server to store we can compute hash of ID % 100 
    - This ensures an uniform allocation of data among servers
