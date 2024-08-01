import React from 'react'
import Button from 'react-bootstrap/Button';
import { useAuth } from './AuthenticationContext';

function Logout() {
    const { logout } = useAuth();

    const handleLogout = async () => {
        try {
            await logout();
            
        } catch (error) {
            console.error('Logout unsuccessful:', error);
        }
    }

    return (
        <>
            <Button variant="info" onClick={handleLogout}>Logout</Button>
        </>
    )
};

export default Logout;