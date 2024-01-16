# Theory
* **Is JSX Mandatory for React?**
  * No it is not mandatory but it makes it easier to develop the react components
<br/>

* **Is ES6 Mandatory for react?**
* ES6 is not mandatory for react but it is highly recommended and widely used in react community. 
<br/>

* **Comments in JSX**
  * `{/* */}`
<br/>

* **<React.Fragment></React.Fragment> and <></>**
* * both of these are used to fragments which are a way to group multiple elements without introducing an additional DOM element. 
* This is useful when you want to return multiple elements from a component but you don't want to add an extra wrapper element to the dom.
* <React.Fragment></React.Fragment> - is available since React 16.2
* <></>: This is short hand for above which was introduced later.
<br/>

* **Virtual DOM**
  * It is an concept where "virtual" representation of UI is kept in memory and synched with real DOM by a library such as ReactDOM. 
  * This is called **Reconciliation**
  * We tell react what state you want UI to be in and react ensures the DOM matches the state. 
  * VirtualDOM is usually associated with React Elements. 
  * React also users `fibers` to hold additional information about component tree.
<br/>

* **Is shadow DOM same as Virtual DOM?**
  * No they are different. The shadow DOM is a browser technology designed primarily for scoping variables and CSS in web components. The virtual DOM is a concept implemented by libraries in JS on top of browser APIs
<br/>

* **What is React Fiber?**
  * It's ongoing re implementation of React's core algorithm. 
  * Fiber is new reconciliation engine in React 16. Its main goal is to enable incremental rendering of the virtual DOM.
  * The goal is to increase its suitability for areas like animation, layout and gesture. 
<br/>

* **What is React Reconciliation?**
  * It is the process through which React updates the browser DOM. It makes the DOM updates faster in React. It updates the virtual DOM first and then uses the diffing algorithm to make efficient and optimized updates in the Real DOM. 
  * React stores a copy of browser DOM which is called virtual DOM
  * When we make changes or add data, react creates a new Virtual DOM and compares it with the previous one. 
  * Comparison is done by **Diffing algorithm**. These comparison takes places in the browser.
  * After comparing, React goes ahead and creates a new Virtual DOM having changes. It is to be noted that as may as 200,000 virtual DOM notes can be produced in a second.
  * Then it updates the browser DOM with the least number of changes possible without rendering the entire DOM again. 
<br/>

* **Why we need keys in React? When do we need keys in React?**
  * Keys are used to identify and track individual elements within a collection (array or list) of JSX elements. They are crucial for efficient updates and rendering in react element. It is used to:
    * Identify elements
    * Optimizing rendering performance
    * preventing component state loss
    * maintaining component identity
    * 