import React, { useState, useEffect, Fragment } from "react";
import { Link } from "react-router-dom";

import Search from "../Search";
import RestauntCard from "./RestauntCard";
import styles from "./RestaurantContainer.module.css";

const RestaurantContainer = () => {
  const [userSearchInput, setUserSearchInput] = useState("");
  const [restaurants, setRestaurants] = useState([]); //Input Param is a state variable by react.
  const [filteredRestaurant, setFilteredRestaurants] = useState([]);

  useEffect(() => {
    console.log("filtering");
    filterRestaurants();
  }, [userSearchInput]);
  useEffect(() => {
    console.log("useEffect is called.");
    fetchData();
  }, []);

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
      if (
        !json ||
        !json.data ||
        !json.data.cards[4] ||
        !json.data.cards[4].card.card.gridElements.infoWithStyle.restaurants
      ) {
        throw new Error("Unexpected data format in the response");
      }

      const jsonData =
        json.data.cards[4].card.card.gridElements.infoWithStyle.restaurants;

      const projectedData = jsonData.map((item) => ({
        id: item.info.id,
        name: item.info.name,
        cloudinaryImageId: item.info.cloudinaryImageId,
        costForTwo: item.info.costForTwo,
        cuisines: item.info.cuisines,
        avgRating: item.info.avgRating,
      }));

      setRestaurants(projectedData);
      setFilteredRestaurants(projectedData);
    } catch (error) {
      console.error("Error fetching data:", error.message);
      // You can also handle the error state here, e.g., set an error flag or show a user-friendly message.
    }
  };

  // Function to filter restaurants based on userSearchInput
  const filterRestaurants = () => {
    if (!userSearchInput) {
      setFilteredRestaurants(restaurants); // If no search input, display all restaurants
    } else {
      const filtered = restaurants.filter((restaurant) =>
        restaurant.name.toLowerCase().includes(userSearchInput.toLowerCase())
      );
      setFilteredRestaurants(filtered);
    }
  };

  return (
    <React.Fragment>
      <Search
        userSearchInput={userSearchInput}
        onUserSearchInputChange={setUserSearchInput}
      />
      {`User is Currently applying search ${
        userSearchInput === null ||
        userSearchInput === undefined ||
        userSearchInput.trim() === ""
          ? "No Filter"
          : userSearchInput
      }`}
      <div className={styles.resContainer}>
        {filteredRestaurant.map((item, index) => (
          <Link style={{textDecoration: 'none', color: 'inherit'}} to={"/restaurants/" + item.id}>
            <RestauntCard  key={item.id} restaurant={item} />
          </Link>
        ))}
      </div>
    </React.Fragment>
  );
};

export default RestaurantContainer;
