import React, { Component } from 'react';
import {connect} from 'react-redux';

import loginPatient from "./actions";
import LoginCard from "./components/LoginCard";
import "./login.css"

class Login extends Component {
    render() {
        const {login} = this.props;
        login('ceco', '123');
        login('ceco1', '123');
        login('ceco2', '123');
        login('ceco3', '123');

        return (
            <div className="login-page">
                <div className="row">
                    <div className="col-8 offset-2">
                        <LoginCard />
                    </div>
                </div>
            </div>
        );
    }
}

const mapDispatchToProps = (dispatch) => ({
    login: (userName, password) => dispatch(loginPatient.actions.DEFAULT({userName, password})),
});

export default connect(null, mapDispatchToProps)(Login);