import { Paper } from "@mui/material";
import React from "react";

const Card = (props) => {
  const style = {
    boxShadow: "0 2px 8px rgba(0, 0, 0, 0.25)",
    borderRadius: "14px",
    my: { xs: 3, md: 6 },
    p: { xs: 2.5, md: 3.5 },
  };
  return (
    <Paper variant="outlined" sx={style}>
      {props.children}
    </Paper>
  );
};

export default Card;
