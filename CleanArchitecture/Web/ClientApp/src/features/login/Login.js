import React, { Component } from 'react';
import {connect} from 'react-redux';
import { MDBContainer, MDBRow, MDBCol, MDBInput, MDBBtn } from 'mdbreact';


import loginPatient from "./actions";
import LoginForm from "./components/LoginForm";

class Login extends Component {
    render() {
        const {login} = this.props;

        return (
            <MDBContainer>
            <MDBRow>
              <MDBCol md="6">
                <form>
                  <p className="h5 text-center mb-4">Sign in</p>
                  <div className="grey-text">
                    <MDBInput
                      label="Type your email"
                      icon="envelope"
                      group
                      type="email"
                      validate
                      error="wrong"
                      success="right"
                    />
                    <MDBInput
                      label="Type your password"
                      icon="lock"
                      group
                      type="password"
                      validate
                    />
                  </div>
                  <div className="text-center">
                    <MDBBtn>Login</MDBBtn>
                  </div>
                </form>
              </MDBCol>
            </MDBRow>
          </MDBContainer>
        );
    }
}

const mapDispatchToProps = (dispatch) => ({
    login: (userName, password) => dispatch(loginPatient.actions.DEFAULT({userName, password})),
});

export default connect(null, mapDispatchToProps)(Login);