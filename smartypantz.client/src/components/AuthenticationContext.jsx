// AuthContext.js
import React, { createContext, useState, useContext, useEffect } from 'react';
import axios from 'axios';

const AuthenticationContext = createContext();

export const useAuth = () => useContext(AuthenticationContext);

export const AuthProvider = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    const checkAuth = async () => {
        try {
            const response = await axios.get('https://localhost:7109/api/Account/check-auth');
            setIsAuthenticated(response.status === 200);
        } catch (error) {
            setIsAuthenticated(false);
        }
    };

    useEffect(() => {
        checkAuth();
    }, []);

    const login = async (username, password) => {
        try {
            const response = await axios.post(('https://localhost:7109/api/Account/login'), { username, password });
            setIsAuthenticated(true);
            return response.data;
        } catch (error) {
            setIsAuthenticated(false);
            throw error;
        }
    };

    const logout = async () => {
        try {
            await axios.post('https://localhost:7109/api/Account/logout');
            setIsAuthenticated(false);
        } catch (error) {
            console.error('Logout failed:', error);
        }
    };

    return (
        <AuthenticationContext.Provider value={{ isAuthenticated, login, logout }}>
            {children}
        </AuthenticationContext.Provider>
    );
};
