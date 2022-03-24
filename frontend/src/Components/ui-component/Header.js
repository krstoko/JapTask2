import { AppBar, Toolbar } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import ButtonReusable from "./ButtonReusable";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";

const Header = (props) => {
  const style = {
    appBar: {
      boxShadow: "rgba(0, 0, 0, 0.45) 0px 25px 20px -20px",
    },
    box: {
      width: "100%",
    },
  };
  return (
    <AppBar position="static" color="default" sx={style.appBar}>
      <Toolbar>
        <Box display="flex" justifyContent="space-between" sx={style.box}>
          <ButtonReusable
            variant="outlined"
            size="small"
            startIcon={<ArrowBackIcon />}
            onClick={props.onBackClick}
          >
            Go Back
          </ButtonReusable>
          {props.children}
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
