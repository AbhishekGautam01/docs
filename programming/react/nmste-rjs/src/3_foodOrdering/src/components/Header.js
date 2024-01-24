import React, { useState } from "react";
import { LOGO_URL } from '../utils/constants'
import { Link } from "react-router-dom";

const Header = () => {

  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const handleIsLoggedInToggle = () => {
    setIsLoggedIn((prev) => !prev);
  }

  return (
    <div className="header">
      <div className="logo-container">
        <img
          className="logo"
          src={LOGO_URL}
        />
      </div>
      <div className="nav-items">
        <ul>
          <li><Link to="/">HOME</Link></li>
          <li><Link to="/about">About Us</Link></li>
          <li><Link to="/contact">Contact</Link></li>
          <li>Cart</li>
          {
            (isLoggedIn ? 
              <button className="login" onClick={handleIsLoggedInToggle}>Logout</button> :
              <button className="login" onClick={handleIsLoggedInToggle}>Login</button>
              )
          }
        </ul>
      </div>
    </div>
  );
};

export default Header;