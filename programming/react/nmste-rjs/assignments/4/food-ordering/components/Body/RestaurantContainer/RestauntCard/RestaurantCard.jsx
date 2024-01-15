import React from 'react';

import styles from './RestaurantCard.module.css';

const RestaurantCard = ({restaurant: {name, img, starRating, cuisines, deliveryTime}}) => {
    console.log(name)
    return (
    <div className={styles.resCard}>
        <h2>{name}</h2>
        <img src={img} alt={`logo-${name}`}/>
        <p>Cuisines: {cuisines}</p>
        <p>Delivery Time: {deliveryTime}</p>
        <p>Rating: {starRating}</p>
    </div>)
}

export default RestaurantCard;