import { Card, CardActionArea, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";
import { boxStyle } from "../../Style/RecipeBoxStyle";
const RecipeBox = ({recipe}) => {
    const navigate = useNavigate()

    const onRecipeClick = () =>{
        navigate(`/recipe/${recipe.id}`)
    }
  return (
    <Grid item xs={12} sm={6} md={4}>
      <Card>
      <CardActionArea onClick={onRecipeClick}>
        <CardMedia
          component="img"
          height="140"
          image={recipe.imgUrl}
          alt="recipeImg"
        />
        <CardContent sx={boxStyle}>
          <Typography gutterBottom variant="h5" component="div">
            {recipe.name}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            {recipe.price}$
          </Typography>
        </CardContent>
        </CardActionArea>
      </Card>
    </Grid>
  );
};

export default RecipeBox;
