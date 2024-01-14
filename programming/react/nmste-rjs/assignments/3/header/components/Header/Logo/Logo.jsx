import React from "react";
import styles from "./Logo.module.css";
import BrandLogo from "../../../public/logo.png";

const Logo = () => {
  return (
    <div className={styles.logo}>
      <img src={BrandLogo} alt="brand logo" />
    </div>
  );
};

export { Logo }