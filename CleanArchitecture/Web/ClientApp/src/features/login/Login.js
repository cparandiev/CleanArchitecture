import React, { Component } from 'react';
import {connect} from 'react-redux';

import loginPatient from "./actions";
import LoginCard from "./components/LoginCard";

class Login extends Component {
    render() {
        const {login} = this.props;

        return (
          <LoginCard />
        );
    }
}

const mapDispatchToProps = (dispatch) => ({
    login: (userName, password) => dispatch(loginPatient.actions.DEFAULT({userName, password})),
});

export default connect(null, mapDispatchToProps)(Login);