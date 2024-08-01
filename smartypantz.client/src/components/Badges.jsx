import React from 'react';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Navbar from 'react-bootstrap/Navbar';
import Logo from "../components/images/logo.jfif";
import Logout from './Logout';


export const Badges = () => {

    return (
        <>

            
            <div className="row" id="cardRow">
                <div className="col-2"></div>
                
                
                
                <div className="col-2">
                    <Card className="cardRowStyle" border="info" bg="dark">
                        <Card.Body className="cardStyle">
                            <Card.Title></Card.Title>
                            <Card.Text className="cardText">
                                Badges Coming Soon
                            </Card.Text>
                            
                        </Card.Body>
                    </Card>
                </div>
                <div className="col-2"></div>
            </div>
        </>
    );
}

export default Badges
