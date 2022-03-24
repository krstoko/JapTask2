import React from "react";
const RecipeContext = React.createContext({
  recipeName: "",
  description: "",
  category: {
    categoryName: "",
  },
  recipesIngredients: [
    {
      ingredient: {},
    },
  ],
});

export default RecipeContext;
