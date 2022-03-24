import { Grid } from "@mui/material";
import React from "react";
import CategorieBox from "./CategorieBox";

const CategoryList = (props) => {
  return (
    <Grid container spacing={4} mt={1}>
      {props.categories.map((category) => (
        <CategorieBox category={category} key={category.id} />
      ))}
    </Grid>
  );
};

export default CategoryList;
