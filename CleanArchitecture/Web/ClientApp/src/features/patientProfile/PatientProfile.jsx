import React, { Component } from 'react';
import DatePicker from "react-datepicker";
import { connect } from 'react-redux';
import { path } from 'ramda';

import {userSelector} from "../common/selectors";
import mergeSelectors from "../../utils/mergeSelectors";
import {getPatientInfo} from "./actions";
import {patientProfileSelector} from "./selectors";

import InfoRow from "./components/InfoRow";

class PatientProfile extends Component {
    componentDidMount(){
        const {match: {params : {patientId}}, getPatientInfo} = this.props;

        getPatientInfo(patientId);
    }

    render() {
        const {profile} = this.props;
        
        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col d-flex justify-content-center">
                                        <h5 className="card-title">Patient Profile</h5>
                                    </div>
                                </div>
                                {profile && <React.Fragment>
                                    <InfoRow title={"FIRST NAME"} value={path(['user', 'firstName'], profile)}/>
                                    <InfoRow title={"LAST NAME"} value={path(['user', 'lastName'], profile)}/>
                                    <InfoRow title={"BIRTHDATE"} value={<DatePicker selected={path(['user', 'birthdate'], profile)} className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>}/>
                                    <InfoRow title={"GENDER"} value={path(['user', 'gender'], profile)}/>
                                    <InfoRow title={"HEIGHT"} value={path(['user', 'height'], profile)}/>
                                    <InfoRow title={"WEIGHT"} value={path(['user', 'weight'], profile)}/>
                                    <InfoRow title={"BLOOD"} value={path(['user', 'blood'], profile)}/>
                                </React.Fragment>}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const selectors = [userSelector, patientProfileSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    getPatientInfo: (patientId) => dispatch(getPatientInfo.actions.DEFAULT({patientId})),
});

export default connect(mapStateToProps, mapDispatchToProps)(PatientProfile);