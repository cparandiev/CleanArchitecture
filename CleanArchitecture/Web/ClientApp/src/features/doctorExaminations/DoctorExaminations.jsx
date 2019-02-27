import React, { Component } from 'react';
import { connect } from "react-redux";
import { compose, map } from "ramda";

import { userSelector } from "../common/selectors";
import { getDoctorExaminations, reviewMedicalExamination } from "./actions";
import mergeSelectors from "../../utils/mergeSelectors";
import { examinationsSelector } from "./selectors";
import {getCurrentElements, getTotalPages} from "../../utils/paginate";
import Paginate from "../common/components/Paginate";
import { filterExaminations, orderExaminations } from "./utils";
import RangePicker from "./components/RangePicker";
import ExaminationRow from "./components/ExaminationRow";

const transformExaminations = (from, to) => compose(
    orderExaminations,
    filterExaminations(from, to),
)

const renderRowsByPage = (elementPerPage, currentPage, reviewMedicalExamination) => compose(
    map(((props) => <ExaminationRow key={props.id} {...props} handleReview={reviewMedicalExamination}/>)),
    getCurrentElements(elementPerPage, currentPage),
)

const elementPerPage = 5;

class DoctorExaminations extends Component {
    state = {from: new Date('2010-01-12T20:01:00'), to: new Date(), offset: 0}

    handlePageChange = (data) => { this.setState((state) => ({...state, offset: data.selected}));}
    
    handleChange = (stateVariableName) => (value) => {this.setState((state) => ({...state, [stateVariableName]: value}));}

    fetchCurrentDoctorExaminations = () => {
        const {getDoctorExaminations, user} = this.props;
        getDoctorExaminations(user.doctorId);
    }

    componentDidMount(){
        this.fetchCurrentDoctorExaminations();
    }
    
    render() {
        const { from, to, offset } = this.state;
        const { examinations, reviewMedicalExamination } = this.props;

        const sortedAndFilteredExaminations = transformExaminations(from, to)(examinations);
        const totalPages = getTotalPages(elementPerPage, sortedAndFilteredExaminations);
        const renderRows = renderRowsByPage(elementPerPage, offset + 1, reviewMedicalExamination);
        
        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col">
                                        <h5 className="card-title">Your Medical Examination</h5>
                                    </div>
                                </div>
                                <RangePicker handleChangeFrom={this.handleChange('from')} handleChangeTo={this.handleChange('to')} titleFrom="From" titleTo="To" dateFrom={from} dateTo={to}/>
                                {totalPages > 0 && 
                                    <React.Fragment>
                                        <hr/>
                                        <div className="row align-items-center">
                                            <div className="col-3 d-flex justify-content-center title">
                                                Date
                                            </div>
                                            <div className="col-3 d-flex justify-content-center title">
                                                Patient
                                            </div>
                                            <div className="col-2 d-flex justify-content-center title">
                                                Approved
                                            </div>
                                            <div className="col-2 d-flex justify-content-center title">
                                                Accomplished
                                            </div>
                                            <div className="col-2 d-flex justify-content-center title">
                                                Actions
                                            </div>
                                        </div>
                                        {renderRows(sortedAndFilteredExaminations)}
                                        <Paginate pageCount={totalPages} onPageChange={this.handlePageChange} />
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

const selectors = [userSelector, examinationsSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    getDoctorExaminations: (doctorId) => dispatch(getDoctorExaminations.actions.DEFAULT({doctorId})),
    reviewMedicalExamination: (id, isApproved) => dispatch(reviewMedicalExamination.actions.DEFAULT({id, isApproved}))
});

export default connect(mapStateToProps, mapDispatchToProps)(DoctorExaminations);