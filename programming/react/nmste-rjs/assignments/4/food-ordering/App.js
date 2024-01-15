import React, { useState } from "react";
import ReactDOM from "react-dom/client";

import Header from "./components/Header";
import "./App.css";

const App = () => (
  <div className="app">
    <Header />
  </div>
);

var root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App />);
