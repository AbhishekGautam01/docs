import React, {useState} from 'react'

import styles from './Body.module.css';
import Search from './Search'
import RestaurantContainer from './RestaurantContainer';

const Body = () =>{

    const [userSearchInput, setUserSearchInput] = useState('');
    return (
    <div className={styles.bodyContainer}>
        <Search userSearchInput={userSearchInput} onUserSearchInputChange={setUserSearchInput} />
        {`User is Currently applying search ${(userSearchInput === null || userSearchInput === undefined || userSearchInput.trim() === '') ? 'No Filter' : userSearchInput}`}
        <RestaurantContainer userSearchInput={userSearchInput} />
    </div>)
}

export default Body;