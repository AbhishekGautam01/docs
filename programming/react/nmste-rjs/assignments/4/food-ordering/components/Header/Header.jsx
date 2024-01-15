import React from 'react';

import styles from './Header.module.css';
import Logo from './Logo';
import NavItems from './NavItems';

const Header = () => (
    <div className={styles.header}>
        <Logo />
        <NavItems />
    </div>
);

export default Header;