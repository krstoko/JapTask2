import { Grid } from "@mui/material";
import React, { useEffect, useState } from "react";
import FormikControl from "../../FormikComponents/FormikControl";
import ButtonReusable from "../../ui-component/ButtonReusable";
import * as Yup from "yup";
import { Form, Formik } from "formik";
import { getAllIngredients } from "../../../ApiService/IngredientsApi";
import { measureUnits } from "./MeasureUnits";
const IngredientsForm = (props) => {
  useEffect(() => {
    getAllIngredients((responseData) => {
      if (responseData) {
        setIngredients(responseData.data);
      }
    });
  }, []);

  const [ingredients, setIngredients] = useState([]);

  const onAddIngredient = (values, resetForm) => {
    console.log(values)
    props.newIngredient(values);
    resetForm();
  };

  const initialValues = {
    ingredientName: "",
    recipeMeasureUnit: "",
    recipeMeasureQuantity: "",
  };

  const validationSchema = Yup.object({
    ingredientName: Yup.object().required("Ingredient name is required"),
    recipeMeasureUnit: Yup.object().required("Measure unit is required"),
    recipeMeasureQuantity: Yup.string().required(
      "Measure quantity is required"
    ),
  });

  return (
    <Formik
      initialValues={initialValues}
      validationSchema={validationSchema}
      onSubmit={(values, { resetForm }) => {
        onAddIngredient(values, resetForm);
      }}
    >
      <Form>
        <Grid container columnSpacing={5} justifyContent="flex-end">
          <Grid item xs={12}>
            <FormikControl
              control="select"
              type="text"
              label="Ingrediant Name"
              name="ingredientName"
              options={ingredients}
            />
          </Grid>
          <Grid item xs={6}>
            <FormikControl
              control="select"
              type="text"
              label="Measure Unit"
              name="recipeMeasureUnit"
              options={measureUnits}
            />
          </Grid>
          <Grid item xs={6}>
            <FormikControl
              control="input"
              type="number"
              name="recipeMeasureQuantity"
              label="Measure Quantity"
              InputProps={{ inputProps: { min: "0", step: "0.1" } }}
            />
          </Grid>
          <Grid item xs={6}>
            <ButtonReusable
              variant="contained"
              type="submit"
              size="large"
              fullWidth
            >
              Add
            </ButtonReusable>
          </Grid>
        </Grid>
      </Form>
    </Formik>
  );
};

export default IngredientsForm;
