import React, { Component } from 'react';
import PropTypes from "prop-types";

import {ProfileButton, BodyExaminationsButton, MedicalExaminationsButton} from "./Buttons";
import "./patient-row.css"

class PatientRow extends Component {
    render() {
        const {firstName, lastName, gender, id} = this.props;

        return (
            <div className="patient-row">
                <div className="row align-items-center">
                    <div className="col d-flex justify-content-center text">{firstName}</div>
                    <div className="col d-flex justify-content-center text">{lastName}</div>
                    <div className="col d-flex justify-content-center text">{gender}</div>
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
    firstName: PropTypes.string,
    lastName: PropTypes.string,
    gender: PropTypes.string,
};

export default PatientRow;