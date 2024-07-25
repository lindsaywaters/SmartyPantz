import React, { useState } from 'react';
import axios from 'axios';
import { useEffect } from 'react'
import Card from 'react-bootstrap/Card';

function ResourcePage() {

    const [skillsWithResources, setSkillsWithResources] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const getResources = async () => {
            try {
                const response = await axios.get('https://localhost:7109/api/resources/grouped-by-skill');
                setSkillsWithResources(response.data);
            } catch (error) {
                setError(error.message);

            }
        }
        getResources();
    }, []);
    if (error) return <div>Error: {error}</div>;
    return (
        <>
            <div id="resourcesPage">
                <div className="row">
                    <div className="col-1"></div>
                    <div className="col-10">
                        {skillsWithResources.map((skillWithResources) => (
                            <Card key={skillWithResources.skill} className="cardRowStyle" border="info" bg="dark">
                                <Card.Body>
                                    <h3 className="cardText">{skillWithResources.skill}</h3>
                                    <ul>
                                        {skillWithResources.resources.map((resource, index) => (
                                            <li key={index}>
                                                <strong>{resource.type}: </strong>
                                                {resource.name}
                                            </li>
                                        ))}
                                    </ul>
                                </Card.Body>
                            </Card>
                        ))}
                    </div>
                    <div className="col-1"></div>
                </div>
            </div>
        </>
    )
}

export default ResourcePage;