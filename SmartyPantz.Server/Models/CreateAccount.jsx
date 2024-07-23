import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';

const CreateAccountForm = () => {
    const initialValues = {
        username: '',
        email: '',
        childsName: '',
        childsAge: '',
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
        childsName: Yup.string(),
        childsAge: Yup.number().integer().min(0).required('Required'),
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
            console.log('Server response:', response.data);
        } catch (error) {
            console.error('Error submitting form:', error.response ? error.response.data : error.message);
        }
    };

    return (
        <div id="createAccountForm" className="displayNone">
            <div className="row loginPageTitle ">
                <h1>Log in to track your child's progress</h1>
            </div>
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
                                        <label htmlFor="childsName">Child's Name</label>
                                        <Field name="childsName" type="text" className="form-control" />
                                        <ErrorMessage name="childsName" component="div" className="text-danger" />
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="childsAge">Child's Age</label>
                                        <Field name="childsAge" type="number" className="form-control" />
                                        <ErrorMessage name="childsAge" component="div" className="text-danger" />
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
            </div>
        </div>
    );
};

export default CreateAccountForm;
