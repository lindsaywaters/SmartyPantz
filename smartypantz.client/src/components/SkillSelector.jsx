import React, { useState, useEffect, useContext } from "react";
import axios from "axios";
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import AuthenticationContext from "./AuthenticationContext";
import { useNavigate } from 'react-router-dom';

function SkillSelector() {
    const [isSubmitted, setIsSubmitted] = useState(false);
    const [skills, setSkills] = useState([]);
    const [checkedSkillIds, setCheckedSkillIds] = useState([]);
    const { currentUserId } = useContext(AuthenticationContext);
    const navigate = useNavigate();

    useEffect(() => {
        console.log('Fetching skills...');
        axios.get('https://localhost:7109/api/Skills')
            .then(response => {
                console.log('Skills API response:', response.data);
                const skillsArray = response.data.$values || response.data;
                if (Array.isArray(skillsArray)) {
                    const skillsWithChecked = skillsArray.map(skill => ({ ...skill, isChecked: false }));
                    setSkills(skillsWithChecked);
                    console.log('Skills fetched:', skillsWithChecked);
                } else {
                    console.error("Unexpected data format:", response.data);
                }
            })
            .catch(error => {
                console.error("There was an error fetching the skills!", error);
            });
    }, []);

    useEffect(() => {
        console.log('Checking for submission...');
        console.log('Current user ID:', currentUserId);
        console.log('IsSubmitted state:', isSubmitted);
        if (isSubmitted && currentUserId) {
            console.log("Calling submitSkills...");
            submitSkills();
        }
    }, [currentUserId, isSubmitted]);

    const submitSkills = () => {
        const allSkillIds = skills.map(skill => skill.id);
        const payload = {
            userId: currentUserId,
            skillIds: checkedSkillIds
        };
        console.log('Submitting skills with payload:', payload);

        axios.post('https://localhost:7109/api/userSkills', payload)
            .then(response => {
                console.log("Skills updated successfully!", response.data);

                // Calculate skills to remove
                const skillsToRemove = allSkillIds.filter(id => !checkedSkillIds.includes(id));

                if (skillsToRemove.length > 0) {
                    axios.delete(`https://localhost:7109/api/userSkills/${currentUserId}`, {
                        data: skillsToRemove
                    })
                        .then(response => {
                            console.log("Skills removed successfully!", response.data);
                            setIsSubmitted(false);
                            navigate('/skillsCenter');
                        })
                        .catch(error => {
                            console.error("There was an error removing the skills!", error);
                            setIsSubmitted(false);
                        });
                } else {
                    setIsSubmitted(false);
                    navigate('/skillsCenter');
                }
            })
            .catch(error => {
                console.error("There was an error updating the skills!", error);
                setIsSubmitted(false);
            });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("HandleSubmit triggered");
        if (currentUserId) {
            setIsSubmitted(true);
            console.log("IsSubmitted set to true");
        } else {
            console.error("User ID is not set yet!");
        }
    };

    const handleCheckboxChange = (skillId) => {
        setSkills(prevSkills => {
            const updatedSkills = prevSkills.map(skill =>
                skill.id === skillId ? { ...skill, isChecked: !skill.isChecked } : skill
            );

            const isChecked = updatedSkills.find(skill => skill.id === skillId).isChecked;

            setCheckedSkillIds(prevIds => {
                const newIds = isChecked
                    ? [...prevIds, skillId]
                    : prevIds.filter(id => id !== skillId);
                return Array.from(new Set(newIds)); // Remove duplicates
            });

            return updatedSkills;
        });
    };


    return (
        <>
            <div id="formPage" className="displayNone">
                <form method="POST" onSubmit={handleSubmit}>
                    <div className="row">
                        <div className="col-2"></div>
                        <div className="col-4">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="cardStyle">
                                    {skills.map(skill => (
                                        <div key={skill.id} className="checkboxSkillStyle">
                                            <label className="cardText">
                                                <input
                                                    type="checkbox"
                                                    id={skill.id}
                                                    checked={skill.isChecked}
                                                    onChange={() => handleCheckboxChange(skill.id)}
                                                    name={skill.title}
                                                />
                                                {skill.description}
                                            </label>
                                        </div>
                                    ))}
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-4">
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="resultsCardStyle">
                                    <h3 className="cardText">Skills Your Child Needs To Work On</h3>
                                    <ul className="justifyCenter">
                                        {checkedSkillIds.map(skillId => {
                                            const skill = skills.find(s => s.id === skillId);
                                            if (skill) {
                                                return (
                                                    <li key={skill.id}>{skill.description}</li>
                                                );
                                            }
                                            return null;
                                        })}
                                    </ul>
                                    <Button variant="info" type="submit">
                                        Submit
                                    </Button>
                                </Card.Body>
                            </Card>
                        </div>
                        <div className="col-2"></div>
                    </div>
                </form>
            </div>
        </>
    );
}

export default SkillSelector;