# HeartBeat
* In a distributed system there are many many servers
* Each server in the system needs to know what other servers are part of system
* Also they want to know if other servers are **Alive or Not**
* **Timely detection of failure is very important.**
* This can help take corrective actions or move workload to other systems

<br/>

* Each server periodically sends a heartbeat message to a central monitoring server or other servers in the system to show it's liveliness. 
* There can be a central monitoring server to which periodically keep sending the heartbeat.
* If any server fails to send data within configured timeout period then it is considered not alive, and requests are not send to it. 