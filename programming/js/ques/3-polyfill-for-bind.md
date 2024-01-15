# Polyfill for Bind

* If browser doesn't have bind function here we have to add the bind function. 
```js

let name = {
    firstname:"Abhishek",
    lastname: "gautam"
}

let printName = function (){
    console.log(this.firstname + " " + this.lastname)
}

let printMyName = printName.bind(name);
printMyName(); // Abhishek Gautam


// OWN Method of Bind
// Every one should have access to myBind() method as bind() is also accessible to all the methods. 
// We have to use Function.prototype
// myBind should return a function which can be further called.
// If we call this function the method should be executed
// ..args will be array of args passed.
Function.prototype.mybind = function(...args) {
    let func = this; // point to instance on which myBind will be called.
    params = args.slice(1); //Remove first arg and return rest
    return function(...args2) {
        //[...arr1, ...arr2] - Array concatenation method
        func.apply(args[0], [...params, ...args2]); // apply method as param is an array and array cannot be passed as 2nd arg in bind.
    }
}


let printMyName1 = printName.myBind(name);
printMyName1(); // Abhishek Gautam

```
* **Question**
