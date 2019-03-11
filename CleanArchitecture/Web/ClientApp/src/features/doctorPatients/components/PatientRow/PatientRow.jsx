import React, { Component } from 'react';
import PropTypes from "prop-types";

import {ProfileButton, BodyExaminationsButton, MedicalExaminationsButton} from "./Buttons";
import "./patient-row.css"

class PatientRow extends Component {
    render() {
        const {id, user} = this.props;

        return (
            <div className="patient-row">
                <div className="row align-items-center">
                    <div className="col d-flex justify-content-center text">{user.firstName}</div>
                    <div className="col d-flex justify-content-center text">{user.lastName}</div>
                    <div className="col d-flex justify-content-center text">{user.gender}</div>
                    <div className="col d-flex justify-content-center text">
                        <ProfileButton id={id}/>
                        <MedicalExaminationsButton id={id}/>
                        <BodyExaminationsButton id={id}/>
                    </div>
                </div>
            </div>
        );    
    }
}

PatientRow.propTypes = {
    id: PropTypes.number,
    user: PropTypes.object,
};

export default PatientRow;