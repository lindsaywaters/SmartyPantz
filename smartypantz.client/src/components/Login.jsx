import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form'
import Card from 'react-bootstrap/Card';
import CreateAccountForm from '../../../SmartyPantz.Server/Models/CreateAccount';
import axios from 'axios'
import { useState } from 'react';
import { useAuth } from './AuthenticationContext'
function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const { login } = useAuth();
    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
             await login(
                username,
                password
            );


            loginForm.classList.add("displayNone")
            
            loginLink.classList.add('displayNone')
            logoutLink.classList.remove('displayNone')
        } catch (error) {
            console.error('login attempt failed:', error);
        }
    };


    function handleCreateAccountLinkClick() {
        loginForm.classList.add("displayNone")
        createAccountForm.classList.remove("displayNone")
    } 
    return (
        <>
           

            <div id="loginForm" className="displayNone">
                <div className="row loginPageTitle ">
                    <h1>Log in to track your childs progress </h1>
                </div>
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
            <CreateAccountForm/>
           
           


           
        </>
    )
}

export default Login