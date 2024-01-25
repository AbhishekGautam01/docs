import React from 'react';

import BrandLogo from '../../../Public/brandLogo.svg';
import styles from './Logo.module.css';

const Logo =() => (
    <div className={styles.logoContainer}>
        <img src={BrandLogo} alt='brand-logo' className={styles.logo}/>
    </div>
)

export default Logo;