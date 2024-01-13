# State in React

## Using Events
* [List of All React Events](reactjs.org/docs/events.html) -- All react events.
* Decide what kind of event you want to watch for 
* Create a function, usually called an event handler or call back function
* Name the function using pattern of handle + EventName 
* Pass the function as a prop to plain element. 
* Make sure you pass the function using a value event name like onClick, onMouseOver etc
* Make sure you pass a reference to the function and not call it. We don't put () around function name as we donot want to immediately call it but we want that function to be called on a certain event that happens. 

## Introduction to State System
* Data that changes as the user interacts with our app. 
* When this data changes, react will update content on the screen automatically. 
* This is the one-and-only way we can change what content react shows. Even other libs that appear to update content use the state system behind the scenes. 
* We can use any number of useState calls. 
* Whenever state changes always the re rendering happens.
  
```js
import {useState} from 'react'; // import from react.

function App(){

    // Array destructuring [Piece of state, setter function] = useState(initial value)
    const [count, setCount] = useState(0);

    //Event Handler or Event Callback function
    const handleClick = () => {
        setCount(count + 1);
    };

    return (<div> 
        <button onClick={handleClick}> Add Animal</button>
        <div> Number of animals: {count}</div>
        </div>)
}

export default App;
```

### Understanding Re-Rendering
* First time component is rendered : React looks at useState line and this is first time call of this and 0 is taken as default value and assigned to the count variable. 
* As soon as we click setCount with (0+1) is called and almost instantly re rendering happens and 2nd time App() func component is called and this time we dont use the default value and now count = 1;
* Now on next click component is called 3rd time and components is rendered with new value. 
* 