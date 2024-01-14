import React from 'react';
import ReactDOM from 'react-dom/client';


// 1) Creating a h1 tag by using core React APIs
const heading = React.createElement(
  "h1",
  { id: "heading" },
  "Hello World! from React"
);

const paragraph = React.createElement("p", {id: "paragraph"}, "I am a paragraph")

const child = React.createElement("div", {id: "child"}, [heading, paragraph]);
const child2 = React.createElement("div", {id: "child2"}, [heading, paragraph]);

const parent = React.createElement("div", {id: "parent"}, [child, child2])
//2) Creating the root element.
const root = ReactDOM.createRoot(document.getElementById("root"));

//3) Rendering the heading inside root
root.render(parent);
