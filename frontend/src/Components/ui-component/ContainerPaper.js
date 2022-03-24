import { Container } from "@mui/material";
import React from "react";
import Card from "./Card";

const ContainerPaper = (props) => {
  const style = {
    centered: {
      position: "absolute",
      left: "50%",
      top: "50%",
      transform: "translate(-50%,-50%)",
    },
  };
  return (
    <Container
      component="main"
      maxWidth={props.maxWidth ? props.maxWidth : "xs"}
      sx={style[props.type]}
    >
      <Card>{props.children}</Card>
    </Container>
  );
};

export default ContainerPaper;
