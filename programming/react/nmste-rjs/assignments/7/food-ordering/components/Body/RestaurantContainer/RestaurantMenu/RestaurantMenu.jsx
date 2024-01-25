import React , {useEffect, useState} from "react";
import { useParams } from "react-router-dom";

import './RestaurantMenu.css';
const RestaurantMenu = () => {

    const [restaurantData, setRestaurantData] = useState(null);
    const {resId}= useParams();

    useEffect(()=> {
        fetchMenu();
    }, [])

    const fetchMenu = async () => {
        const data = await fetch(`https://www.swiggy.com/dapi/menu/pl?page-type=REGULAR_MENU&complete-menu=true&lat=28.5011314&lng=77.234377&restaurantId=${resId}&catalog_qa=undefined&submitAction=ENTER`)
        const json = await data.json();

        const name = json.data?.cards[0].card.card.info.name
        const cuisines = json.data?.cards[0].card.card.info.cuisines
        const costFotTwo = json.data?.cards[0].card.card.info.costForTwoMessage

        const items = [];

        json.data?.cards[2].groupedCard.cardGroupMap.REGULAR.cards[1].card.card.itemCards?.forEach(item => {
        const itemName = item.card.info.name;
        const itemPrice = (typeof item.card.info.price === 'number') ? item.card.info.price / 100 : item.card.info.defaultPrice /100;
        items.push({ name: itemName, price: itemPrice });
        });
        setRestaurantData({name: name, cuisines: cuisines, costForTwo: costFotTwo, items: items})
    }

    return restaurantData === null ? (<h1>Loading...</h1> ): (<div className="menu">
        <h1>{restaurantData.name}</h1>
        <h2>{restaurantData.cuisines}</h2>
        <h3>{restaurantData.costForTwo}</h3>
        <ul>
            {
                restaurantData.items.map((item) => <li key={item.name}>{item.name} - Rs. {item.price}</li>)
            }
        </ul>
        </div>
    )
}

export default RestaurantMenu;