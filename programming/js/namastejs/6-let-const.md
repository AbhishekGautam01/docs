# Let & Const

* **Let & Const declarations are hoisted but very differently from var declarations**
* Let & Const are in **temporal dead zone**
* Temporal dead zone is time between the variable is defined and initialized a value. When initialization happens then temporal dead zone ends. 

```js
console.log(b); // undefined because of hoisting
console.log(a); // error Reference: cannot access before initialization.
let a = 10;
var b = 100;
console.log(a); //10
```

* **How to known `variable a` was hoisted or not**
* When GEC executes initially in memory phase b was assigned undefined and memory in GEC and attached to global object.
* where as `a` is also assigned undefined but not stored in Global memory space and this is not accessible unless initialized. 
* [8:30]