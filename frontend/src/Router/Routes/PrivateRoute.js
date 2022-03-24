import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { isAuthenticated } from "../../Components/Authorization/AuthHelper/authHelper";

const PrivateRoute = () => {
  return isAuthenticated() ? <Outlet /> : <Navigate to="/signIn" />;
};

export default PrivateRoute;
