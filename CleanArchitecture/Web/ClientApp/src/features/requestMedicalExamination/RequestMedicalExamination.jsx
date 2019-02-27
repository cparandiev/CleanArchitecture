import React, { Component } from 'react';
import { connect } from "react-redux";
import { compose, map } from "ramda";

import RangePicker from "./components/RangePicker";
import ClinicsDropdown from "./components/ClinicsDropdown";
import DoctorsDropdown from "./components/DoctorsDropdown";
import {clinicsSelector} from "./selectors";
import mergeSelectors from "../../utils/mergeSelectors";
import { selectedDoctorWokingTimes, userSelector } from "../common/selectors";
import {getAllClinicsWithDoctors, requestMedicalExamination} from "./actions";
import {getDoctorsBySelectedClinicId, orderWorkingTimes, filterWorkingTimes} from "./utils";
import {getDoctorWorkingTimes} from "../common/actions";
import WorkingTimeRow from "./components/WorkingTimeRow";
import {getCurrentElements, getTotalPages} from "../../utils/paginate";
import Paginate from "../common/components/Paginate";
import "./request-medical-examination.css";

const transformDoctorWokingTimes = (from, to) => compose(
    orderWorkingTimes,
    filterWorkingTimes(from, to),
)

const renderRowsByPage = (elementPerPage, currentPage, onSubmit, requestDate, durationInMinutes, handleDurationInMinutesChange, handleRequestDateChange) => compose(
    map((({open, close, id}) => <WorkingTimeRow onSubmit={onSubmit} id={id} key={id} open={open} close={close} requestDate={requestDate} durationInMinutes={durationInMinutes}
        handleDurationInMinutesChange={handleDurationInMinutesChange} handleRequestDateChange={handleRequestDateChange}/>)),
    getCurrentElements(elementPerPage, currentPage),
)

const elementPerPage = 5;

class RequestNewExamination extends Component {
    state = {from: new Date('2010-01-12T20:01:00'), to: new Date(), offset: 0, selectedClinicId: 0, selectedDoctorId: 0,
        requestDate: new Date(), durationInMinutes: 0}
    
    handlePageChange = (data) => { this.setState((state) => ({...state, offset: data.selected}));}
    
    handleChange = (stateVariableName) => (value) => {this.setState((state) => ({...state, [stateVariableName]: value}));}

    handleChange2 = (stateVariableName) => (e) => {const value = e.target.value; this.setState((state) => ({...state, [stateVariableName]: value}));}

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

    handleSubmit = () => {
        const {requestDate, durationInMinutes, selectedDoctorId} = this.state;
        const {user, requestMedicalExamination} = this.props;

        requestMedicalExamination(user.patientId, selectedDoctorId, requestDate, durationInMinutes);
    }

    render() {
        const {from, to, selectedClinicId, selectedDoctorId, offset, requestDate, durationInMinutes} = this.state;
        const {clinics, selectedDoctorWokingTimes} = this.props;

        const doctors = getDoctorsBySelectedClinicId(clinics, selectedClinicId);
        const sortedAndFilteredDoctorWokingTimes = transformDoctorWokingTimes(from, to)(selectedDoctorWokingTimes);
        
        const totalPages = getTotalPages(elementPerPage, sortedAndFilteredDoctorWokingTimes);
        const renderRows = renderRowsByPage(elementPerPage, offset + 1, this.handleSubmit, requestDate, durationInMinutes, this.handleChange2('durationInMinutes'), this.handleChange('requestDate')); //todo

        console.log(durationInMinutes);

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
                                        <DoctorsDropdown disabled={selectedClinicId===0} doctors={doctors} selectedDoctorId={selectedDoctorId} handleSelected={this.handleDoctorDropdownChange}/>
                                    </div>
                                </div>
                                {totalPages > 0 && 
                                    <React.Fragment>
                                        <div className="row">
                                            <div className="col">
                                                <div className="title">
                                                    Open
                                                </div>
                                            </div>
                                            <div className="col">
                                                <div className="title">
                                                    Close
                                                </div>
                                            </div>
                                            <div className="col-1" />
                                        </div>
                                        { renderRows(sortedAndFilteredDoctorWokingTimes) }
                                        { <Paginate pageCount={totalPages} onPageChange={this.handlePageChange} /> }
                                    </React.Fragment>
                                    
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        );
    }
}

const selectors = [clinicsSelector, selectedDoctorWokingTimes, userSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    getAllClinicsWithDoctors: () => dispatch(getAllClinicsWithDoctors.actions.DEFAULT()),
    getDoctorWorkingTimes: (doctorId) => dispatch(getDoctorWorkingTimes.actions.DEFAULT({doctorId})),
    requestMedicalExamination: (patientId, doctorId, requestDate, durationInMinutes) => dispatch(requestMedicalExamination.actions.DEFAULT({patientId, doctorId, requestDate, durationInMinutes}))
});


export default connect(mapStateToProps, mapDispatchToProps)(RequestNewExamination);