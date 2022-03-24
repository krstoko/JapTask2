import { InputBase } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import React from "react";

const SearchBar = (props) => {
  const style = {
    paddingLeft: `40px`,
    height: "30px",
  };
  return (
    <div className="searchWrapper">
      <div className="searchIconWrapper">
        <SearchIcon />
      </div>
      <InputBase
        placeholder="Search…"
        inputProps={{ "aria-label": "search" }}
        sx={style}
        value={props.searchValue}
        onChange={props.onChangeHandler}
      />
    </div>
  );
};

export default SearchBar;
