import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Modal from 'react-bootstrap/Modal';
import {useState } from 'react'

const CreateAccountForm = () => {
    const [showModal, setShowModal] = useState(false);
    const navigate = useNavigate();
    const initialValues = {
        username: '',
        email: '',
        
        password: '',
        confirmPassword: ''
    };

    const validationSchema = Yup.object({
        username: Yup.string()
            .min(4, 'Must be at least 4 characters long')
            .max(20, 'Must be 20 characters long or less')
            .required('Required'),
        email: Yup.string()
            .email('Invalid email address')
            .required('Required'),
        
        password: Yup.string()
            .min(8, 'Must be at least 8 characters long')
            .max(20, 'Must be 20 characters or less')
            .required('Required'),
        confirmPassword: Yup.string()
            .oneOf([Yup.ref('password'), null], 'Passwords must match')
            .required('Required')
    });

    const onSubmit = async (values) => {
        try {

            const response = await axios.post('https://localhost:7109/api/Account/register', values, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            setShowModal(true);
            console.log('Server response:', response.data);

        } catch (error) {
            console.error('Error submitting form:', error.response ? error.response.data : error.message);
        }

      
    };

    const handleModalClose = () => {
        setShowModal(false);
        navigate('/login');
    }

    return (
        <div id="createAccountForm">
            
            <div className="row loginForm">
                <div className="col-5"></div>
                <div className="col-2">
                    <Card className="cardRowStyle" border="info" bg="dark">
                        <Card.Body className="cardStyle">
                            <Formik
                                initialValues={initialValues}
                                validationSchema={validationSchema}
                                onSubmit={onSubmit}
                            >
                                <Form>
                                    <div className="form-group">
                                        <label htmlFor="username">Username</label>
                                        <Field name="username" type="text" className="form-control" />
                                        <ErrorMessage name="username" component="div" className="text-danger" />
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="email">Email</label>
                                        <Field name="email" type="email" className="form-control" />
                                        <ErrorMessage name="email" component="div" className="text-danger" />
                                    </div>


                                    <div className="form-group">
                                        <label htmlFor="password">Password</label>
                                        <Field name="password" type="password" className="form-control" />
                                        <ErrorMessage name="password" component="div" className="text-danger" />
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="confirmPassword">Confirm Password</label>
                                        <Field name="confirmPassword" type="password" className="form-control" />
                                        <ErrorMessage name="confirmPassword" component="div" className="text-danger" />
                                    </div>
                                    <Button type="submit" variant="info">Register</Button>
                                </Form>
                            </Formik>
                        </Card.Body>
                    </Card>
                </div>
                <div className="col-5"></div>
                <Modal show={showModal} onHide={handleModalClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>Registration Successful</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <p>You have successfully registered. You will be redirected to the login page.</p>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="primary" onClick={handleModalClose}>
                            OK
                        </Button>
                    </Modal.Footer>
                </Modal>
            </div>
        </div>
    );
};

export default CreateAccountForm;
