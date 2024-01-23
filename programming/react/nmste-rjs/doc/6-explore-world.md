# Explore the world
* Some pre-requisite concepts:
  * Monolith Architecture: Everything is in a single service.
  * Microservices:
    * Different services for different jobs. All combined together formed a big app. 
    * This achieves separation of concern and single responsibility principle. 

## Fetching data
* Approach 1: As soon as Page load make API call and render the UI. If API takes 500ms, page will load with delay of 500ms
* Approach 2: As soon as page load , render the UI then make the API call and re-render our app with the API data.

* In our project we use Approach 2 and this gives better UX. 

## useEffect Hook
  
* Syntax: `useEffect(() => {/**Call back function */}, [/**Dependency Array */])`
* The callback function will call after the component is rendered.  
* Our browsers don't allow us to call api's from one origin to another origin by default. 
* To by pass this CORS use web extension
* **While data is loading we use shimmer UI - load a fake page like skeleton of website.**
* Whenever state variable changes react triggers a reconciliation cycle and react re renders the variable. 
* So when our component first renders then api is called and set restaurant is called which updates state and again body is called. 
* React will re render the entire component and but the dom update will be efficient due to react's reconciliation process. 
* Rendering according to condition like rendering based list is empty or not that is called **conditional rendering**.
* In Below code on each key press in search box , react will re render the entire component
```js
import React, { useState, useEffect } from "react";

import RestaurantCard from "./RestaurantCard";
import Shimmer from "./Shimmer";

const Body = () => {
  const [restaurants, setRestaurants] = useState([]); //Input Param is a state variable by react.
  const [searchText, setSearchText] = useState('');

  const handleSearchTextChange = (evt) => {
    setSearchText((prev) => {
      if(prev !== evt.target.value)
        return evt.target.value;
      return prev;
    })
  }

  useEffect(
    () => {
      /**Call back function */
      console.log("useEffect is called.");
      fetchData();
    },
    [
      /**Dependency Array */
    ]
  );

  return (
    <div className="body">
      <div className="filter">
        <div className="search">
          <input type="text" className="search-box"  value={searchText} onChange={handleSearchTextChange}/>
          <button onClick={() => {
            //filter the restaurant cards and update the UI
            console.log(searchText)
          }}>Search</button>
        </div>
      </div>
    </div>
  );
};

export default Body;
```