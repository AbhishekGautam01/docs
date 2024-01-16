# Window & this

* Even if we run the empty js file then GEC(Global execution context) is created and js also created `window`
* These variables are created in global space. 
* `this` points to window object.
* Window is global object along with global execution context is created. 
* And this points to window object.
* All js engines have responsibility to create this windows object.
* window object will create in browser, in node it will be a different variable
* `this === window` - true at global level.

* **Global Space**: Any code which is not in any inside any function is global space.
* Any var or func created in global space will attach to global object - `window`. 
* when we try to access any program and dont put anything in start it will assume it is in global space.
```js
var a = 10;
function b(){
    var x = 10;
}

console.log(window.a)
console.log(a)
console.log(this.a) // 10 as this point to window object
```