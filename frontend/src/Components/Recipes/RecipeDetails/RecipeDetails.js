import { Divider, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React, { useContext } from "react";
import RecipeContext from "../../../store/recipetDetails-content";
import { recipeDetailsStyle } from "../../Style/RecipeDetailsStyle";

const RecipeDetails = () => {
 
  const recipeDetails = useContext(RecipeContext);
  return (
    <Grid item xs={12} sm={12} md={6}>
      <Typography variant="h5" align="center">
        Recipe Details
      </Typography>
      <Divider />
      <Box component="div" pt={3}>
        <Typography variant="h5" sx={recipeDetailsStyle.higher} gutterBottom>
          Recipe Name:
        </Typography>
        <Typography paragraph sx={recipeDetailsStyle.paragraph} gutterBottom>
          {recipeDetails.name}
        </Typography>
        <Typography variant="h5" sx={recipeDetailsStyle.higher} gutterBottom>
          Recipe Category:
        </Typography>
        <Typography paragraph sx={recipeDetailsStyle.paragraph} gutterBottom>
          {recipeDetails.category.name}
        </Typography>
        <Typography variant="h5" sx={recipeDetailsStyle.higher} gutterBottom>
          Recipe Description:
        </Typography>
        <Typography paragraph sx={recipeDetailsStyle.paragraph} gutterBottom>
         {recipeDetails.description}
        </Typography>
        <Typography variant="h5" sx={recipeDetailsStyle.higher} gutterBottom>
          Recipe total price:
        </Typography>
        <Typography paragraph sx={recipeDetailsStyle.paragraph} gutterBottom>
         {recipeDetails.price}$
        </Typography>
      </Box>
    </Grid>
  );
};

export default RecipeDetails;
