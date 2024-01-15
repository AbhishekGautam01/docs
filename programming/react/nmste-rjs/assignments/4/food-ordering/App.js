import React, { useState } from "react";
import ReactDOM from "react-dom/client";

import Header from "./components/Header";
import Body from './components/Body';
import "./App.css";

const App = () => (
  <div className="app">
    <Header />
    <Body />
  </div>
);

var root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App />);
