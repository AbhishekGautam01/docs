import React from 'react';
import { IoIosHome,   } from "react-icons/io";
import { FaPhoneVolume } from "react-icons/fa6";
import { SiAboutdotme } from "react-icons/si";
import { FaShoppingCart } from "react-icons/fa";
import {Link} from "react-router-dom";

import styles from './NavItems.module.css'

const NavItems = () => (
    <div className={styles.navitemsContainer}>
        <ul>
            <li><Link style={{textDecoration: 'none', color: 'inherit'}} to="/"><IoIosHome className={styles.icon} /></Link></li>
            <li><Link style={{textDecoration: 'none', color: 'inherit'}} to="/about"><SiAboutdotme className={styles.icon}/></Link></li>
            <li><Link style={{textDecoration: 'none', color: 'inherit'}} to="/contact"><FaPhoneVolume className={styles.icon}/></Link></li>
            <li><Link style={{textDecoration: 'none', color: 'inherit'}} to="/"><FaShoppingCart className={styles.icon}/></Link></li>
        </ul>
    </div>
);

export default NavItems;