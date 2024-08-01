import React from 'react';
import { useAuth } from './AuthenticationContext';
import { Navigate } from 'react-router-dom';

const AuthorizeAccess = ({ element }) => {
    const { isAuthenticated } = useAuth();

    return isAuthenticated ? element : <Navigate to="/login" replace />;
}

export default AuthorizeAccess; 