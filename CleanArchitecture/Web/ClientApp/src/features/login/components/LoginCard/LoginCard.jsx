import React, { Component } from 'react';
import { map, compose} from "ramda";

import LoginCardOption from "./LoginCardOption";
import "./login-card.css";
import renderClassAsFunction from "../../../../utils/renderClassAsFunction";

const createloginCardProps = (selectedRole) => ({text, onClick}) => ({key: text, active: selectedRole === text, onClick, children: text});

const createOptions = (selectedRole, options) => map(
    compose(renderClassAsFunction(LoginCardOption), createloginCardProps(selectedRole)),
    options
);

class LoginCard extends Component {
    state = {selectedRole: "Patient"}

    selectRole = (role) => () => {
        this.setState({selectedRole: role});
    }

    render() {
        const {selectedRole} = this.state;
        const optionsTexts = ['Patient', 'Doctor'];

        const options = createOptions(selectedRole, map(text => ({text, onClick: this.selectRole(text)}), optionsTexts));
        
        console.log(options);

        return (
            <div className="card">                
                <div className="card-body">
                    <h5 className="card-title">Login as</h5>
                    <ul className="nav nav-tabs justify-content-center">
                        {options}
                    </ul>
                    <form>
                        <div class="row">
                            <div class="col-8 offset-2">
                                <div className="form-group">
                                    <label for="exampleInputEmail1">Username</label>
                                    <input type="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter username" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 offset-2">
                                <div className="form-group">
                                    <label for="exampleInputPassword1">Password</label>
                                    <input type="password" className="form-control" id="exampleInputPassword1" placeholder="Password" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 offset-2">
                                <button type="submit" className="btn btn-primary float-right">Submit</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}

export default LoginCard;