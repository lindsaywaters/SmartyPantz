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
import ResourcePage from './Resources';


export const DisplayHomePage = () => {
  
  
    function handleLoginLinkClick() {
        loginLink.classList.add("displayNone")
       
        homeView.classList.add("displayNone")
        loginForm.classList.remove("displayNone")
        
    }
    function handleCreateAccountLinkClick() {
        loginForm.classList.add("displayNone")
        createAccountForm.classList.remove("displayNone")
        homeView.classList.add("displayNone")
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
                                    <Button className="createAccountLink" variant="info" onClick={handleCreateAccountLinkClick}>Create Account</Button>
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-5"></div>
                    </div>
                </div>
                <Login></Login>
                <div className="row-6 extraSpace">

                </div>
            </div>
            <footer></footer>
        </>


    );
}

export const DisplayUserDashboard = () => {
    function handleCheckSkillsClick () {
        dashView.classList.add("displayNone");
        
        formPage.classList.remove("displayNone");

    }
    const handleAchievementsClick = () => {

    }
    const handleMyTasksClick = () => {

    }
    function handleResourcesClick() {
        resourcePage.classList.remove("displayNone")
        dashView.classList.add("displayNone");

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
                <InfoForm></InfoForm>
                <div id="dashView">
                  
                    
                    <div className="row" id="cardRow">
                        <div className="col-1"></div>
                        <div className="col-2">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="cardStyle">
                                    <Card.Title></Card.Title>
                                    <Card.Text className="cardText">
                                        Achievements
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
                                        MyPlan
                                    </Card.Text>
                                    <Button className="buttonColor" variant="info" onClick={handleCheckSkillsClick}>Check Skills</Button>
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-2"></div>
                        <div className="col-2">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="cardStyle">
                                    <Card.Title></Card.Title>
                                    <Card.Text className="cardText">
                                        Resources
                                    </Card.Text>
                                    <Button className="buttonColor" variant="info" onClick={handleResourcesClick}>More Info</Button>
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-1"></div>
                    </div>
                </div>
                <div id="resourcePage" className="displayNone">
                    <ResourcePage></ResourcePage>
                </div>
                <div className="row-6 extraSpace">

                </div>
            </div>

            <footer></footer>
       
        </>
    )
}


 