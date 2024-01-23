import React from "react";

import { CDN_URL } from "../utils/constants";
const RestaurantCard = ({resDetail: {cloudinaryImageId, name, cuisines, avgRating, costForTwo}}) => {
    return (
        <div className="res-card">
            <img className="res-logo" src={`${CDN_URL}${cloudinaryImageId}`} alt="res-logo" />
            <h3>{name}</h3>
            <h4>{cuisines}</h4>
            <h4>{avgRating} Stars</h4>
            <h4>{costForTwo}</h4>
        </div>
    )
}

export default RestaurantCard;