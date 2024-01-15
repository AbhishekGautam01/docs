import React from 'react';

import Logo from './Logo';
import SearchBar from './SearchBar';
import UserIcon from './UserIcon';
import styles from './Header.module.css';

const Header = ({userInput, onUserInputChange}) => {
    return (
    <React.Fragment>
        <header className={styles.header}>
            <Logo />
            <SearchBar userInput={userInput} onUserInputChange={onUserInputChange} />
            <UserIcon />
        </header>
        <p>{userInput}</p>
    </React.Fragment>
    );
}

export default Header;