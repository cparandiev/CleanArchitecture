import React, { Component } from 'react';
import { connect } from "react-redux";
import { isEmpty, map } from "ramda";

import { patientsSelector } from "./selectors";
import { getDoctorPatients } from "./actions";
import PatientRow from "./components/PatientRow";
import PatientHeader from "./components/PatientHeader";
import mergeSelectors from "../../utils/mergeSelectors";
import "./doctor-patients.css";

class DoctorPatients extends Component {
    componentDidMount() {
        const {match: {params : {doctorId}}, getDoctorPatients} = this.props;
        getDoctorPatients(doctorId);
    }

    render() {
        const { patients }= this.props;
        console.log(patients);

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
                                {!isEmpty(patients) && (
                                    <div className="doctor-patients-container">
                                        <PatientHeader/>
                                        {map(p => <PatientRow {...p} />, patients)}
                                    </div>    
                                )}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const selectors = [patientsSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    getDoctorPatients: (doctorId) => dispatch(getDoctorPatients.actions.DEFAULT({doctorId})),
});

export default connect(mapStateToProps, mapDispatchToProps)(DoctorPatients);