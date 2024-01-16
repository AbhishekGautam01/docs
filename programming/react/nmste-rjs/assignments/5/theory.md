# Assignment 5: Lets get hooked
* **What is the difference between Named Export, Default export and * as export?**
  * Named export: Using this we can expose multiple variables, function & classes from a module and import them by their names.
  * Default Export: A module can have only 1 default export, which is primary export of module. 
  * The * as syntax allows you to import all exports from a module as properties of an object. This is known as a namespace import. 
    ```js
    // module.js
    export const foo = () => 'foo';
    export const bar = () => 'bar';

    // another file
    import * as myModule from './module.js';
    // Usage: myModule.foo(), myModule.bar()
    ```

<br/>

* **What are React Hooks?**
  * React Hooks are functions that allow functional components in React to use state and lifecycle features that were previously only available in class components. They were introduced in React 16.8 to provide a more direct and concise way of working with component state and side effects in functional components.
  * The two most commonly used React Hooks are useState and useEffect, but there are others that serve various purposes. 
<br/>

* **useState**: It add state to functional components. it returns an array with two elements. the current state and a function that lets you update it.
  * state is a piece of data which a react component manages. 
  * **The useState hook allows to have a state in Functional Component**
    * **State in Functional Component**: useState allows functional components to have their own state.
    * **Multiple state variables**: We can use the useState hook multiple times in a component to manage different pieces of state independently. 
    * **Automatic State Merging**: `setCount(prevCount => prevCount + 1)`
    * It allows us to update state based on previous state as well. 