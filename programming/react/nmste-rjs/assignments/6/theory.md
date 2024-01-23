# Assignment 6

1. **What is a microservices?**
   1. Microservices is an application architecture in which the services are broken into much smaller services ideally handling a single domain in the business, having their own resources and dependencies. 
<br/>

2. **What is a monolith?**
   1. It is the old way of building the application, in which all the various components of application are part of the same solution. 
<br/>

3. **WHat is useEffect Hook and why do we need them?**
   1. The word effect comes from the term side effect. 
   2. Most of react is intended to be pure function. Where the input to these functions are given through `props`.
   3. `useEffect` is a predefined hook that handles the effect of the dependency array. It is called every time any state in the dependency array is modified or updated. 
   4. It is used to handle side effects in React such as fetching data and updating the DOM. 
   5. This hook runs on every render but there is also a way of using a dependency array using which we can control the effect of rendering. 
   6. If the dependency array is empty then the `useEffect` will run only once and never after that in component life cycle.
   7. To run 
      1. useEffect on every render: don't pass any dependency array
      2. useEffect only once - pass an empty array as dependency.
      3. to run useEffect on change of a particular value , pass the state and props in the dependency array
   8. **Why Use?**
      1. fetch data asynchronously and update the state when data is available
      2. Can be used to mimic the lifecycle operations of class components
      3. Can be used to setup and clean event listeners
<br/>

4. **What is optional chaining?**
   1. The optional chaining (?.) operator accesses an object's property or calls a function. If the object accessed or function called using this operator is undefined or null, the expression short circuits and evaluates to undefined instead of throwing an error.
<br/>

5. **WHat is simmer UI?**
   1. A shimmer UI, often referred to as a "shimmer effect," is a visual technique used in user interfaces to indicate that content is loading or being fetched. It is a subtle animation that provides a temporary placeholder for content while the actual data is being loaded in the background. 
<br/>

6. **What is difference between JS expression and JS statement?**
   1. Js expression isa piece of code that produces a value. 
   2. It can be a simple value ef a literal or variable or a combination of values and operators.
   3. A JS statement is a larger unit of code that performs an action. It doesn't necessarily produces a value. 
<br/>

7. **What is conditional rendering?**
   1. Conditional rendering is loading elements in UI based on some criteria 
<br/>

8. **What is CORS?**
   1. Cross origin resource sharing - It is a browser policy, it is a security feature implemented by web browsers to control the requests made by web pages from one domain to resources on another domain. 
<br/>

9. **What is Async and Await**
   1.  Async , Await are keywords that are used in conjunction with promises to simplify the handling of async operations. 
   2.  A async function will always returns a promise and it allows use of the await keyword with in its body. 
   3.  Await is used to pause the execution of the function until the promise is resolved or rejected. 
   4.  Async can be used to handle exceptions in a better way.
        ```js
        async function fetchData() {
        try {
            const result = await fetchDataFromServer();
            console.log(result);
        } catch (error) {
            console.error('An error occurred:', error);
        }
        }
        ```
    5. Promise chaining: Async await simplifies the syntax when dealing with multiple async operations. You can use it to chain async operations cleanly than using nested callbacks or Promise chaining. 
        ```js
        async function fetchData() {
        const result1 = await fetchDataFromServer1();
        const result2 = await fetchDataFromServer2(result1);
        console.log(result2);
        }
        ```
    6. It makes code more readable.
<br/>

10. **Adding error handling in API Call**
    ```js
    const fetchData = async () => {
    try {
        const data = await fetch(
        "https://www.swiggy.com/dapi/restaurants/list/v5?lat=28.5011314&lng=77.234377&is-seo-homepage-enabled=true&page_type=DESKTOP_WEB_LISTING"
        );

        // Check if the response status is okay (status code 200)
        if (!data.ok) {
        throw new Error(`Failed to fetch data. Status: ${data.status}`);
        }

        const json = await data.json();
        // Check if the expected data structure is present in the JSON response
        if (!json || !json.data || !json.data.cards[4] || !json.data.cards[4].card.card.gridElements.infoWithStyle.restaurants) {
        throw new Error('Unexpected data format in the response');
        }
    } catch (error) {
        console.error('Error fetching data:', error.message);
        // You can also handle the error state here, e.g., set an error flag or show a user-friendly message.
    }
    };
    ```