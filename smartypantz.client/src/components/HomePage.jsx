import React from 'react';
import { Link, Route, Routes} from 'react-router-dom';
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Logo from "../components/images/logo.jfif";
import Login from './Login';
import { useAuth } from './AuthenticationContext';

const DisplayHomePage = () => {
    const { isAuthenticated } = useAuth();

    return (
        <>
            <div className="background">
                <div className="row">
                    <div className="col-12">
                        
                    </div>
                </div>
                
                    <div id="homeView">
                        <div id="quote" className="row quoteText">
                            <h1>"The expert in anything was once a beginner." - Helen Hayes</h1>
                        </div>
                        <div className="row" id="cardRow">
                            <div className="col-5"></div>
                            <div className="col-2">
                                <Card className="cardRowStyle" border="info" bg="dark">
                                    <Card.Body className="cardStyle">
                                        <Card.Text className="cardText">
                                            Assess your child's skills to pinpoint strengths and areas for growth, empowering targeted development.
                                        </Card.Text>
                                        <Button className="createAccountLink" variant="info" as={Link} to="/create-account">Create Account</Button>
                                    </Card.Body>
                                </Card>
                            </div>
                            <div className="col-5"></div>
                        </div>
                    </div>
                    <Routes>
                        <Route path="/login" component={Login} />
                    </Routes>
                    
                
            </div>
           
            <footer></footer>
        </>
    );
}

export default DisplayHomePage;
