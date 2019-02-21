import React, { Component } from 'react';
import {Link} from "react-router-dom";
import { connect } from 'react-redux';
import { compose, map } from "ramda";

import DatePicker from "../common/components/DatePicker";
import Paginate from "../common/components/Paginate";
import routesConfig from "../../routes/routesConfig";
import MedicalExaminationRequestRow from "./components/MedicalExaminationRequestRow";
import {userSelector} from "../common/selectors";
import mergeSelectors from "../../utils/mergeSelectors";
import {getPatientMedicalExaminations} from "./actions";
import {requestsSelector} from "./selectors";
import {filterMedicalExaminations, sortMedicalExaminations} from "./utils";
import {getCurrentElements, getTotalPages} from "../../utils/paginate";
import "./patient-medical-examinations.css";

const transformMedicalExaminations = (from, to) => compose(
    sortMedicalExaminations,
    filterMedicalExaminations(from, to),
);

const renderRowsByPage = (elementPerPage, currentPage) => compose(
    map(((props) =><MedicalExaminationRequestRow key={props.id} {...props}/> )),
    getCurrentElements(elementPerPage, currentPage),
)

const elementPerPage = 5;

class PatientMedicalExaminations extends Component {
    state = {from: new Date('2010-01-12T20:01:00'), to: new Date(), offset: 0}
    
    handleChangeFrom = (date) => {this.setState((state) => ({...state, from: date}));}

    handleChangeTo = (date) => {this.setState((state) => ({...state, to: date}));}

    handlePageChange = (data) => { this.setState((state) => ({...state, offset: data.selected}));}

    handlePageChange = (data) => { this.setState((state) => ({...state, offset: data.selected}));}

    componentDidMount() {
        const {user, getPatientMedicalExaminations} = this.props;
        getPatientMedicalExaminations(user.patientId);
    }

    render() {
        const {from, to, offset} = this.state;
        const {requests} = this.props;
        
        const sortedAndFilteredMedicalExaminations = transformMedicalExaminations(from, to)(requests);
        const totalPages = getTotalPages(elementPerPage, sortedAndFilteredMedicalExaminations);
        const renderRows = renderRowsByPage(elementPerPage, offset + 1);

        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col">
                                        <h5 className="card-title">Medical Examination</h5>
                                    </div>
                                    <div className="col">
                                        <Link to={routesConfig.requestMedicalExamination.path} className="btn btn-primary float-right"> {/* todo */}
                                            Request new examination
                                        </Link>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-5 offset-1">
                                        <DatePicker title='From' value={from} handleChange={this.handleChangeFrom} datePickerContainerClassName="col" rowClassName="row" titleContainerClassName="col-2 col-form-label"/>
                                    </div>
                                    <div className="col-5">
                                        <DatePicker title='To' value={to} handleChange={this.handleChangeTo} datePickerContainerClassName="col" rowClassName="row" titleContainerClassName="col-2 col-form-label"/>
                                    </div>
                                </div>
                                {(totalPages > 0) &&
                                (<React.Fragment>
                                    <hr/>
                                    <div className="medical-examinations-container">
                                        <div className="row align-items-center">
                                            <div className="col-3 d-flex justify-content-center title">
                                                Date
                                            </div>
                                            <div className="col-2 d-flex justify-content-center title">
                                                Clinic
                                            </div>
                                            <div className="col-2 d-flex justify-content-center title">
                                                Doctor
                                            </div>
                                            <div className="col-2 d-flex justify-content-center title">
                                                Approved
                                            </div>
                                            <div className="col-2 d-flex justify-content-center title">
                                                Accomplished
                                            </div>
                                        </div>
                                        {renderRows(sortedAndFilteredMedicalExaminations)}
                                        <Paginate pageCount={totalPages} onPageChange={this.handlePageChange} />
                                    </div>
                                </React.Fragment>)}
                            </div>                
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const selectors = [userSelector, requestsSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    getPatientMedicalExaminations: (patientId) => dispatch(getPatientMedicalExaminations.actions.DEFAULT({patientId})),
});

export default connect(mapStateToProps, mapDispatchToProps)(PatientMedicalExaminations);