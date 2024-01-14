import React from "react";
import ReactDOM from "react-dom/client";

// React.createElement - creates an object => Object => When Rendered on DOM => HTML Element.

// JSX(transpiled before reaching JS Engine so Browsers can understand.) - PARCEL -> using Babel
const jsxHeading = <h1 id="heading">Namaste React 🔥</h1>;

//React Functional Component
const Title = function () {
  return (<div id="container" className="head">
    <h1>Namaste React Functional Component🔥</h1>
  </div>)
};


const number = 10000;
// React Element
const elem = (<span>React Element</span>)
const subTitle = (<h2>{elem} Namaste React from Subtitle</h2>)
// Rendering a React Functional Component with in another component
const HeadingComponent = () => (
  <div id="container">
    <Title />
    <h2>{number*2}</h2>
    {subTitle}
    <h1>Namaste React Functional Component🔥</h1>
  </div>
);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<HeadingComponent />);

/*
    This will fail because this is how we pass React Elements however it is a functional component so we have to do it like above.
    root.render(HeadingComponent)
*/ 