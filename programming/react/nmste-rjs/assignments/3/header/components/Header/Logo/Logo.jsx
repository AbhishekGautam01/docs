import React from "react";

import BrandLogo from "../../../public/logo.png";
import styles from "./Logo.module.css";

const Logo = () =>  (
    <div className={styles.logo}>
      <img src={BrandLogo} alt="brand logo" />
    </div>
  );

export default Logo;