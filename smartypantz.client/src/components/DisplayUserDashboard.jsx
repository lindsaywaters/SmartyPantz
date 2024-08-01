import React from 'react';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Navbar from 'react-bootstrap/Navbar';
import Logo from "../components/images/logo.jfif";
import Logout from './Logout';


export const DisplayUserDashboard = () => {
    
    return (
        <>
            
            <div id="dashView">
                <div id="quote" className="row quoteText">
                    <p>"The expert in anything was once a beginner." - Helen Hayes </p>
                </div>
               
            </div>
            <div className="row" id="cardRow">
                <div className="col-2"></div>
                <div className="col-2">
                    <Card className="cardRowStyle" border="info" bg="dark">
                        <Card.Body className="cardStyle">
                            <Card.Title></Card.Title>
                            <Card.Text className="cardText">
                                Awards
                            </Card.Text>
                            <Link to="/Awards">
                                <Button className="buttonColor" variant="info">Check Progress</Button>
                            </Link>
                            
                        </Card.Body>
                    </Card>
                </div>
                <div className="col-1"></div>
                <div className="col-2">
                    <Card className="cardRowStyle" border="info" bg="dark">
                        <Card.Body className="cardStyle">
                            <Card.Title></Card.Title>
                            <Card.Text className="cardText">
                                Skill Hub
                            </Card.Text>
                            <Link to="/SkillsCenter">
                                <Button className="buttonColor" variant="info">Skill Hub</Button>
                            </Link>
                        </Card.Body>
                    </Card>
                </div>
                <div className="col-1"></div>
                <div className="col-2">
                    <Card className="cardRowStyle" border="info" bg="dark">
                        <Card.Body className="cardStyle">
                            <Card.Title></Card.Title>
                            <Card.Text className="cardText">
                                Resources
                            </Card.Text>
                            <Link to="/resources">
                                <Button className="buttonColor" variant="info">More Info</Button>
                            </Link>
                        </Card.Body>
                    </Card>
                </div>
                <div className="col-2"></div>
            </div>
        </>
    );
}

export default DisplayUserDashboard;
