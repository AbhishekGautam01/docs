# Core React Questions

* **What is React?**
  * Open source front end JS library 
  * Build view layer for web and movile apps.
  * Uses JSX syntax 
  * Uses Virtual DOM
  * Supports SSR which is useful for SEO
  * Follows uni directional or one way data flow
  * reusable/composable UI
<br/>

* **What is JSX?**
  * Javascript XML - XML like extension syntax to ECMA script. 
<br/>

* **Element vs Component**
  * Element is a plain object describing what you want to display on screen in terms of react nodes. 
  * Elements can contain other elements in their props. 
  * Elements cannot be mutated 
  * Component takes props as input and returns a JSX tree as the output. 
<br/>

* **Pure Components**
  * Components which render the same output for the same state and props. 
  * We can achieve this through memoized `React.memo()`
  * This API prevents unnecessary re-renders by comparing the previous props and new props using shallow comparison
  * This will just compare props and not the state because state change may mean re-rendering.
<br/>

* **State in React**
  * It is information that may change over the lifetime of component. 
  * State is similar to props but it is private and fully controlled by the component i.e. it is not accessible to any other component till the owner component decides to pass it. 
<br/>

* **Props in React**
  * Inputs to the components passed by parent as single values or objects containing a set of values that are passed to components on creation similar to HTML tag attributes.
    * Pass custom data to your component
    * trigger state changes
<br/>

* **State vs Props**
  * both are JS objects and used to manage the data of component.
  * state is managed by component but props is managed by it's parent's component
<br/>

* **Why should we not update state directly?**
  * If you try to update the state directly then it won't re render the component
  * setState schedules an update to a component's state object. 
  * call back function is invoked when state change and finished and component gets rendered.
    ```js
    setState({ name: "John" }, () =>
    console.log("The name has updated and component re-rendered")
    );
    ```
<br/>

* **Passing callbacks**
  * Public class fields syntax `<button onClick={handleClick}>Signout</button>`
  * Arrow function in callbacks `<button onClick={() => handleClick()}>Signout</button>`
<br/>

* **Synthetic Events**
  *  React abstracts away the differences between browser implementations of events and provides a consistent interface for handling them. These synthetic events are instances of the `SyntheticEvent` object, which is a cross-browser wrapper around the native browser events.
<br/>

* **What is the use of refs?**
  * The *ref* is used to return a reference to the element. 
  * They should be avoided in most cases however they can useful when you need a direct access to the DOM element or an instance of a component. 
<br/>

* **How to create refs?**
  * Using React.createRef()
    ```js
    class MyComponent extends React.Component {
    constructor(props) {
        super(props);
        this.myRef = React.createRef();
    }
    render() {
        return <div ref={this.myRef} />;
    }
    }
    ```
<br/>

* **What is Virtual DOM and how does it work?**
  * It is an in memory representation of realDOM. 
  * The representation of UI is kept in memory and synced with the rel DOM. 
  * This entire process is called **reconciliation**
  * 3 Steps
    * Whenever an underlying data changes, the entire UI is re rendered in virtual DOM representation
    * Then the difference between the previous DOM representation and the new one is calculated.
    * Once the calculations are done, the real DOM will be updated with only the things that have actually changed.
<br/>

* **What is Shadow DOM?**
  * It is browser tech designed primarily for scoping variables and CSS in web components.
<br/>

* **What is react fiber?**
  * It is the new reconciliation engine , it increases the suitability for areas like animation, layout, gestures, ability to pause , abort and reuse work and assign priority to different types of updates.
<br/>

* **Controlled Components**
  * A component that controls the input elements within the forms on subsequent user input is called Controlled Component, i.e, every state mutation will have an associated handler function.
<br/>

* **What is lifting state up in react?**
  * When several components need to share the same changing data then it is recommended to lift the shared state up to their closest common ancestor. 
  * If 2 child share same data then move the state up into parent rather then both child maintaining their own state. 
<br/>

* **Higher Order Components**
  * It is a function that takes a component and returns a new component. 
  * It is a pattern that is derived from react's compositional nature. 
  * It can be used for 
    * Code reuse
    * render hijacking
    * state manipulation
    * props manipulation
  * `const EnhancedComponent = higherOrderComponent(WrappedComponent);`
<br/>

* **What is context?**
  * Context provides a way to pass data through the component tree without having to pass props down manually at every level
  * `const { Provider, Consumer } = React.createContext(defaultValue);`
<br/>

* **What is children components?**
  * It is a special prop that is used to pass components, elements or plain text as children to a react component. 
    ```js
    import React from 'react';
    const Box = ({ children }) => {
    return (
        <div className="box">
        {children}
        </div>
    );
    };
    const App = () => {
    return (
        <Box>
        <p>This is a paragraph inside the box.</p>
        <button>Click me</button>
        </Box>
    );
    };

    export default App;
    ```
<br/>

* **React.Lazy**
  * It is a react feature that allows you to load a component lazily i.e. only when it is actually needed.
  ```js
  import React, { lazy, Suspense } from 'react';

    // Import the component lazily
    const LazyComponent = lazy(() => import('./LazyComponent'));

    const MyComponent = () => {
    return (
        <div>
        <Suspense fallback={<div>Loading...</div>}>
            {/* Render the lazily loaded component */}
            <LazyComponent />
        </Suspense>
        </div>
    );
    };

    export default MyComponent;
  ```
  * It is used to create lazily loaded version of the lazy component.
  * `Suspense` is a fallback UI while the lazily loaded component is being loaded. 
<br/>

* **What are fragments?**
  * Fragment lets us group a list of children without adding extra nodes to the DOM. 
  * Fragments are a bit faster and use less memory by not creating an extra DOM node.
  * DOM inspector is less cluttered. 
<br/>

* **What are portals in React?**
  * Recommended way to render children into a DOM node that exists outside the DOM hierarchy
  * `ReactDOM.createPortal(child, container);`
<br/>

* **What are stateful components**
  * If the behavior of a component is dependent on the state of the component then it can be termed as stateful component. 
  * These stateful components are either function components with hooks or class components.
<br/>

* **What is the purpose of render method in `reactDOM?**
  * Method is used to render a react element in the DOM. 
  * `ReactDOM.render(element, container, [callback])`
  * The callback is optional; it runs when every time components is rendered or update.
<br/>

* **How to use Styles in react?**
  * This can be used by passing styles attribute. 
  * CSS properties are passed in camelCased. 
  ```js
    const divStyle = {
    color: "blue",
    backgroundImage: "url(" + imgUrl + ")",
  };

  function HelloWorldComponent() {
    return <div style={divStyle}>Hello World!</div>;
  }
  ```
<br/>

* **How events are different in React?**
  * React event handlers are named using camelCase, rather than lowerCase
  * With JSX you can pass a function as event handler rather than string.
<br/>

* **How do you conditionally render the components?**
  * JSX can take conditions and it doesn't render if something evaluates to false or undefined.
  * We can use `conditional short circuiting` i.e to display if something evaluates to true like :
    ```js
    const MyComponent = ({ name, address }) => (
      <div>
        <h2>{name}</h2>
        {address && <p>{address}</p>}
      </div>
    );
    ```
  * If we want to use if else then we can use a ternary operator
<br/>

* **Why we need to be careful when spreading props on DOM elements?**
  * When we spread props we run into the risk of adding unknown HTML attributes, which is a bad practice
  * We should de structure the props like const comp = ({isDisplay, ...restOfProps}) => {}
<br/>

* **Explain me the usage of React.memo**
  * It is a higher order component in react that is used to memoize a component and prevents unnecessary re renders. 
  * When a component is wrapped with React.memo it will only re render if the passed props changes. 
  ```js
  import React from 'react';

  const MyComponent = React.memo((props) => {
    // Component logic and rendering based on props
    return (
      <div>
        {props.name}
      </div>
    );
  });

  // Usage
  const App = () => {
    const data = { name: 'John' };

    return <MyComponent data={data} />;
  };  
  ```
<br/>

* **What is switching Components**
  * A component which can render more than 1 component on condition.
    ```js
    import HomePage from "./HomePage";
    import AboutPage from "./AboutPage";
    import ServicesPage from "./ServicesPage";
    import ContactPage from "./ContactPage";

    const PAGES = {
      home: HomePage,
      about: AboutPage,
      services: ServicesPage,
      contact: ContactPage,
    };

    const Page = (props) => {
      const Handler = PAGES[props.page] || ContactPage;

      return <Handler {...props} />;
    };

    // The keys of the PAGES object can be used in the prop types to catch dev-time errors.
    Page.propTypes = {
      page: PropTypes.oneOf(Object.keys(PAGES)).isRequired,
    };
    ```
<br/>

* **Why we need to pass function to `setState()**
  * setState is an async operation. 
  * React batches state change for performance reason.
  * The call back ensure you can also get the previous state to just be sure about the update
    ```js
      this.setState((prevState, props) => ({
    count: prevState.count + props.increment,
  }));
  // this.state.count === 3 as expected
    ```
<br/>

* **What are some pointer Events supported in React?**
  * Pointer Events provide a unified way of handling all input events.
    * OnPointerDown
    * OnPointerUp
    * OnPointerMove
    * OnPointerCancel
<br/>

* **Why component name should start with capital letter?**
  * If you are rendering your component using JSX, the name of that component has to begin with a capital letter otherwise React will throw an error as an unrecognized tag
<br/>

* **What are render props?**
  * Render Props is a simple technique for sharing code between components using a prop whose value is a function. 
  * The below component uses render prop which returns a React element.
  * `<DataProvider render={(data) => <h1>{Hello ${data.target}}</h1>} />`