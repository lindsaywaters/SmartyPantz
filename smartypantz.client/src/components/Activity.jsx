import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { Card, Button } from 'react-bootstrap';

function Activity() {
    const { skillId } = useParams(); 
    const [skill, setSkill] = useState(null);
    
    useEffect(() => {
        console.log(`Fetching details for skill ID: ${skillId}`);
        axios.get(`https://localhost:7109/api/Skills/${skillId}`)
            .then(response => {
                console.log('Skill details:', response.data);
                setSkill(response.data);
            })
            .catch(error => {
                console.error("Error fetching skill details:", error);
            });
    }, [skillId]);

    if (!skill) {
        return <p>Loading...</p>;
    }

    return (
        <>
            <div className="row">
                <div className="col-1"></div>
                <div className="col-10">
                    <Card className="cardRowStyle" border="info" bg="dark">
                        <Card.Body className="cardStyle cardText">
                            
                            <Card.Title className="cardText">{skill.activity}</Card.Title>
                            <Card.Text className="cardText">{skill.activityDescription}</Card.Text>
                        </Card.Body>
                    </Card>
                </div>
                <div className="col-1"></div>
            </div>
        </>
    );
}

export default Activity;
