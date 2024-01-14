import React from 'react'
import styles from './SearchBar.module.css'
const SearchBar = () => {
    return (
        <div className={styles.searchBar}>
            <input type='text' placeholder='Search...' />
        </div>
    )
}

export {SearchBar}