import React, { useState } from "react";
import { LOGO_URL } from '../utils/constants'
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
          <li>HOME</li>
          <li>About Us</li>
          <li>Contact</li>
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