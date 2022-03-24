import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import SignIn from "../Components/Authorization/SignIn";
import Categories from "../Components/Categories/Categories";
import RecipeAdd from "../Components/Recipes/RecipeAdd/RecipeAdd";
import Recipe from "../Components/Recipes/RecipeDetails/Recipe";
import Recipes from "../Components/Recipes/RecipeList/Recipes";
import BlockedRoute from "./Routes/BlockedRoute";
import PrivateRoute from "./Routes/PrivateRoute";
const MainRouter = () => {
  return (
    <React.Fragment>
      <Routes>
        <Route path="/" element={<Navigate replace to="/signIn" />} />

        <Route path="/" element={<BlockedRoute />}>
          <Route path="signIn" element={<SignIn />} />
        </Route>

        <Route path="/" element={<PrivateRoute />}>
          <Route path="categories" element={<Categories />} />
          <Route path="recipes/:categoryId" element={<Recipes />} />
          <Route path="recipe/:recipeId" element={<Recipe />} />
          <Route path="recipe/add" element={<RecipeAdd />} />
        </Route>
      </Routes>
    </React.Fragment>
  );
};

export default MainRouter;
