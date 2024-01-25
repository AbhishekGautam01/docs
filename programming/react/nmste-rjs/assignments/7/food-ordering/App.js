import React, { useState } from "react";
import ReactDOM from "react-dom/client";
import {createBrowserRouter, RouterProvider, Outlet} from "react-router-dom";

import Header from "./components/Header";
import Body from './components/Body';
import Error from "./components/Error";
import About from './components/About/About'
import Contact from "./components/Contact/Contact";
import { ResMenu } from "./components/Body";
import "./App.css";

const App = () => (
  <div className="app">
    <Header />
    <Outlet />
  </div>
);

const appRouter= createBrowserRouter([
  {
    path: "/",
    Component: App,
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
      },
      {
        path: "/restaurants/:resId",
        element: <ResMenu />
      }
    ]
  }
])

var root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<RouterProvider router={appRouter} />);
