import React from "react";
import ReactDOM from "react-dom/client";

const Header = () => {
  return (
    <div className="header">
      <div className="logo-container">
        <img
          className="logo"
          src="https://png.pngtree.com/png-vector/20220623/ourmid/pngtree-food-logo-png-image_5297921.png"
        />
      </div>
      <div className="nav-items">
        <ul>
          <li>HOME</li>
          <li>About Us</li>
          <li>Contact</li>
          <li>Cart</li>
        </ul>
      </div>
    </div>
  );
};

const RestaurantCard = (props) => {
    return (
        <div className="res-card">
            <img className="res-logo" src="https://www.licious.in/blog/wp-content/uploads/2020/12/Hyderabadi-chicken-Biryani.jpg" alt="res-logo" />
            <h3>{props.resName}</h3>
            <h4>{props.cuisine}</h4>
            <h4>4.4 Stars</h4>
            <h4>38 mins</h4>
        </div>
    )
}

const Body = () => {
    return (
        <div className="body">
            <div className="search">
                Search
            </div>
            <div className="res-container">
                <RestaurantCard resName="Meghana" cuisine="Burger, Fast Food"/>
            </div>
        </div>
    )
}


const AppLayout = () => {
  return (
    <div className="app">
      {/* Header */}
      <Header />
      { /* Body */}
      <Body />
    </div>
  );
};

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<AppLayout />);
