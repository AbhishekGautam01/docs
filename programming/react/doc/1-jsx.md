# JSX
## [Cheat Sheet JSX](https://jsx-notes.vercel.app/)
* index.js
```js
// 1) Import React & React DOM Lib
import React from 'react'; //Understand what a component it
import ReactDOM from 'react-dom/client'; // Understand to get a component and show up in the browser.

// 2) Get Reference of Div with Id root
const el = document.getElementById('root');

// 3) Ask react to take control of this element
const root = ReactDOM.createRoot(el);

/// 4) create a component
    let message = 'Bye there!';

    if(Math.random() > 0.5){
        message = 'Hello there!';
    }

    return <h1>{message}</h1>

// 5) Show the component on the screen
root.render(<App />); // Passing App as JSX element.
```

* JSX is transpiled into JS for it to be a valid JS by using babel.
* [Babel Repl](babeljs.io/repl) - Tool to show what your JSX is turned into
* To show any content we need it to be returned from the Component, else it will not be displayed on the screen.
* Curly braces in JSX means we are going to reference a JS variable or expression. `<h1>{message}</h1>`
* We often mostly use this curly braces with numbers and strings. eg react doesn't know how to render true, false, null , undefined if passed in curly braces. Passing objects will result in error.

## Shorthand Js Expression
* Curly braces can be used to write out js expressions 
```js
    return <h1>{message} - {new Date().toLocaleTimeString()}</h1>
```

## Component Layout
* Our components will always be like:
  * Function Declaration
  * Declaring variables
  * Code to compute values we want to show in our JSX
  * Content we want this component to show by returning JSX

## Props

* To our elements we can pass **props**. Below type, min, max are props short for properties.
```js
  return (<input type="number" min={5} max={5}/>);
```
* Props are different from html attributes. Props can refer to a variable using the same curly braces syntax.
  * Props which are strings should always be written in ""
  * Numbers in propers should always be written in {}
  * Array should be passed as {[1,2,3]}
  * Object:{{color: 'red}} -> out {} is JSX and inner {} is object properties.
  * Objects can be passed as props
```js
function App() {
    const inputType = 'number';
    const minValue = 5;
    const maxValue = 10;
  return (<input type={inputType} min={minValue} max={maxValue} style={{border: '3px solid red'}}/>);
}
```

## Converting HTML to JSX
* We should be able to use html attributes with some changes in JSX
* All Prop names follow camelCase
* Number attributes use curly braces
* Boolean 'true' can be written with just the property name. 'False' Should be written with the curly braces.
>  <input spellCheck> == spellCheck=true;
> <input spellCheck={false}>
* The `class` attribute is written as 'className'. class help with styling.
* In-line styles are provided as objects.
```js
  return (<textarea autoFocus={false} style={{textDecoration: 'none', padding: '5px'}}/>);
```

## Extracting Components
* App.js file will have code to create the components. 
* Index.js will only Show the App component.

## Create a new Components
* Create a new file. By covention file should start with a caps letter
* Make your component. Should be a function tht returns JSX
* Export the components at bottom of file
* Import the component into another file. 
* Render the component