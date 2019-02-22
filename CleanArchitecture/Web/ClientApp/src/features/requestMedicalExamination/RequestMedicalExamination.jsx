import React, { Component } from 'react';
import { connect } from "react-redux";

import RangePicker from "./components/RangePicker";
import ClinicsDropdown from "./components/ClinicsDropdown";
import DoctorsDropdown from "./components/DoctorsDropdown";
import {clinicsSelector} from "./selectors";
import mergeSelectors from "../../utils/mergeSelectors";
import {getAllClinicsWithDoctors} from "./actions";
import {getDoctorsBySelectedClinicId} from "./utils";
import {getDoctorWorkingTimes} from "../common/actions";
import DatePicker from "react-datepicker";
import MaterialIcon from 'material-icons-react';
import "./request-medical-examination.css";

class RequestNewExamination extends Component {
    state = {from: new Date('2010-01-12T20:01:00'), to: new Date(), offset: 0, selectedClinicId: 0, selectedDoctorId: 0}
    
    handleChange = (stateVariableName) => (value) => {this.setState((state) => ({...state, [stateVariableName]: value}));}

    handleClinicDropdownChange = (e) => {const value = e.target.value; this.setState((state) => ({...state, selectedClinicId: +value}));}

    toggleOpen = () => {this.setState((state) => ({...state, open: !state.open}));}

    handleDoctorDropdownChange = (e) => {
        const value = e.target.value;

        this.setState((state, {getDoctorWorkingTimes}) => {
            if(value > 0) getDoctorWorkingTimes(value);

            return ({...state, selectedDoctorId: +value})
        });
    }

    componentDidMount(){
        const {getAllClinicsWithDoctors} = this.props;

        getAllClinicsWithDoctors();
    }

    render() {
        const {from, to, selectedClinicId, selectedDoctorId, open} = this.state;
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
                                        <ClinicsDropdown clinics={clinics} selectedClinicId={selectedClinicId} handleSelected={this.handleClinicDropdownChange}/>
                                    </div>
                                </div>
                                <div className="row rme-select-row">
                                    <div className="col-2 offset-1">
                                        <label className="title">Doctor</label>
                                    </div>
                                    <div className="col-8">
                                        <DoctorsDropdown disabled={selectedClinicId==0} doctors={doctors} selectedDoctorId={selectedDoctorId} handleSelected={this.handleDoctorDropdownChange}/>
                                    </div>
                                </div>
                                <div>
                                    <div className="row">
                                        <div className="col">
                                            <DatePicker selected={from}  className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                                        </div>
                                        <div className="col">
                                            <DatePicker selected={to} className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                                        </div>
                                        <div className="col-1">
                                            <MaterialIcon key={open} className="material-icons 32 md-dark clickable-icon float-right" icon={open ? "expand_less"  : "expand_more"} size="32" onClick={this.toggleOpen}/>
                                        </div>
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
    getDoctorWorkingTimes: (doctorId) => dispatch(getDoctorWorkingTimes.actions.DEFAULT({doctorId}))
});


export default connect(mapStateToProps, mapDispatchToProps)(RequestNewExamination);