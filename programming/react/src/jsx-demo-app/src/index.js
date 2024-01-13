// 1) Import React & React DOM Lib
import React from "react"; //Understand what a component it
import ReactDOM from "react-dom/client"; // Understand to get a component and show up in the browser.
import App from './App';

// 2) Get Reference of Div with Id root
const el = document.getElementById("root");

// 3) Ask react to take control of this element
const root = ReactDOM.createRoot(el);

// 4) Show the component on the screen
root.render(<App />); // Passing App as JSX element.
