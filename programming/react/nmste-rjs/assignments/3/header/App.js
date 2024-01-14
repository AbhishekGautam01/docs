import React from 'react';
import ReactDOM from 'react-dom/client';
import { Header } from './components/Header/Header';
import './App.css';

const App = () => (
    <div className='App'>
       <Header />
    </div>
)

var root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App/>);