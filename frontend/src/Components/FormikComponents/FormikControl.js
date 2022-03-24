import React from "react";
import Input from "./FormsUI/Input";
import Select from "./FormsUI/Select";
import TextArea from "./FormsUI/TextArea";

const FormikControl = (props) => {
  const { control, ...rest } = props;
  switch (control) {
    case "input":
      return <Input {...rest} />;
    case "select":
      return <Select {...rest} />;
    case "textArea":
      return <TextArea {...rest} />;
    default:
      return null;
  }
};

export default FormikControl;
