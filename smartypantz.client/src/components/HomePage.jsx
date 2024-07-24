import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Logo from "../components/images/logo.jfif"
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import InfoForm from './Card';
import Login from './Login';
import Logout from './Logout'


export const DisplayHomePage = () => {
  
    function handleCheckSkillsClick() {
        homeView.classList.add("displayNone");
        formPage.classList.remove("displayNone");

    }
    function handleLoginLinkClick() {
        loginLink.classList.add("displayNone")
        formPage.classList.add("displayNone")
        homeView.classList.add("displayNone")
        loginForm.classList.remove("displayNone")
        resultsPage.classList.add("displayNone")
    }
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
                            <div className="col-3">
                            </div>
                            <div id="loginLink">
                            <div className="nameBox col-2">
                                    
                                    <Button variant="info" onClick={handleLoginLinkClick}>Login</Button>
                                
                                </div>
                            </div>
                            <div id="logoutLink" className="displayNone">
                                <div className="nameBox col-2">

                                    <Logout/>

                                </div>
                            </div>
                            
                        </Navbar>

                    </div>
                </div>
                <div id="homeView">
                    <div id="quote" className="row quoteText">
                        <h1>"The expert in anything was once a beginner." - Helen Hayes </h1>
                    </div>
                    <div className="row" id="cardRow">
                        <div className="col-5"></div>
                        <div className="col-2">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="cardStyle">
                                    <Card.Title></Card.Title>
                                    <Card.Text className="cardText">
                                        Assess your child's skills to pinpoint strengths and areas for growth, empowering targeted development
                                    </Card.Text>
                                    <Button className="buttonColor" variant="info" onClick={handleCheckSkillsClick}>Check Skills</Button>
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-5"></div>
                    </div>
                </div>
                <InfoForm></InfoForm>
                <Login></Login>
                <div className="row-6 extraSpace">

                </div>
            </div>
            <footer></footer>
        </>


    );
}

export const DisplayUserDashboard = () => {
    const handleCheckSkillsClick = () => {
        dashView.classList.add("displayNone");
        

    }
    const handleAchievementsClick = () => {

    }
    const handleMyTasksClick = () => {

    }
    const handleResourcesClick = () => {

    }
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
                            <div className="col-3">
                            </div>
                            
                            <div id="logoutLink" >
                                <div className="nameBox col-2">

                                    <Logout/>

                                </div>
                            </div>

                        </Navbar>

                    </div>
                </div>
                <div id="dashView">
                    <div id="quote" className="row quoteText">
                        <h1></h1>
                    </div>
                    <div className="row" id="cardRow">
                        <div className="col-1"></div>
                        <div className="col-2">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="cardStyle">
                                    <Card.Title></Card.Title>
                                    <Card.Text className="cardText">
                                        <h3>Achievements</h3>
                                    </Card.Text>
                                    <Button className="buttonColor" variant="info" onClick={handleAchievementsClick}>Check Progress</Button>
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-2"></div>
                        <div className="col-2">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="cardStyle">
                                    <Card.Title></Card.Title>
                                    <Card.Text className="cardText">
                                        <h3>My Tasks</h3>
                                    </Card.Text>
                                    <Button className="buttonColor" variant="info" onClick={handleMyTasksClick}>Work On Skills</Button>
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-2"></div>
                        <div className="col-2">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="cardStyle">
                                    <Card.Title></Card.Title>
                                    <Card.Text className="cardText">
                                        <h3>Resources</h3>
                                    </Card.Text>
                                    <Button className="buttonColor" variant="info" onClick={handleResourcesClick}>More Info</Button>
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-1"></div>
                    </div>
                </div>
                <div className="row-6 extraSpace">

                </div>
            </div>

            <footer></footer>
       
        </>
    )
}


 