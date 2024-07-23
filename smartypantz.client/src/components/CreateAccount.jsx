import axios from 'axios';

import Card from 'react-bootstrap/Card';

function CreateAccountForm ()  {
  


    const onSubmit = async (values) => {
        console.log('Submitting form with values:', values); // Debugging log
        try {
            const response = await axios.post('/api/Account/register', values, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            console.log('Server response:', response.data); // Debugging log
        } catch (error) {
            console.error('Error submitting form:', error.response ? error.response.data : error.message);
        }
    };


    return (
        <div id="createAccountForm" className="displayNone">
            <div className="row loginPageTitle">
                <h1>Log in to track your child's progress</h1>
            </div>
            <div className="row loginForm">
                <div className="col-5"></div>
                <div className="col-2">
                    <Card className="cardRowStyle" border="info" bg="dark">
                        <Card.Body className="cardStyle">
                            <form>
                                <label htmlfor="username">Username</label>
                                 <input type="text" name="username"></input>

                                
</form>

                        </Card.Body>
                    </Card>
                </div>
                <div className="col-5"></div>
            </div>
        </div>
    );
};

export default CreateAccountForm;
