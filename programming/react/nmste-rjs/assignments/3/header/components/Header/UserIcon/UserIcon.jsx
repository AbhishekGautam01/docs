import React from 'react';
import styles from './UserIcon.module.css';
import userIcon from '../../../public/userIcon.png';

const UserIcon = () => {
    return (
        <div className={styles.userIcon}>
            <img src={userIcon} alt='UserIcon' />
        </div>
    )
}

export {UserIcon}