import React, { useState } from 'react';

import RestauntCard from './RestauntCard';
import styles from './RestaurantContainer.module.css';

const RestaurantContainer = ({ userSearchInput }) => {
  const [filteredRestaurants, setFilteredRestaurants] = useState([]);

    const restaurants = [
        { name: 'Meghana Biryani', img: 'https://static.wixstatic.com/media/6a16b4_17633e8c4de34a61a8048cdb59e2a275~mv2.png/v1/fill/w_480,h_316,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/6a16b4_17633e8c4de34a61a8048cdb59e2a275~mv2.png', starRating: 3, cuisines: ["biryani", "north indian"], deliveryTime: "30m"},
        { name: 'KFC', img: 'https://www.freepnglogos.com/uploads/kfc-png-logo/camera-kfc-png-logo-0.png', starRating: 4.1, cuisines: ["fast food", "American"], deliveryTime: "30m"},
        { name: 'Burger King', img: 'https://pngimg.com/d/burger_king_PNG9.png', starRating: 3, cuisines: ["Americal", "burger"], deliveryTime: "30m"},
        { name: 'Maalgaadi', img: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcZxbJoQ_DfuZWK21AG_m5ebmZvResFdAzcy4abN8fSA&s', starRating: 3, cuisines: ["biryani", "north indian"], deliveryTime: "30m"},
        { name: 'Pizza hut', img: 'https://www.freepnglogos.com/uploads/pizza-hut-png-logo/pizza-hut-brands-png-logo-8.png', starRating: 5, cuisines: ["pizza", "italian"], deliveryTime: "30m"},
        { name: 'Pasta Street', img: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ8gaJn-DzKDAg6goAxGIjuWnZfwM2PE-Nx67v5NlONDQ&s', starRating: 3, cuisines: ["desserts", "Pasta"], deliveryTime: "30m"},
        { name: 'Burger King', img: 'https://pngimg.com/d/burger_king_PNG9.png', starRating: 3, cuisines: ["Americal", "burger"], deliveryTime: "30m"},
        { name: 'Maalgaadi', img: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcZxbJoQ_DfuZWK21AG_m5ebmZvResFdAzcy4abN8fSA&s', starRating: 3, cuisines: ["biryani", "north indian"], deliveryTime: "30m"},
    ]

// Function to filter restaurants based on userSearchInput
const filterRestaurants = () => {
    if (!userSearchInput) {
      setFilteredRestaurants(restaurants); // If no search input, display all restaurants
    } else {
      const filtered = restaurants.filter(
        (restaurant) =>
          restaurant.name.toLowerCase().includes(userSearchInput.toLowerCase())
      );
      setFilteredRestaurants(filtered);
    }
  };

  // Call the filter function when the component mounts or when userSearchInput changes
  React.useEffect(() => {
    filterRestaurants();
  }, [userSearchInput]);

  return (
    <div className={styles.resContainer}>
      {filteredRestaurants.map((item, index) => (
        <RestauntCard key={index} restaurant={item} />
      ))}
    </div>
  );
};

export default RestaurantContainer;