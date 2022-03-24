import { Snackbar } from "@mui/material";
import React from "react";

const SnackbarComponent = (props) => {
  return (
    <Snackbar
      anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
      open={props.open}
      onClose={props.onClose}
      autoHideDuration={4000}
      message={<span>{props.message}</span>}
    />
  );
};

export default SnackbarComponent;
