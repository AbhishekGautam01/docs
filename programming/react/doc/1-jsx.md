# JSX

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