import { TextField } from "@mui/material";
import { useField } from "formik";
import React from "react";

const Input = ({ name, ...rest }) => {
  const [field, mata] = useField(name);

  const configTextField = {
    ...field,
    ...rest,
    fullWidth: true,
  };

  if (mata && mata.touched && mata.error) {
    configTextField.error = true;
    configTextField.helperText = mata.error;
  }

  return <TextField autoComplete="off" margin="normal" {...configTextField} multiline={true}  rows={5}/>;
};

export default Input;
