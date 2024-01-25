import React from 'react';

import classes from './Header.module.css';
import Logo from './Logo';
import NavItems from './NavItems';

const Header = () => (
    <div className={classes.header}>
    <Logo />
    <NavItems/>
    </div>
);

export default Header;