# Js for React
## Arrow Functions
```js
// Normal Way
export default function DoSomething(){

}

// In newer versions of JS : Arrow functions
// we can use const(recommended) , let var
// Useful for callback functions.
export const DoSomething1 = () => {

}

//React
const myComponent = () => {
    return <div>Hi There!</div>
}

//Anonymous function
<button onClick = {() => {console.log("clicked")}}>Click me!</button>
```

## Ternary Operator and Conditionals
```js
// React allows to write js in JSX(~modified HTML)

let age = 16;
let name = (age > 10) && "Abhishek"; // if age greater than 10 then do name= Abhishek
let name = (age > 10) || "Abhishek"; //if age is not greater than 10 then do name = Abhishek

let name = age > 10 ? "Abhishek" : "Gautam";

const myComponent = () => {
    return (age > 10 ) ? <div>Abhishek</div> : <div>Gautam</div>;
};

let myAge = 17;
let isOfAge = false;

(condition) ? (when true): (when false)
isOfAge = myAge > 17 ? true: false;

let color = "green";
let isCorrect = false;

color = isCorrect ? "green" : "red";
color = isCorrect && "green"; isCorrect then "green"
```

## Objects 
```js
// Destructuring objects
const name = "Abhishek"
const age = 20;
const person = {
    name:name,// when key value pair has same name then we do not have to repeat variable name.
    age
    isMarried: true
}

const {name, age, isMarried } = person;
console.log(name);
console.log(age);

// Copy object by changing only 1 single property. Using SPREAD
// person2 will be same as person 1 but age will be different
const person2 = {...person, age: 23}

const names = ["Abhishek", "Gautam", "Basavraj"]
const names2 = [...names, "Sourav"]
```

## 3 Functions of JS Array
```js

let names = ["Abhishek", "Gautam", "Basavraj", "Abhishek", "Abhishek"]

names.map((name) => {
    console.log(name)
    return name + "1"; //replaces current element with this.
})

//rendering lists in react.
names.map((name) => {
    return <h1>{name}</h1>
});

// search and filtering through lists.
names.filter((name) => {
    return (name !== "Abhishek") 
})
```

### Async, Await , Promises & Fetch

## DOM
* It is representation of web page. It is tree like structure. 
* React manipulates these elements of DOM. 
* React creates a virtual DOM which is used to determine the most efficient way to make changes to this virtual DOM. 
* JSX is used instead of actual HTML. 


## Import / Export
```js

const axios = require('axios');

//in react

import axios from 'axios';
export { anObject}
export const {anObject}
export default someObject;
```

## Optional Chaining
```js
const fetchData = async () => {
    const data = await fetch("imaginaryapi.com");
    const name = data.person.name; // in our app everything cannot be sequential and below line may run before the above completes. 

    const name = data.person?.name // it will only try to access name when the person exists. 
}
```

## Template Literals
```js
const fetchData = asyn (animalName) => {
    const data = await fetch(`imaginaryapi/com/search=${animalName}`)
}
```