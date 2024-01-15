import React from 'react';

import styles from './Search.module.css';

const Search = ({userSearchInput, onUserSearchInputChange}) => {

    const handleChangeUserSearchInput = (evt) => {
        onUserSearchInputChange((prev) => {
            if(prev !== evt.target.value){
                return evt.target.value;
            }
            return prev;
        })
    }

    return (
    <div className={styles.searchContainer}>
        <input type='text' placeholder='Search...' value={userSearchInput} onChange={handleChangeUserSearchInput}/>
    </div>)
}

export default Search;