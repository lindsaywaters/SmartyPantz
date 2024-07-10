import { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import InfoForm from './components/Card';
import axios from 'axios';


import DisplayHomePage from './components/HomePage';

function App() {
    return (
        <DisplayHomePage />
    )
}
export default App;