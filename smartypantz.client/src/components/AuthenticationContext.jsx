import React, { createContext, useState, useContext, useEffect } from 'react';
import axios from 'axios';

const AuthenticationContext = createContext();

export const useAuth = () => useContext(AuthenticationContext);

export const AuthProvider = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [currentUserId, setCurrentUserId] = useState(null);

    const checkAuth = async () => {
        try {
            const response = await axios.get('https://localhost:7109/api/Account/check-auth', {
                headers: {
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            setIsAuthenticated(response.status === 200);
            if (response.data && response.data.$id) {
                setCurrentUserId(response.data.$id);
               
            } else {
                
                setCurrentUserId(null);
            }
        } catch (error) {
            setIsAuthenticated(false);
            setCurrentUserId(null);
        }
    };

    useEffect(() => {
        const token = localStorage.getItem('authToken');
        if (token) {
            checkAuth();
        } else {
            setIsAuthenticated(false);
            setCurrentUserId(null);
        }
    }, []);
    const login = async (username, password) => {
        try {
            const response = await axios.post('https://localhost:7109/api/Account/login', { username, password });
            
            console.log('Login response:', response.data);

            if (response.data && response.data.token) {
                localStorage.setItem('authToken', response.data.token);
                setIsAuthenticated(true);

                if (response.data.$id) {
                    setCurrentUserId(response.data.$id);
                    console.log('User ID from response:', response.data.$id);
                } else {
                    setCurrentUserId(null);
                    console.log('User ID not found in response');
                }

                return response.data;
            } else {
                setIsAuthenticated(false);
                setCurrentUserId(null);
                console.log('Token not found in response');
            }
        } catch (error) {
            setIsAuthenticated(false);
            setCurrentUserId(null);
            console.error('Login failed:', error);
            throw error;
        }
    };




    const logout = async () => {
        try {
            await axios.post('https://localhost:7109/api/Account/logout');
            localStorage.removeItem('authToken');
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
