import { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import InfoForm from './components/Card';
import axios from 'axios';
import { useAuth } from './components/AuthenticationContext'

import { DisplayHomePage, DisplayUserDashboard } from './components/HomePage';

function App() {
    const { isAuthenticated } = useAuth();
    return (
        <div className="App">
            {isAuthenticated ? (
                <DisplayUserDashboard />
            ) : (
                    <DisplayHomePage />
            )}
            
        </div>
    )
}
export default App;