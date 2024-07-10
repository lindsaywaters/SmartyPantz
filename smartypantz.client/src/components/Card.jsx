import React, { useState, useEffect } from "react";
import axios from "axios";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';

function InfoForm() {
    const [isSubmitted, setIsSubmitted] = useState(false);
    const [skills, setSkills] = useState([]);
    const [checkedSkillIds, setCheckedSkillIds] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:7109/api/Skills')
            .then(response => {
                // Ensure each skill has an IsChecked property
                const skillsWithChecked = response.data.map(skill => ({ ...skill, IsChecked: false }));
                setSkills(skillsWithChecked);
            })
            .catch(error => {
                console.error("There was an error fetching the skills!", error);
            });
    }, []);

    function handleSubmit(e) {
        e.preventDefault();
        setIsSubmitted(true);
        formPage.classList.add("displayNone");
        
        console.log(skills)
    }

    function handleCheckSkillsClick() {
        homeView.classList.add("displayNone");
        formPage.classList.remove("displayNone");
        resultsPage.classList.remove("displayNone");
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

    return (
        <>
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

            <div id="formPage" className="displayNone">
                <div className="row">
                    <div className="col-2"></div>
                    <div className="col-4">
                        <Card className="cardRowStyle" border="info" bg="dark">
                            <Card.Body className="cardStyle">
                                <form method="POST" onSubmit={handleSubmit}>
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
                                    <Button variant="info" type="submit">
                                        Submit
                                    </Button>
                                </form>
                            </Card.Body>
                        </Card>
                    </div>
                    <div className="col-4">
                        <div>
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
                                </Card.Body>
                            </Card>

                            </div>
                        </div>
                    </div>
                    <div className="col-2"></div>
                </div>
            </div>

           
        </>
    );
}

export default InfoForm;
