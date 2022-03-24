import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import React from "react";
import ButtonReusable from "./ButtonReusable";

const MyModal = (prop) => {
  const { message, title, openModal, closeModal } = prop;

  return (
    <Dialog open={openModal}>
      <DialogTitle align="center">{title}</DialogTitle>
      <DialogContent>
        <DialogContentText>{message}</DialogContentText>
      </DialogContent>
      <DialogActions>
        <ButtonReusable
          color="primary"
          variant="contained"
          onClick={() => {
            closeModal();
          }}
        >
          Ok
        </ButtonReusable>
      </DialogActions>
    </Dialog>
  );
};

export default MyModal;
