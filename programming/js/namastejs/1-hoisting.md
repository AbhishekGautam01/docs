# Hoisting

* the process whereby the interpreter appears to move the declaration of functions, variables, classes, or imports to the top of their scope, prior to execution of the code.
* We are trying to access x and getName even before they are declared or initialized but it will work in JS.
* 
```js
getName(); // Namaste Javascript
console.log(x) // undefined
console.log(getName); // console logs the entire function body

var x = 7;

console.log(y) // Error: Y is not defined. Undefined and No Defined are different. Because y was not defined so in memory creation phase y would have not been found and assigned undefined value
function getName() {
    console.log("Namaste Javascript")
}

```
* Due to **Hoisting** we are able to access variable and functions even before it is initialized. 
* When we run our program the Execution context is being created, In `Memory Creation phase` each and every var func gets memory.
* Even before code starts running, memory is allocated to all variables and function.
* **Program Execution**
  * **Memory Creation**: X: undefined getname: f getName(){ console.log("Namaste Javascript")}

```js
getName(); // This will error will arrow function will behave as variable so in memory creation phase it will be assigned undefined. 
console.log(getName); // undefined
var getName = () => {

}

var getName2 = function () { //getName2 will behave like another variable and memory undefined will be allocated.

}
```