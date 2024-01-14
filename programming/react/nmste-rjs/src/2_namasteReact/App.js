import React from 'react'
import ReactDOM from 'react-dom/client'

const heading = React.createElement("h1", {id: "heading"}, "Hello World from Namaste React");
const child = React.createElement("div", {id: "child"}, heading)
const child2 =  React.createElement("div", {id: "child2"}, heading)
const parent = React.createElement("div", {id: "parent"}, [child, child2])

const rootDiv = document.getElementById("root");
const root = ReactDOM.createRoot(rootDiv);
root.render(parent);