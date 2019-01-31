import React, { Component } from 'react';
import {connect} from 'react-redux';

import Button from "../features/common/components/Button";
import { loginPatient } from "./actions";

class Login extends Component {
    render() {
        const {login} = this.props;

        return (
            <div>
                <Button onClick={() => login('1', '2')}>
                    Login
                </Button>
            </div>
        );
    }
}

const mapDispatchToProps = (dispatch) => ({
    login: (userName, password) => dispatch(loginPatient.actions.DEFAULT({userName, password})),
});

export default connect(null, mapDispatchToProps)(Login);