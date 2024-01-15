import React from 'react';
import { IoIosHome,   } from "react-icons/io";
import { FaPhoneVolume } from "react-icons/fa6";
import { SiAboutdotme } from "react-icons/si";
import { FaShoppingCart } from "react-icons/fa";

import styles from './NavItems.module.css'

const NavItems = () => (
    <div className={styles.navitemsContainer}>
        <ul>
            <li><IoIosHome className={styles.icon} /></li>
            <li><SiAboutdotme className={styles.icon}/></li>
            <li><FaPhoneVolume className={styles.icon}/></li>
            <li><FaShoppingCart className={styles.icon}/></li>
        </ul>
    </div>
);

export default NavItems;