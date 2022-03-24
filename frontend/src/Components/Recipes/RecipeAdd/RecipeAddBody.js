import { Grid, Typography } from "@mui/material";
import React, { useRef, useState } from "react";
import DetailsForm from "./DetailsForm";
import IngredientsForm from "./IngredientsForm";
import ButtonReusable from "../../ui-component/ButtonReusable";
import Table from "../../ui-component/Table/Table";
import { recipeAddColumns } from "../../ui-component/Table/TableColumns";
import { addRecipe } from "../../../ApiService/RecipesApi";
import MyModal from "../../ui-component/MyModal";
import SnackbarComponent from "../../ui-component/Snackbar";
import { measureUnits } from "./MeasureUnits";
const RecipeAddBody = () => {
  const detailsFormRef = useRef(null);

  const removeIngredient = (ingredientDetails) => {
    setIngredients((prevState) =>
      prevState.filter(
        (ingredient, index) => index + 1 !== ingredientDetails.id
      )
    );
  };

  const columns = recipeAddColumns(removeIngredient);

  const [openModal, setOpenModal] = useState({ open: false, message: "" });
  const [successSnackbar, setSuccessSnackbar] = useState({
    open: false,
    message: "",
  });
  const [ingredients, setIngredients] = useState([]);

  const newIngredient = (ingredient) => {
    setIngredients((prevState) => [...prevState, ingredient]);
  };

  const rows = ingredients.map((ingredient, id) => {
    console.log(ingredient.ingredientName.name);
    return {
      id: id + 1,
      ingredientName: ingredient.ingredientName.name,
      recipeMeasureUnit: ingredient.recipeMeasureUnit.name,
      recipeMeasureQuantity: ingredient.recipeMeasureQuantity,
    };
  });

  const addRecipeCall = (recipe) => {
    recipe.categoryId = recipe.categoryId.id;
    var recipeIngredients = ingredients.map((ingredient) => {
      return {
        ingredientId: ingredient.ingredientName.id,
        recipeMeasureUnit: ingredient.recipeMeasureUnit.id,
        recipeMeasureQuantity: ingredient.recipeMeasureQuantity
      };
    });
    recipe = { ...recipe, recipeIngredients};
    addRecipe(recipe, (responseData) => {
      if (responseData && responseData.data) {
        setIngredients([]);
        setSuccessSnackbar({
          open: true,
          message: "Successfuly created recipe",
        });
      } else {
        settingErrorState(true, responseData.message);
      }
    });
  };

  const onClickHandler = () => {
     if (ingredients.length === 0) {
      settingErrorState(
        true,
        "Looks like you tried to add recipe without ingrediants.Please try again with at least one ingredient"
      );
    } else {
    detailsFormRef.current.handleSubmit();
     }
  };

  const settingErrorState = (open, message) => {
    setOpenModal({
      open: open,
      message: message,
    });
  };

  const handleClose = () => setSuccessSnackbar({ open: false, message: "" });

  return (
    <React.Fragment>
      <MyModal
        title={"Error happaned"}
        message={openModal.message}
        openModal={openModal.open}
        closeModal={() => setOpenModal({ open: false, message: "" })}
      />
      <SnackbarComponent
        open={successSnackbar.open}
        message={successSnackbar.message}
        onClose={handleClose}
      />
      <Typography variant="h3" align="center" mt={4}>
        Add new Recipe
      </Typography>
      <Grid container spacing={5} mt>
        <Grid item xs={12} sm={6}>
          <DetailsForm ref={detailsFormRef} addRecipe={addRecipeCall} />
        </Grid>
        <Grid item xs={12} sm={6}>
          <IngredientsForm newIngredient={newIngredient} />
        </Grid>
      </Grid>
      <Table rows={rows} columns={columns} />
      <ButtonReusable
        type="button"
        onClick={onClickHandler}
        fullWidth
        variant="contained"
      >
        Add recipe
      </ButtonReusable>
    </React.Fragment>
  );
};

export default RecipeAddBody;
