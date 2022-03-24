import React, { useContext } from "react";
import RecipeContext from "../../../store/recipetDetails-content";
import Image from "../../ui-component/Image";
import RecipeInformations from "./RecipeInformations";

const RecipeBody = () => {
  const recipeDetails = useContext(RecipeContext);
  
  return (
    <React.Fragment>
      <Image
        src={recipeDetails.imgUrl}
        alt="Image"
      />
      <RecipeInformations />
    </React.Fragment>
  );
};

export default RecipeBody;
