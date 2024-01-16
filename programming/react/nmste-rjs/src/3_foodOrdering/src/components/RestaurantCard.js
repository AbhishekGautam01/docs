import React from "react";

const RestaurantCard = (props) => {
    console.log(props)
    return (
        <div className="res-card">
            <img className="res-logo" src="https://www.licious.in/blog/wp-content/uploads/2020/12/Hyderabadi-chicken-Biryani.jpg" alt="res-logo" />
            <h3>{props.resDetail.name}</h3>
            <h4>{props.resDetail.cuisine}</h4>
            <h4>{props.resDetail.rating} Stars</h4>
            <h4>38 mins</h4>
        </div>
    )
}

export default RestaurantCard;