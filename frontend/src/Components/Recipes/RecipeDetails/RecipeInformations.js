import { Grid } from "@mui/material";
import React from "react";
import RecipeDetails from "./RecipeDetails";
import RecipeIngredients from "./RecipeIngredients";

const RecipeInformations = () => {
  return (
    <Grid container spacing={5} mt>
      <RecipeDetails />
      <RecipeIngredients />
    </Grid>
  );
};

export default RecipeInformations;
