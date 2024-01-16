# Undefined vs Not Defined

* JS code is executed using GEC and created further Execution context and pushing to call stack 
* When all variables and function in memory creation phase, the variable gets a placeholder `undefined`
* Once the assignment of value line execute the value of var change from undefined to not defined
* undefined also takes up memory, this is kept until variable gets some value.

```js
var a;

console.log(a); //undefined

if(a === undefined){
    console.log("a is undefined");
}
```

* JS is loosely typed language that is it doesn't attach variable to any specific type. It is also known as **Weakly typed language**
```js
var a;
console.log(a); //undefined
a = 10;
console.log(a); //10
a = "hello world";
console.log(a); //hello world
```

* it is not advised to assign a variable `undefined` explicitly 