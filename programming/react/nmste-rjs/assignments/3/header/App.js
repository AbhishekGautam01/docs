import React, {useState} from "react";
import ReactDOM from "react-dom/client";
import Header from "./components/Header";
import "./App.css";

const App = () => {

  // by default it is not async, it's works by closure.
  const [userInput, setUserInput] = useState('Search User...')

  return (
    <div className="App">
      <Header userInput={userInput} onUserInputChange={setUserInput}/>
      <div id="dummy-body">{}</div>
    </div>
  );
};

var root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App />);
