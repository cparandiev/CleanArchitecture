import React, { Component } from 'react';
import {connect} from 'react-redux';

import login from "./actions";
import LoginCard from "./components/LoginCard";
import "./login.css"

class Login extends Component {
    render() {
        const {login} = this.props;
        
        return (
            <div className="login-page">
                <div className="row">
                    <div className="col-8 offset-2">
                        <LoginCard login={login}/>
                    </div>
                </div>
            </div>
        );
    }
}

const mapDispatchToProps = (dispatch) => ({
    login: (username, password, role, setSubmitting) => dispatch(login.actions.DEFAULT({username, password, role}, {setSubmitting})),
});

export default connect(null, mapDispatchToProps)(Login);