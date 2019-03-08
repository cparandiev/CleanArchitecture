import React, { Component } from 'react';

import PatientRow from "./components/PatientRow";
import PatientHeader from "./components/PatientHeader";
import "./doctor-patients.css";

class DoctorPatients extends Component {
    render() {
        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col">
                                        <h5 className="card-title">Your Patients</h5>
                                    </div>
                                </div>
                                <hr/>
                                <div className="doctor-patients-container">
                                    <PatientHeader/>
                                    <PatientRow id={3} firstName="Cvetko" lastName="Parandiev" gender="Male"/>
                                    <PatientRow id={1} firstName="Maria" lastName="Qneva" gender="Female"/>
                                    <PatientRow id={1} firstName="Cvetko" lastName="Parandiev" gender="Male"/>
                                    <PatientRow id={1} firstName="Maria" lastName="Qneva" gender="Female"/>
                                    <PatientRow id={1} firstName="Cvetko" lastName="Parandiev" gender="Male"/>
                                    <PatientRow id={1} firstName="Maria" lastName="Qneva" gender="Female"/>
                                    <PatientRow id={1} firstName="Cvetko" lastName="Parandiev" gender="Male"/>
                                    <PatientRow id={1} firstName="Maria" lastName="Qneva" gender="Female"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default DoctorPatients;