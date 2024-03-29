import React, { useState, useEffect } from "react";

import RestaurantCard from "./RestaurantCard";
import Shimmer from "./Shimmer";
import { Link } from "react-router-dom";

const Body = () => {
  const [restaurants, setRestaurants] = useState([]); //Input Param is a state variable by react.
  const [filteredRestaurant, setFilteredRestaurants] = useState([]);
  const [searchText, setSearchText] = useState("");

  const handleSearchTextChange = (evt) => {
    setSearchText((prev) => {
      if (prev !== evt.target.value) return evt.target.value;
      return prev;
    });
  };

  const handleSearch = () => {
    const filteredRestaurant =
      searchText === ""
        ? restaurants
        : restaurants.filter((res) =>
            res.name.toLowerCase().includes(searchText)
          );
    setFilteredRestaurants(filteredRestaurant);
  };

  useEffect(
    () => {
      /**Call back function */
      console.log("useEffect is called.");
      fetchData();
    },
    [
      /**Dependency Array */
    ]
  );

  const fetchData = async () => {
    try {
      const data = await fetch(
        "https://www.swiggy.com/dapi/restaurants/list/v5?lat=28.5011314&lng=77.234377&is-seo-homepage-enabled=true&page_type=DESKTOP_WEB_LISTING"
      );
      // Check if the response status is okay (status code 200)
      if (!data.ok) {
        throw new Error(`Failed to fetch data. Status: ${data.status}`);
      }
  
      const json = await data.json();
      
      // Check if the expected data structure is present in the JSON response
      if (!json || !json.data || !json.data.cards[4] || !json.data.cards[4].card.card.gridElements.infoWithStyle.restaurants) {
        throw new Error('Unexpected data format in the response');
      }
  
      const jsonData = json.data.cards[4].card.card.gridElements.infoWithStyle.restaurants;
      const projectedData = jsonData.map((item) => ({
        id: item.info.id,
        name: item.info.name,
        cloudinaryImageId: item.info.cloudinaryImageId,
        costForTwo: item.info.costForTwo,
        cuisines: item.info.cuisines,
        avgRating: item.info.avgRating,
      }));
  
      console.log(projectedData)
      setRestaurants(projectedData);
      setFilteredRestaurants(projectedData);
    } catch (error) {
      console.error('Error fetching data:', error.message);
      // You can also handle the error state here, e.g., set an error flag or show a user-friendly message.
    }
  };
  

  return (
    <div className="body">
      <div className="filter">
        <div className="search">
          <input
            type="text"
            className="search-box"
            value={searchText}
            onChange={handleSearchTextChange}
          />
          <button onClick={handleSearch}>Search</button>
        </div>
        <button
          className="filter-btn"
          onClick={() => {
            const filteredList = restaurants.filter((res) => res.avgRating > 4);
            setFilteredRestaurants(filteredList);
          }}
        >
          Top Rated Restaurants
        </button>
      </div>
      <div className="res-container">
        {filteredRestaurant.length > 0 ? (
          filteredRestaurant.map((restaurant) => (
            <Link to={"/restaurants/" + restaurant.id}>
              <RestaurantCard key={restaurant.id} resDetail={restaurant} />
            </Link>
          ))
        ) : (
          <Shimmer />
        )}
      </div>
    </div>
  );
};

export default Body;
