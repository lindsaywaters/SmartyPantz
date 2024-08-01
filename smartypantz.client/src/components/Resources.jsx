import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Card from 'react-bootstrap/Card';

function ResourcePage() {
    const [skillsWithResources, setSkillsWithResources] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const getResources = async () => {
            try {
                const response = await axios.get('https://localhost:7109/api/resources/grouped-by-skill');
                console.log(response.data.$values);
                // Transform the data structure to make it easier to work with
                const skills = response.data.$values.map(skill => ({
                    skill: skill.skill,
                    resources: skill.resources.$values
                }));
                setSkillsWithResources(skills);
            } catch (error) {
                setError(error.message);
            }
        };
        getResources();
    }, []);

    if (error) return <div>Error: {error}</div>;

    return (
        <div id="resourcesPage">
            <div className="row">
                <div className="col-1"></div>
                <div className="col-10">
                    {skillsWithResources.map(skillWithResources => (
                        <Card key={skillWithResources.skill} className="cardRowStyle" border="info" bg="dark">
                            <Card.Body>
                                <h3 className="cardText">{skillWithResources.skill}</h3>
                                <ul>
                                    {skillWithResources.resources.map((resource, index) => (
                                        <li key={index}>
                                            <strong>{resource.type}: </strong>
                                            {resource.type === "Website" ? (
                                                <a href={resource.name} target="_blank" rel="noopener noreferrer">{resource.name}</a>
                                            ) : (
                                                <span>{resource.name}</span>
                                            )}
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
    );
}

export default ResourcePage;
