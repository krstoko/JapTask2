import { Grid } from "@mui/material";
import { Form, Formik } from "formik";
import React, { forwardRef, useEffect, useState } from "react";
import { getAllCategories } from "../../../ApiService/CategoriesApi";
import FormikControl from "../../FormikComponents/FormikControl";
import * as Yup from "yup";
import { renameObjKey } from "../../../HelperFunctions/ObjectFunctions";
const DetailsForm = forwardRef((props, ref) => {
  const [categories, setCategories] = useState([]);
  useEffect(() => {
    getAllCategories((responseData) => {
      setCategories(responseData.data);
    });
  }, []);


  const initialValues = {
    name: "",
    categoryId: "",
    description: "",
    imgUrl: "",
  };

  
  const validationSchema = Yup.object({
    name: Yup.string().required("Recipe name is required"),
    categoryId: Yup.object().required("Category is required"),
    description: Yup.string().required("Description is required"),
    imgUrl: Yup.string().required("Image url is required"),
  });
  return (
    <Formik
      initialValues={initialValues}
      validationSchema={validationSchema}
      innerRef={ref}
      onSubmit={(values, { resetForm }) => {
        props.addRecipe(values);
        resetForm();
      }}
    >
      <Form>
        <Grid container columnSpacing={5}>
          <Grid item xs={6}>
            <FormikControl
              control="input"
              type="text"
              label="Recipe Name"
              name="name"
            />
          </Grid>
          <Grid item xs={6}>
            <FormikControl
              control="select"
              name="categoryId"
              label="Recipe Category"
              options={categories}
            />
          </Grid>
          <Grid item xs={12}>
            <FormikControl
              control="input"
              type="text"
              label="Recipe Image Url"
              name="imgUrl"
            />
          </Grid>
          <Grid item xs={12}>
            <FormikControl
              control="textArea"
              name="description"
              label="Recipe Description"
            />
          </Grid>
        </Grid>
      </Form>
    </Formik>
  );
});

export default DetailsForm;
