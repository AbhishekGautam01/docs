import React from 'react';

import userIcon from '../../../public/userIcon.png';
import styles from './UserIcon.module.css';

const UserIcon = () => (
        <div className={styles.userIcon}>
            <img src={userIcon} alt='UserIcon' />
        </div>
)

export default UserIcon;