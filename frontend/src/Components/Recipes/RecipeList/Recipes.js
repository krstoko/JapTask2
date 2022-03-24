import React from "react";
import ContainerPaper from "../../ui-component/ContainerPaper";
import Header from "../../ui-component/Header";
import ButtonReusable from "../../ui-component/ButtonReusable";
import { useNavigate } from "react-router-dom";
import RecipesBody from "./RecipesBody";

const Recipes = () => {
  const navigate = useNavigate();

  const onBackClick = () => {
    navigate("/categories");
  };
  const onAddClick = () =>{
    navigate("/recipe/add")
  }
  return (
    <ContainerPaper maxWidth="lg">
      <Header onBackClick={onBackClick}>
        <ButtonReusable variant="contained" size="small" onClick={onAddClick}>
          Add Recipe
        </ButtonReusable>
      </Header>
      <RecipesBody />
    </ContainerPaper>
  );
};

export default Recipes;
