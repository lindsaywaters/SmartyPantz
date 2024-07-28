import React, { useState, useEffect, useContext } from "react";
import axios from "axios";
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import AuthenticationContext from "./AuthenticationContext";

function InfoForm() {
    const [isSubmitted, setIsSubmitted] = useState(false);
    const [skills, setSkills] = useState([]);
    const [checkedSkillIds, setCheckedSkillIds] = useState([]);
    const { currentUserId } = useContext(AuthenticationContext);

    useEffect(() => {
        console.log('Fetching skills...');
        axios.get('https://localhost:7109/api/Skills')
            .then(response => {
                const skillsWithChecked = response.data.map(skill => ({ ...skill, IsChecked: false }));
                setSkills(skillsWithChecked);
                console.log('Skills fetched:', skillsWithChecked);
            })
            .catch(error => {
                console.error("There was an error fetching the skills!", error);
            });
    }, []);

    useEffect(() => {
        console.log('Current user ID updated:', currentUserId);
        if (isSubmitted && currentUserId) {
            submitSkills();
        }
    }, [currentUserId, isSubmitted]);

    const submitSkills = () => {
        const payload = {
            userId: currentUserId,
            skillIds: checkedSkillIds
        };
        console.log('Submitting skills with payload:', payload);

        axios.post('https://localhost:7109/api/userSkills', payload)
            .then(response => {
                console.log("Skills updated successfully!", response.data);
                setIsSubmitted(false);
            })
            .catch(error => {
                console.error("There was an error updating the skills!", error);
                setIsSubmitted(false);
            });
    };

    function handleSubmit(e) {
        e.preventDefault();
        if (currentUserId) {
            setIsSubmitted(true);
            document.getElementById("formPage").classList.add("displayNone");
            document.getElementById("resultsPage").classList.remove("displayNone");
        } else {
            console.error("User ID is not set yet!");
        }
    }

    function handleCheckboxChange(skillId) {
        setSkills(prevSkills =>
            prevSkills.map(skill =>
                skill.id === skillId ? { ...skill, IsChecked: !skill.IsChecked } : skill
            )
        );

        if (checkedSkillIds.includes(skillId)) {
            setCheckedSkillIds(prevIds => prevIds.filter(id => id !== skillId));
        } else {
            setCheckedSkillIds(prevIds => [...prevIds, skillId]);
        }
    }

    function handleCreatePlan() {
        document.getElementById("myPlanPage").classList.remove("displayNone");
    }

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
                                                    checked={skill.IsChecked}
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
                                            return (
                                                <li key={skill.id}>{skill.description}</li>
                                            );
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

            <div id="resultsPage" className="displayNone">
                <div className="row">
                    <div className="col-4"></div>
                    <div className="col-4">
                        <div>
                            <Card className="cardRowStyle" border="info" bg="dark">
                                <Card.Body className="resultsCardStyle">
                                    <h3 className="cardText">Skills Your Child Needs To Work On</h3>
                                    <ul className="justifyCenter">
                                        {checkedSkillIds.map(skillId => {
                                            const skill = skills.find(s => s.id === skillId);
                                            return (
                                                <li key={skill.id}>{skill.description}</li>
                                            );
                                        })}
                                    </ul>
                                    <Button type="button" onClick={handleCreatePlan}>Create Plan</Button>
                                </Card.Body>
                            </Card>
                        </div>
                    </div>
                    <div className="col-4"></div>
                </div>
            </div>
        </>
    );
}

export default InfoForm;
