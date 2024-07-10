import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Logo from "../components/images/logo.jfif"
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import InfoForm from './Card';

function DisplayHomePage() {
    return (

        <>
            <div className="background">
                <div className="row">
                    <div className="col-12 " >

                        <Navbar expand="lg" className="navStyle" >

                            <div className="logo col-5" >
                                <img
                                    alt=""
                                    src={Logo}
                                    width="150"
                                    height="120"
                                    className="d-inline-block align-top"

                                />

                            </div>

                            <div className="nameBox col-2 ">
                                <p className="nameStyle">PreKReady</p>
                            </div>
                            <div className="col-5">
                            </div>

                        </Navbar>

                    </div>
                </div>
                <InfoForm></InfoForm>
                <div className="row-6 extraSpace">

                </div>
            </div>
            <footer></footer>
        </>


    );
}

export default DisplayHomePage;