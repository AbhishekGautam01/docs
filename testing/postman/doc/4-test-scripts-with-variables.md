# Test scripts using postman variables
* Postman variables are similar to variables in any programming language. 
## Types of Variables
    1. Global
    2. Environment 
    3. Local 
    4. Data
> **NOTE**: If the variable is in 2 different scope then the variable value is selected from scope which has highest priority. If var is in env and global then env will win as it is much narrow. 

* TO access saved variables in request builder the syntax is `{{myVariable}}`

![Overview](./img/variables-overview.png)

* If you hover over a variables then it will show it scopes
![scopes](./img/scopes.png)

## Accessing variables in the scripts

* `pm.globals.get("variable_key")`
* `pm.globals.set("variables_key, variable_value);`
* `pm.globals.unset("variable_key") // delete a variables`
* `pm.globals.clear() // delete all variables`

## Global Variables
* In Trello Create board API , when we create board we get a boardId which we need in subsequent calls and we need to automate this process of passing data between requests. 
![setting-global-variables](./img/setting-global-variables.png)
* Accessing global variables
![image.png](./img/accessing-global-variables.png)
* To delete a global variables `pm.globals.unset("boardId")`

> **NOTE**: It is good practice to delete the variable once you dont need it.

## Environment Variables
* Similar to global variables but with narrower scope. 
* Ideal for switching between between setups while still using same collection
* Same usage in the request builder as with global variable.

* You can create environments and have variables in them , then whichever environment you select based on that it will get the value of the variable. 

![environments](./img/environments.png)

* `pm.environment.get("variable_key")`
* `pm.environment.set("variables_key, variable_value);`
* `pm.environment.unset("variable_key") // delete a variables`
* `pm.environment.clear() // delete all variables`

## Pre-request scripts

* Similar to test scripts but with no assertions and run before request.
* Ideal for making your request dynamic and it is usually used in combination with variables. 
* **Pre-request script(eg calculate a timestamp and save it to a varibales) --> Http Request --> Test**
![pre-req scripts](./img/pre-request-scripts.png)

## Variables types
![variables-precedence](./img/variables-precedence.png)
* if we set same variable in global and environment then the value set in environment will be taken. 
* **Global Variables**: Variables ideal for quick results and prototyping. 
    * Avoid using this as much as possible 
    * Clear/remove variables once you do not need them 
    * Get variables in scripts using the scoped getter when working with global variables. `pm.variables.get()` 
> **NOTE** the method **pm.variables.get()** is advisable to use as this will figure out the correct scope of that variable , but if you use pm.global.get() and later you want to move those to environment variable you will have to do postman script changes. 
<br/>

* **Environment Variables**: Ideal for working with different servers
    * Storing environment specific information 
    * URLs , auth information can be stored here. 
    * Passing data to request is another use case for this variables. 

* **Collection Variables**: Tied to a single collection. It cannot be shared by multiple collection. 
    * This is a good alternative to environment variable if we have a single server
    * URLs / authentication credential if only one environment exists
    * **Setting a collection variable** : `pm.collectionVariables.set("name", value)`
    * **Getting a collection variable** : `pm.collectionVaribes.get("name")`

* **Data Variables**: Used when working with multiple data sets
    * Exist only during the iternation
    * They can be declared only by CSV or json file. 

## Setup different URL to test against different environments
* This can be done using the environments and environment variables. 
* Because postman won't tell which environment is active so it is good practise to have an env variable declared in all environments so you can do the testing easily and then you can check in your test and pre-scripts if right environemnt is active or not 

```js
if(pm.environment.get("env") === 'production'){
    // do something 
}
```

## Debugging tests
* if you want to see some values during test then you should write console.log() and then check the values in console output.