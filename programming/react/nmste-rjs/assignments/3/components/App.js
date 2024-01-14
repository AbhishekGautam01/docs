import React from 'react';
import ReactDOM from 'react-dom/client';

// Elements using React.createElement
var heading3 = React.createElement("h3", {id: "heading3-cE"}, "createElement: Heading3");
var heading2 = React.createElement("h2", {id: "heading2-cE"}, "createElement: Heading2")
var heading1 = React.createElement("h1", {id: "heading1-cE1"}, "createElement: Heading1")

var parentDiv = React.createElement("div", {className: "title"}, [heading1, heading2, heading3]);

// Creating Element using JSX
var headingDivJSX = (
    <div className='title'>
        <h1 id="jsx-h1">JSX Heading 1</h1>
        <h2 id="jsx-h2">JSX Heading 2</h2>
        <h3 id="jsx-h3">HSX Heading 3</h3>
        {/*  Composition of components*/}
        {heading3}
    </div>
)

// Functional Components
const Heading4 = () => (
    <h4>Heading Component 4</h4>
)

const HeadingDiv = () => (
    <div className='title'>
        <h1 id="jsx-h1">JSX Heading 1</h1>
        <h2 id="jsx-h2">JSX Heading 2</h2>
        <h3 id="jsx-h3">HSX Heading 3</h3>
        {/*  Composition of components*/}
        <Heading4 /> 
        <Heading4></Heading4>
        {Heading4()}
        {heading3}
    </div>
)
const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<HeadingDiv />);