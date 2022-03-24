import { MenuItem, TextField } from "@mui/material";
import { useField, useFormikContext } from "formik";
import React from "react";

const Select = ({ name, options, ...rest }) => {
  const [field, mata] = useField(name);

  const { setFieldValue } = useFormikContext();

  const handleChange = (event) => {
    const { value } = event.target;
    setFieldValue(name, value);
  };

  const configSelect = {
    ...field,
    ...rest,
    select: true,
    variant: "outlined",
    fullWidth: true,
    onChange: handleChange,
  };

  if (mata && mata.touched && mata.error) {
    configSelect.error = true;
    configSelect.helperText = mata.error;
  }

  return (
    <TextField autoComplete="off" margin="normal" {...configSelect}>
      {options.map((item) => {
        return (
          <MenuItem key={item.id} value={item}>
            {item.name}
          </MenuItem>
        );
      })}
    </TextField>
  );
};

export default Select;
