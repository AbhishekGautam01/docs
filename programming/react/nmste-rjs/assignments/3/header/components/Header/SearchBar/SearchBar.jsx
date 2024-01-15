import React, { useState } from "react";

import styles from "./SearchBar.module.css";

const SearchBar = ({userInput, onUserInputChange}) => {

  
  const handleChangeUserInput = (evt) => {
    // We want to make change after checking through the previous value
    onUserInputChange((prev) => {
        if(prev !== evt.target.value) {
            return evt.target.value
        }
        // if we remove this return statement then component will not re-render.
        return prev;
    });
  }

  return (
    <div className={styles.searchBar}>
      <input type="text" placeholder="Search..." value={userInput} onChange={handleChangeUserInput}/>
    </div>
  );
};

export default SearchBar;
