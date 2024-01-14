# Assignment 1

* **What is Emmets**
  * Emmets are used for snippets and code expansion. 
  * Emmets are default enables in html, xsl, css, scss, sass.
  * emmet.includeLanguages - can be used to enable emmets for languages apart from the above ones.

* **Library vs Framework**
  * Both are re-usable code written by someone else. 
  * **Library**: A library is like going to Ikea. You already have a home, but you need a bit of help with furniture. You don’t feel like making your own table from scratch. Ikea allows you to pick and choose different things to go in your home. You are in control.
  * **Framework**: A framework, on the other hand, is like building a model home. You have a set of blueprints and a few limited choices when it comes to architecture and design. Ultimately, the contractor and blueprint are in control. And they will let you know when and where you can provide your input.
  * **Library** We are in charge of flow of application, we choose when and where to call library function
  * **Framework** It is in charge and provides us places to plug in our code but the code is called by plugin.


* **CDN?**
  * Content Delivery Network
  * Distributed network of server strategically located around the world to deliver web content such as images, videos, stylesheets & scripts to user based on geographical location. 
  * **GOAL**: Improve performance, reliability & scalability by reducing latency and distributed load
  * **Usage**
    * Faster Content Delivery
    * Load Balancing
    * DDoS Mitigation
    * Scalability
    * Improved Website Security
    * Global Presence
  * CDN uses load balancing to choose a server for user:
    * DNS Resolution: User req goes to DNS server, DNS server resolves domain name to an IP address.
    * Geographical Proximity: Based on user IP address the CDN aims to direct user's request to nearest edge server(**PoPs - Point of Presence**)
<br/>

* **Why is react known as react?**
  * Because it reacts quickly to the change without reloading the whole page. It uses the virtual DOM to efficiently update parts of a webpage. 
<br/>

* **crossorigin in script tag?**
  * It is used to define how the browser should handle requests for cross-origin(from different domain). This is useful for loading scripts from different server. 
  * This is used in conjunction with the `integrity` attribute for script integrity checking.
    * `Anonymous`: This is default value. This is suitable for scripts that don't need any cookies. Scripts are fetched without any credentials.
      * `<script src="https://example.com/script.js" crossorigin="anonymous"></script>`
    * `Use Credentials`: The script requires authentication. `<script src="https://example.com/script.js" crossorigin="use-credentials"></script>`

* **What is React and ReactDOM?**
  * React provides the tools and concepts to define component-based user interfaces. 
  * ReactDOM handles the task of rendering those interfaces in a web environment.
<br/>

* **● What is difference between react.development.js and react.production.js files via CDN?**
  * In production mode, compression and minification of JS & other resources happens to reduce the size of the code which is not in case with development mode. 
  * Performance will be faster in production mode.
<br/>

* **Async vs Defer(Ola Interview Question)**
  * these are boolean attributes used along with script tag to load external scripts efficiently
  * When we load web page
    * HTML Parsing
    * Script loading
      * Fetching the script
      * Executing it line by line
 * **Normal Script Tag**:  `<script src="" />` When browser is parsing html line by line and encounters the script tag then it stops and fetches the script from the network and then execute it then and there and then html parsing will resume after script is fully executed.
 * **Async Script Tag**: `<script async src =""  />` - While html parsing is going on, the scripts are fetched from network asynchronously. As soon as the scripts are available then the parsing stops and scripts are executed and then on completion html parsing resume
 * **Deferred Script Tag**: `<script defer src="" />` While html parsing is going on the script are fetched from network, and these scripts are only executed when the parsing of html is fully completed.
* Async attribute does not guarantee the order of execution but deferred does guarantee the order of execution
* **When to use what?**
  * When we want order of execution to be same then defer is best
  * When we want to load external scripts and order of execution does not matter then async should be used.