import React, { useState, useEffect, useContext } from 'react';
import axios from 'axios';
import AuthenticationContext from './AuthenticationContext';
import { Card, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

import Activity from './Activity';


function SkillsCenter() {
    const [skills, setSkills] = useState([]);
    const [userSkillsList, setUserSkillsList] = useState([]);
    const { currentUserId } = useContext(AuthenticationContext);
    const navigate = useNavigate();
    // Fetch all skills on component mount
    useEffect(() => {
        console.log('Fetching skills...');
        axios.get('https://localhost:7109/api/Skills')
            .then(response => {
                setSkills(response.data);
            })
            .catch(error => {
                console.error("Error fetching skills:", error);
            });
    }, []);

    // Fetch user-specific skills when currentUserId changes
    useEffect(() => {
        if (currentUserId) {
            console.log('Fetching user skills...');
            axios.get(`https://localhost:7109/api/userSkills/${currentUserId}`)
                .then(response => {
                    console.log('User skills API response:', response.data);
                   
                        const skillsData = response.data.$values.map(item => item.skill)
                        setUserSkillsList(skillsData);
                    
                })
                .catch(error => {
                    console.error("Error fetching user skills:", error);
                    setUserSkillsList([]); // Default to empty array on error
                });
        }
    }, [currentUserId]);

    useEffect(() => {
        console.log("User skills list updated:", userSkillsList);
    }, [userSkillsList]);


    const handleStartActivity = (skillId) => {
        navigate(`/activity/${skillId}`)
    }
    const handleSetCompleted = () => {

    }
    
    return (
        <>
            <div className="container">
                <div className="row">
                    <Link to="/skillSelector">
                        <Button> Select Skills</Button>
                    </Link>
                </div>
                <div className="row">
                    {userSkillsList.map((userSkill) => (
                        <div key={userSkill.id} className="col-md-4 mb-4">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="cardStyle">
                                    <Card.Text className="cardText">
                                        {userSkill.title}
                                    </Card.Text>
                                    
                                    <Button className="m-2" onClick={() => handleStartActivity(userSkill.id)}>Start Activity</Button>
                                    <Button className="m-2" onClick={() => handleSetCompleted()}>Mark Completed</Button>
                                    
                                </Card.Body>
                            </Card>
                        </div>
                    ))}
                </div>
            </div>
        </>
    );
}

export default SkillsCenter;
