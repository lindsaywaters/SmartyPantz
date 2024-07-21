import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Card from 'react-bootstrap/Card';
function Login() {
   
    function handleLogin() {

    }
    function handleCreateAccount() {
        
    }

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

                                <Form method="POST">
                                    <Form.Label className="cardText" htmlFor="inputUserName">UserName</Form.Label>
                                    <Form.Control
                                        type="username"
                                        id="inputUserName"

                                    />



                                    <Form.Label className="cardText" htmlFor="inputPassword5">Password</Form.Label>
                                    <Form.Control
                                        type="password"
                                        id="inputPassword5"
                                        aria-describedby="passwordHelpBlock"
                                    />

                                    <Button className="buttonColor" variant="info" type="submit" onSubmit={handleLogin }>Log In</Button>
                                    <Button className="createAccountLink" variant="info" onClick={handleCreateAccountLinkClick }>Create Account</Button>
                                </Form>
                                
                            </Card.Body>

                           
                        </Card>
                    </div>
                   
                    <div className="col-5"></div>
                    </div>
            

            </div>

            <div id="createAccountForm" className="displayNone">
                <div className="row loginPageTitle ">
                    <h1>Log in to track your childs progress </h1>
                </div>
                <div className="row loginForm">
                    <div className="col-5"></div>
                    <div className="col-2">
                        <Card className="cardRowStyle" border="info" bg="dark">
                            <Card.Body className="cardStyle">

                                <Form method="POST">
                                    <Form.Label className="cardText" htmlFor="inputUserName">UserName</Form.Label>
                                    <Form.Control
                                        type="username"
                                        id="inputUserName"

                                    />



                                    <Form.Label className="cardText" htmlFor="inputPassword5">Password</Form.Label>
                                    <Form.Control
                                        type="password"
                                        id="inputPassword5"
                                        aria-describedby="passwordHelpBlock"
                                    />

                                    <Button className="buttonColor" variant="info" type="submit" onSubmit={handleCreateAccount}>Create Account</Button>
                                   
                                </Form>

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