# Finding the Path
* We will be using a routing library. 
* `useEffect` is a named import from react
  * It takes a callback function and a dependency array. 
  * This is called after every render of the component Because of dependency array this behavior will change.
  * If no dependency array - useEffect is called on every component render. 
  * If an empty dependency array is passed - useEffect is called on only initial render. 
  * If we put something in dependency array so then useEffect will only be called when dependency array is changed. 
* `useState` - never use useState outside body of your component. 
  * useState is used for creating local state creating inside your component. 
  * Always try to place it on the top of the function body declaration. 
  * Never create your useState inside if Else statement/for loops or inside some function.  

## React Router DOM - React Routing
* Installing in the code `npm i react-router-dom`
* import { createBrowserRouter} from "react-router-dom"// helps us to create routing configuration. 
* Configuration
  ```js
  const appRouter = createBrowserRouter([
    {
        path: "/",
        element: <AppLayout />,
        errorElement: <Error />

    },
    {
        path: "/about",
        element: <About />
    }
    ])
  ```
* RouterProvider import will provide the router to the App. 
* `root.render(<RouterProvider router={appRouter} />);`
* There are many types of router this library provides us like browser router, hash router, memory router , static router.
* But createReactRouter is the recommended by react team. 
* React Router DOM - Also handles route miss and display an error page. 

## Creating own error page
```js
const appRouter = createBrowserRouter([
  {
    path: "/",
    element: <AppLayout />,
    errorElement: <Error />
  },
  {
    path: "/about",
    element: <About />
  },{
    path: "/contact",
    element: <Contact />
  }
])

```

* Router gives us access to hook `useRouteError` from "react-router-dom" 
* This can be used to show more error in screen.
* Error Sample `{"status":404,"statusText":"Not Found","internal":true,"data":"Error: No route matches URL \"/sjkdsjksd/jsdnjds\"","error":{}}`

```js
import React from "react";
import { useRouteError } from "react-router-dom";

const Error = () => {
    const err = useRouteError();
    console.log(JSON.stringify(err));
    return (
        <div>
            <h1>Oops!!!</h1>
            <h2>Something went wrong!!</h2>
            <h3>{err.status}: {err.statusText}</h3>
        </div>
    )
}

export default Error;
```

## Creating Children Routes inside our app
* Like about page should load inside Body component. 
* Header should always stay. 
* Using Outlet - `import {createBrowserRouter, RouterProvider, Outlet} from "react-router-dom";`
* We define the children property in router configuration
```js
const appRouter = createBrowserRouter([
  {
    path: "/",
    element: <AppLayout />,
    errorElement: <Error />,
    children: [
      {
        path: "/",
        element: <Body />
      },
      {
        path: "/about",
        element: <About />
      },
      {
        path: "/contact",
        element: <Contact />
      }
    ]
  }
])
```
* And Adding the <Outlet /> in my JSX
```js
const AppLayout = () => {
  return (
    <div className="app">
      {/* Header */}
      <Header />
      {/** Whenever there is change in the path then this outlet will be filled with the children inside this Outlet. */}
      <Outlet />
    </div>
  );
};
```

## Adding routing links
* When using react never ever use an anchor tag for routing because when routing happens the whole page will refresh while using anchor tag
* We use a <Link /> from react router dom
* `<li><Link to="/contact">Contact</Link></li>`
* Because this routing doesn't refresh the whole page this is why we call it a single page application. 

## Routing in web apps
* **Client Side Routing**
  * Client side routing supports the SPAs.
* **Server Side Routing**
  * Routing happens from server and comes back to UI and displayed

## Dynamic Routing
* This is used to define dynamic parts of the routing
* `path: "/restaurants/:resId"`
* To read this in component use hook - `useParams` - `const {resId}= useParams();`
* Passing the params from the Parent component
```js
<Link to={"/restaurants/" + restaurant.resId}>
    <RestaurantCard key={restaurant.id} resDetail={restaurant} />
</Link>
```
* Link internally uses a anchor tag but react router dom keeps a track of this link. 