# Call, Bind & Apply method

* **Call**: Function Borrowing
```js
let name = {
    firstname: "Abhishek",
    lastname: "Gautam",
    printFullName: function (hometown, state){
        console.log(this.firstname + " " + this.lastname + hometown +  state);
    }
}

name.printFullName("delhi", "delhi"); // Abhishek Gautam Delhi

let name2 = {
    firstname: "Sachin",
    lastname: "Tendulkar"
}

// to give name2 printing capability we can use `CALL` method to do function borrowing from other method

// now inside name printFullName() `this` will point to name2;
// Function borrowing
name.printFullName.call(name2, "Mumbai", "Maharastra") // Sachin Tendulkar Mumbai
```
<br/>

* **Apply**: Only difference with call method is way we pass arguments. the argument apart from the first argument are passed as array list meaning the this argument is passed as it is and rest of arguments are passed as array list
```js
name.printFullName.Apply(name2, ["Mumbai", "Maharastra"])

```
<br/>

* **Bind**: it binds the method with object and returns the copy of object. It doesnt invoke the method unlike call and apply , using object we can call the method later
```js
let printFullName = function(hometown, state){
    console.log(this.firstName + this.lastname + hometown + state)
}
let printMyName = printfullName.bind(name2, "Mumbai", "maharastra");
printMyName();

```

* Interviewer can ask to write polyfill for this