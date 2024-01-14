import React from 'react';
import Logo from './Logo';
import SearchBar from './SearchBar';
import UserIcon from './UserIcon';
import styles from './Header.module.css'

const Header = () => {
    return (
        <header className={styles.header}>
            <Logo />
            <SearchBar />
            <UserIcon />
        </header>
    )
}

export {Header};