import React, { Component } from 'react';
import { map, compose, assoc, toLower} from "ramda";
import { Formik, Form, Field, ErrorMessage } from 'formik';
import PropTypes from 'prop-types';

import LoginCardOption from "./LoginCardOption";
import "./login-card.css";

const createOptions =  (selectedRole, options) => map(
    ({text, onClick}) => (
        <LoginCardOption key={text} active={selectedRole===text} onClick={onClick}>
            {text}
        </LoginCardOption>
    ),
    options
);

class LoginCard extends Component {
    state = {selectedRole: "Patient"}

    optionsTexts = ['Patient', 'Doctor'];

    selectRole = (role) => () => {
        this.setState({selectedRole: role});
    }

    handleSubmit = (values, { setSubmitting }) => {
        const {login} = this.props;
        const {selectedRole} = this.state;
        
        login(values.username, values.password, toLower(selectedRole), setSubmitting);

        // setSubmitting(false);
    }

    render() {
        const {selectedRole} = this.state;

        const options = createOptions(selectedRole, map(text => ({text, onClick: this.selectRole(text)}), this.optionsTexts));
        
        return (
            <Formik initialValues={{ username: '', password: '' }} onSubmit={this.handleSubmit}>
            {({ isSubmitting }) => (
                <div className="card">                
                    <div className="card-body">
                        <h5 className="card-title">Login as</h5>
                        <ul className="nav nav-tabs justify-content-center">
                            {options}
                        </ul>
                        <Form>
                            <div className="row">
                                <div className="col-8 offset-2">
                                    <div className="form-group">
                                        <label htmlFor="username">Username</label>
                                        <Field type="text" name="username" className="form-control" placeholder="Enter username"/>
                                        <ErrorMessage name="email" component="div" />
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-8 offset-2">
                                    <div className="form-group">
                                        <label htmlFor="password">Password</label>
                                        <Field type="password" name="password" className="form-control" placeholder="Password"/>
                                        <ErrorMessage name="email" component="div" />
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-8 offset-2">
                                    <button type="submit" className="btn btn-primary float-right" disabled={isSubmitting}>Submit</button>
                                </div>
                            </div>
                        </Form>  
                    </div>
                </div>
            )}
            </Formik>
        );
    }
}

LoginCard.propTypes = {
    login: PropTypes.func,
}

export default LoginCard;