import React from 'react';

import styles from './RestaurantCard.module.css';

const RestaurantCard = ({restaurant: {id, name, cloudinaryImageId, costForTwo, cuisines, avgRating}}) => {
    return (
    <div className={styles.resCard}>
        <h2>{name}</h2>
        <img src={`https://media-assets.swiggy.com/swiggy/image/upload/fl_lossy,f_auto,q_auto,w_660/${cloudinaryImageId}`} alt={`logo-${name}`}/>
        <p>Cuisines: {cuisines}</p>
        <p>Cost for two: {costForTwo}</p>
        <p>Rating: {avgRating}</p>
    </div>)
}

export default RestaurantCard;