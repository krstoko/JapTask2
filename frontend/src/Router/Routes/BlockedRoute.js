import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { isAuthenticated } from '../../Components/Authorization/AuthHelper/authHelper';

const BlockedRoute = () => {

    return !isAuthenticated() ? <Outlet /> : <Navigate to="/categories" />
}

export default BlockedRoute