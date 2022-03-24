import React from "react";
import ContainerPaper from "../../ui-component/ContainerPaper";
import Header from "../../ui-component/Header";
import { useNavigate } from "react-router-dom";
import RecipeBody from "./RecipeBody";
import { RecipeDetailsContextProvider } from "../../../store/RecipeDetailsContextProvider";

const Recipe = () => {
  const navigate = useNavigate();

  const onBackClick = () => {
    navigate("/categories");
  };

  return (
    <ContainerPaper maxWidth="lg">
      <Header onBackClick={onBackClick} />
      <RecipeDetailsContextProvider>
        <RecipeBody />
      </RecipeDetailsContextProvider>
    </ContainerPaper>
  );
};

export default Recipe;
