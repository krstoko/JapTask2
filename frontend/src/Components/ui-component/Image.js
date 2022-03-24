import { Box } from "@mui/material";
import React from "react";

const Image = (props) => {
  const style = {
    ...props.style,
    width: "100%",
    mt: 3,
    objectFit: "cover",
    borderRadius: 5,
    height: "100%",
    maxHeight: { xs: 303, md: 400 },
  };
  return <Box component="img" sx={style} alt={props.alt} src={props.src} />;
};

export default Image;
