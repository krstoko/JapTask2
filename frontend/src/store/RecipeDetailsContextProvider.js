import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { singleRecipe } from "../ApiService/RecipesApi";
import RecipeContext from "./recipetDetails-content";

export const RecipeDetailsContextProvider = (props) => {
  const [data, setData] = useState({
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
  const { recipeId } = useParams();

  useEffect(() => {
    singleRecipe(recipeId, (responseData) => {
      if (responseData) setData(responseData.data);
    });
  }, [recipeId]);

  return (
    <RecipeContext.Provider value={data}>
      {props.children}
    </RecipeContext.Provider>
  );
};
