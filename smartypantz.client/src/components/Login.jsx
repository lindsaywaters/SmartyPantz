import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form'
import Card from 'react-bootstrap/Card';
import { useNavigate } from 'react-router-dom';
import axios from 'axios'
import { useState } from 'react';
import { useAuth } from './AuthenticationContext'
import CreateAccountForm from './CreateAccount';
function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const { login } = useAuth();
    const navigate = useNavigate();
    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
             await login(
                username,
                password
            );

            navigate('/dashboard')
           
        } catch (error) {
            console.error('login attempt failed:', error);
        }
    };


    function handleCreateAccountLinkClick() {
        navigate('/create-account')
        
    } 
    return (
        <>
           

            <div id="loginForm" className="displayNone">
               
                <div className="row loginForm">
                    <div className="col-5"></div>
                    <div className="col-2">
                        <Card className="cardRowStyle" border="info" bg="dark">
                            <Card.Body className="cardStyle">

                                <form method="POST" onSubmit={handleSubmit }>
                                    <label className="cardText" htmlFor="inputUserName">UserName</label>
                                    <input
                                        type="text"
                                        id="inputUserName"
                                        value={username}
                                        placeholder="username"
                                        onChange={(e)=> setUsername(e.target.value) }
                                    />



                                    <label className="cardText" htmlFor="inputPassword5">Password</label>
                                    <input
                                        type="password"
                                        id="inputPassword5"
                                        aria-describedby="passwordHelpBlock"
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        placeholder="***********"
                                    />

                                    <Button className="buttonColor" variant="info" type="submit">Log In</Button>
                                    <Button className="createAccountLink" variant="info" onClick={handleCreateAccountLinkClick }>Create Account</Button>
                                </form>
                                
                            </Card.Body>

                           
                        </Card>
                    </div>
                   
                    <div className="col-5"></div>
                    </div>
            
            
            </div>
           
           
           


           
        </>
    )
}

export default Login