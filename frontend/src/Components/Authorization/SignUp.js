import { Grid, Typography } from "@mui/material";
import React from "react";
import ButtonReusable from "../ui-component/ButtonReusable";
import ContainerPaper from "../ui-component/ContainerPaper";
import FormikControl from "../FormikComponents/FormikControl";
import * as Yup from "yup";
import { Form, Formik } from "formik";
import { Link } from "react-router-dom";

const SignUp = () => {
  const onSubmit = (values) => {
    console.log(values);
  };

  const initialValues = {
    userName: "",
    password: "",
    confirmPassword: "",
  };

  const validationSchema = Yup.object({
    userName: Yup.string().required("Username is required"),
    password: Yup.string()
      .min(6, "At least 6 characters required")
      .required("Password is required"),
    confirmPassword: Yup.string()
      .oneOf([Yup.ref("password"), null], "Passwords must match")
      .required("Confirm password is required"),
  });

  return (
    <React.Fragment>
      <ContainerPaper type="centered">
        <Typography component="h1" variant="h5" align="center">
          Sign Up
        </Typography>
        <Formik
          initialValues={initialValues}
          validationSchema={validationSchema}
          onSubmit={(values) => {
            onSubmit(values);
          }}
        >
          <Form>
            <FormikControl
              control="input"
              type="text"
              label="Username"
              name="userName"
            />
            <FormikControl
              control="input"
              type="password"
              label="Password"
              name="password"
            />
            <FormikControl
              control="input"
              type="password"
              label="Confirm Password"
              name="confirmPassword"
            />
            <ButtonReusable type="submit" fullWidth variant="contained">
              Sign Up
            </ButtonReusable>
            <Grid container justifyContent="flex-end">
              <Grid item>
                <Link to="/signIn">Already have an account? Sign in</Link>
              </Grid>
            </Grid>
          </Form>
        </Formik>
      </ContainerPaper>
    </React.Fragment>
  );
};

export default SignUp;
