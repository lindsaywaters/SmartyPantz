import React from 'react';
import { Link } from 'react-router-dom';
import { Navbar, Button, Nav } from 'react-bootstrap';
import Logo from '../components/images/logo.jfif';
import { useAuth } from './AuthenticationContext';

import Logout from './Logout';
const NavbarComponent = () => {
    const { isAuthenticated } = useAuth();
    return (
        <Navbar expand="lg" className="navStyle">
            <div className="logo col-5">
                <img
                    alt=""
                    src={Logo}
                    width="150"
                    height="120"
                    className="d-inline-block align-top"
                />
            </div>
            <div className="nameBox col-2">
                <div className="row">
                    <p className="nameStyle">SmartyPantz</p>
                </div>
                <div className="row">
                    {isAuthenticated ? (
                        <Nav className="ms-4">

                            <Nav.Link as={Link} to="/dashboard">Dashboard</Nav.Link>
                            <Nav.Link as={Link} to="/skillsCenter">Skills</Nav.Link>
                            <Nav.Link as={Link} to="/badges">Badges</Nav.Link>
                            <Nav.Link as={Link} to="/resources">Resources</Nav.Link>
                        </Nav>
                    ) : (
                        <Nav className="ms-4">
                            <Nav.Link as={Link} to="/">Home</Nav.Link>
                            <Nav.Link as={Link} to="/resources">Resources</Nav.Link>
                        </Nav>
                    )}
                    
                    </div>
            </div>
            <div className="col-3"></div>
            <div className="nameBox col-2">
                {isAuthenticated ? (
                    <Logout as={Link} to="/"></Logout>
                ) : (
                    <Button variant="info" as={Link} to="/login">Login</Button>
                )}
            </div>
        </Navbar>
    );
};

export default NavbarComponent;
