
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