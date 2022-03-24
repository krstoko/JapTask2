import React from "react";
import { Button } from "@mui/material";

const ButtonReusable = (props) => {
  const style = {
    ...props.style,
    mt: 3,
    mb: 2,
    fontSize: 18
  };
  return (
    <Button sx={style} {...props}>
      {props.children}
    </Button>
  );
};

export default ButtonReusable;
