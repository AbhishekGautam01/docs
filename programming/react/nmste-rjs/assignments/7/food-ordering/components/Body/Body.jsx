import React, {useState} from 'react'

import styles from './Body.module.css';
import Search from './Search'
import RestaurantContainer from './RestaurantContainer';

const Body = () =>{

    return (
    <div className={styles.bodyContainer}>
        <RestaurantContainer  />
    </div>)
}

export default Body;