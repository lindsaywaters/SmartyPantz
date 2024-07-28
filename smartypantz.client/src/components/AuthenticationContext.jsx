import React, { createContext, useState, useContext, useEffect } from 'react';
import axios from 'axios';

const AuthenticationContext = createContext();

export const useAuth = () => useContext(AuthenticationContext);

export const AuthProvider = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [currentUserId, setCurrentUserId] = useState(null);
    useEffect(() => {
        console.log("Current User ID updated:", currentUserId);
    }, [currentUserId]);

    const checkAuth = async () => {
        try {
            const response = await axios.get('https://localhost:7109/api/Account/check-auth');
            setIsAuthenticated(response.status === 200);
            if (response.data && response.data.userId) {
                
            }
        } catch (error) {
            setIsAuthenticated(false);
            
        }
    };

    useEffect(() => {
        checkAuth();
    }, []);

    const login = async (username, password) => {
        
        try {
            const response = await axios.post('https://localhost:7109/api/Account/login', { username, password });
            console.log('API Response:', response.data);
            setIsAuthenticated(true);
            if (response.data && response.data.userId) {
                setCurrentUserId(response.data.userId);
               
                console.log(response.data.userId);
            }
            
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
            setCurrentUserId(null);
        } catch (error) {
            console.error('Logout failed:', error);
        }
    };

    return (
        <AuthenticationContext.Provider value={{ isAuthenticated, currentUserId, login, logout }}>
            {children}
        </AuthenticationContext.Provider>
    );
};

export default AuthenticationContext;