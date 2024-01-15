# Function Invocation and variable assignment

* Consider below code:

```js
var x = 1;
a(); // 10
b(); // 100
console.log(x); //1

function a() {
    var x = 10;
    console.log(x);
}

function b() {
    var x = 100;
    console.log(x);
}
```

* Firstly global execution context is created then memory phase will happen
| Memory(Variable Environment) | Code | 
| :---: | :---: |
| x: undefined | | 
| a: function a() {...} | |
| b: function b() {...} | | 

<br/>

| Call Stack | 
| :---: | 
| GEC | 

* Phase 2 Code Execution Phase. Al L1 1 will replace undefined over here
* Al L2 a() invocation Happens a new Execution context is created and Memory Phase & Code phase will happen, so x inside function a will be independent of everything else . X in function() will be referenced from local memory in the new execution context.

| Memory(Variable Environment) | Code | 
| :---: | :---: |
| x: 1 | | 
| a: function a() {...} | |
| b: function b() {...} | | 

<br/>
| Call Stack | 
| :---: | 
| GEC | 
| a() (TOP) | 

* After the a() is completed the call stack top record is popped and because GlobalExecutionContext was at L2 when the new ExecutionContext was created so the control will resume from there and a new ExecutionContext will be created for b() and pushed to call stack