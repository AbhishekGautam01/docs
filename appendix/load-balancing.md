# Load Balancing
* Helps spread traffic across cluster of servers to improve responsiveness and availability of apps, dbs. 
* Keeps track of **status of all resources** while distributing load. 
* If a server is **not responding, high error rate** then LB will not send traffic to it. 
* It **sits between client and server** and distributes traffic based on various algorithms. 
* This prevents any one of application server from becoming **Single point of failure** 
![LB](./img/LB.svg)

* LB Can be added at 3 places: 
    1. Between User and the web server
    2. Between web servers and internal platform layer likw **cache servers, app servers** 
    3. Between internal platform layer and database. 
![LB](./img/LB1.png)
    <br/>

## Benefit
* Faster uninterrupted services. 
* Service providing Less downtime and higher throughput. 
* Smart load balancers provide **analytics to determine traffic bottlenecks** before they happen. It can also provide actionable insights to the business. 
* Fewer Failed or Stressed Components. 

# Load balancing Algorithms 
## How does Load Balancer Choose the backend server. 
* It is based on following two factors: 
    1. Server is responding appropriately to the requests. 
    2. Use of pre-configured algorithm to select one from the set of healthy servers. 

## Health Checks 
* Traffic should be only forwarded to healthy backend servers. 
* LB regularly tried to connect to backend servers to ensure that servers are listening. 

## LB Methods
1. **Least Connection Method:** 
    * Directs traffic to server with **least active connections**
    * **Used When** there are large number of persistent client connections which are unevenly distributed between the servers.
2. **Least Response Time Method**: 
    * directs traffic to **fewest active connections** and the **lowest average response time** 
3. **Least Bandwidth Method**: 
    * directs traffic to server serving **least amount of traffic measured in megabits per second (Mbps)**
4. **Round Robin Method** : It cycles through a list og servers and sends each new request to the next server. 
    * **used when** Servers are of **equal specs** and not many persistent connections. 
5. **Weighted Round Robin Method**: It better handles servers with different **processing capabilities**. 
    * Each server is assigned a wt(int value)
    * Servers with higher weight receive more requests. 
6. **IP Hash**" Hash of IP address of client is calculated to redirect request to server. 

# Redundant Load Balancers 
* LB can be single point of failure to overcome this we can have a second load balancer which can be connected to form a cluster. 
* Each LB monitors health of other. And as both are equally capable if main fails then second can take over. 
![LB](./img/LB2.svg)

# Furhter Reading
[`What is load balancing`](https://avinetworks.com/what-is-load-balancing/)

<br/>

[`Architecting LB system`](https://lethain.com/introduction-to-architecting-systems-for-scale/)
