import React, { Component } from 'react';
import { connect } from "react-redux";
import { compose } from "ramda";
import DatePicker from "react-datepicker";
import MaterialIcon from 'material-icons-react';

import { userSelector } from "../common/selectors";
import { getDoctorExaminations } from "./actions";
import mergeSelectors from "../../utils/mergeSelectors";
import { examinationsSelector } from "./selectors";
import {getCurrentElements, getTotalPages} from "../../utils/paginate";
import Paginate from "../common/components/Paginate";
import { filterExaminations, orderExaminations } from "./utils";
import RangePicker from "./components/RangePicker";

const transformExaminations = (from, to) => compose(
    orderExaminations,
    filterExaminations(from, to),
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
        const { from, to } = this.state;
        const { examinations } = this.props;

        const sortedAndFilteredExaminations = transformExaminations(from, to)(examinations);
        const totalPages = getTotalPages(elementPerPage, sortedAndFilteredExaminations);

        console.log(sortedAndFilteredExaminations);

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
                                        <div className="row align-items-center">
                                            <div className="col d-flex justify-content-center title">
                                                Date
                                            </div>
                                            <div className="col d-flex justify-content-center title">
                                                Patient
                                            </div>
                                            <div className="col d-flex justify-content-center title">
                                                Approved
                                            </div>
                                            <div className="col d-flex justify-content-center title">
                                                Accomplished
                                            </div>
                                            <div className="col d-flex justify-content-center title">
                                                Actions
                                            </div>
                                        </div>
                                        <div className="row align-items-center">
                                            <div className="col d-flex justify-content-center title">
                                                <DatePicker selected={new Date()}  className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                                            </div>
                                            <div className="col d-flex justify-content-center title">
                                                Cvetko Parandiev
                                            </div>
                                            <div className="col d-flex justify-content-center title">
                                                <MaterialIcon icon={true ? "check_circle" : "block"} size="24"/>
                                            </div>
                                            <div className="col d-flex justify-content-center title">
                                                <MaterialIcon icon={false ? "check_circle" : "block"} size="24" />
                                            </div>
                                            <div className="col d-flex justify-content-center title">
                                                <MaterialIcon icon="rate_review" size="24" />
                                                <MaterialIcon icon="block" size="24" />
                                                <MaterialIcon icon="done" size="24" />
                                                <MaterialIcon icon="info" size="24" />
                                            </div>
                                        </div>
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
});

export default connect(mapStateToProps, mapDispatchToProps)(DoctorExaminations);