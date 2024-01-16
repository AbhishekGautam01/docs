import React, { useState } from "react";

import RestaurantCard from "./RestaurantCard";
import resList from "../utils/mockData";

const Body = () => {
  let listOfRestaurant = [
    { id: 1, name: "Dominos", cuisine: "Burger, Fast Food", rating: 4.1 },
    { id: 2, name: "KFC", cuisine: "Burger, Fast Food", rating: 4.1 },
    { id: 3, name: "McD", cuisine: "Burger, Fast Food", rating: 3.8 },
  ];

  const [restaurants, setRestaurants] = useState(listOfRestaurant); //Input Param is a state variable by react.

  return (
    <div className="body">
      <div className="filter">
        <button className="filter-btn" onClick={() => {
            const filteredList = restaurants.filter((res) => res.rating > 4);
            setRestaurants(filteredList);
        }}>
          Top Rated Restaurants
        </button>
      </div>
      <div className="res-container">
        {restaurants.map((restaurant) => (
          <RestaurantCard key={restaurant.id} resDetail={restaurant} />
        ))}
      </div>
    </div>
  );
};

export default Body;
