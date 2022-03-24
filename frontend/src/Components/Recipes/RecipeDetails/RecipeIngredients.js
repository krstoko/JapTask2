import { Divider, Grid, Typography } from "@mui/material";
import React, { useContext } from "react";
import RecipeContext from "../../../store/recipetDetails-content";
import Table from "../../ui-component/Table/Table";
import { recipeColumns } from "../../ui-component/Table/TableColumns";
const RecipeIngredients = () => {
  

  const recipeDetails = useContext(RecipeContext);

  const rows = recipeDetails.recipesIngredients.map((ingredient, id) => {
    return {
      id: id + 1,
      name: ingredient.ingredient.name,
      quantity: ingredient.recipeMeasureQuantity,
      measureUnit: ingredient.recipeMeasureUnit,
      price: ingredient.realIngredientPrice + "$"
    };
  });
  
  return (
    <Grid item xs={12} sm={12} md={6} >
      <Typography variant="h5" align="center">Recipe Ingredients</Typography>
      <Divider />
      <Table rows={rows} columns={recipeColumns}/>
    </Grid>
  );
};

export default RecipeIngredients;
