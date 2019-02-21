import React, { Component } from 'react';
import { connect } from "react-redux";

import RangePicker from "./components/RangePicker";
import ClinicsDropdown from "./components/ClinicsDropdown";
import DoctorsDropdown from "./components/DoctorsDropdown";
import {clinicsSelector} from "./selectors";
import mergeSelectors from "../../utils/mergeSelectors";
import {getAllClinicsWithDoctors} from "./actions";
import {getDoctorsBySelectedClinicId} from "./utils";
import "./request-medical-examination.css";

class RequestNewExamination extends Component {
    state = {from: new Date('2010-01-12T20:01:00'), to: new Date(), offset: 0, selectedClinicId: 0, selectedDoctorId: 0}
    
    handleChange = (stateVariableName) => (value) => {this.setState((state) => ({...state, [stateVariableName]: value}));}

    handleDropdownChange = (stateVariableName) => (e) => {const value = e.target.value; this.setState((state) => ({...state, [stateVariableName]: +value}));}

    componentDidMount(){
        const {getAllClinicsWithDoctors} = this.props;

        getAllClinicsWithDoctors();
    }

    render() {
        const {from, to, selectedClinicId, selectedDoctorId} = this.state;
        const {clinics} = this.props;
        
        const doctors = getDoctorsBySelectedClinicId(clinics, selectedClinicId);
        
        console.log(doctors);

        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col">
                                        <h5 className="card-title">Request Medical Examination</h5>
                                    </div>
                                </div>
                                <RangePicker handleChangeFrom={this.handleChange('from')} handleChangeTo={this.handleChange('to')}
                                    titleFrom="From" titleTo="To" dateFrom={from} dateTo={to}/>
                                <div className="row rme-select-row">
                                    <div className="col-2 offset-1">
                                        <label className="title">Clinic</label>
                                    </div>
                                    <div className="col-8">
                                        <ClinicsDropdown clinics={clinics} selectedClinicId={selectedClinicId} handleSelected={this.handleDropdownChange('selectedClinicId')}/>
                                    </div>
                                </div>
                                <div className="row rme-select-row">
                                    <div className="col-2 offset-1">
                                        <label className="title">Doctor</label>
                                    </div>
                                    <div className="col-8">
                                        <DoctorsDropdown disabled={selectedClinicId==0} doctors={doctors} selectedDoctorId={selectedDoctorId} handleSelected={this.handleDropdownChange('selectedDoctorId')}/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        );
    }
}

const selectors = [clinicsSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    getAllClinicsWithDoctors: () => dispatch(getAllClinicsWithDoctors.actions.DEFAULT()),
});


export default connect(mapStateToProps, mapDispatchToProps)(RequestNewExamination);