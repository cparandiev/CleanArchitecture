import React, { Component } from 'react';
import { connect } from 'react-redux';
import { map, compose } from 'ramda';

import DatePicker from "./components/DatePicker";
import WorkingTimeUnit from "./components/WorkingTimeUnit";
import {userSelector, selectedDoctorWokingTimes} from "../common/selectors";
import {getDoctorWorkingTimes} from "../common/actions";
import mergeSelectors from "../../utils/mergeSelectors";
import './doctor-working-time.css';
import Paginate from "../common/components/Paginate";
import {orderWorkingTimes, filterWorkingTimes} from "./utils";
import {getCurrentElements, getTotalPages} from "../../utils/paginate";
import { deleteDoctorWorkingTime } from "./actions";

const transformDoctorWokingTimes = (from, to) => compose(
    orderWorkingTimes,
    filterWorkingTimes(from, to),
)

const renderRowsByPage = (elementPerPage, currentPage, onDelete) => compose(
    map((({open, close, id}) => <WorkingTimeUnit onDelete={onDelete} id={id} key={id} from={open} to={close}/>)),
    getCurrentElements(elementPerPage, currentPage),
)

const elementPerPage = 5;

class DoctorWorkingTime extends Component {
    state = {from: new Date(), to: new Date(), offset: 0}

    handleChangeFrom = (date) => {this.setState((state) => ({...state, from: date}));}

    handleChangeTo = (date) => {this.setState((state) => ({...state, to: date}));}

    handlePageChange = (data) => { this.setState((state) => ({...state, offset: data.selected}));}

    componentDidMount(){
        const {user, getDoctorWorkingTimes} = this.props;
        getDoctorWorkingTimes(user.doctorId);
    }

    render() {
        const {from, to, offset} = this.state;
        const {selectedDoctorWokingTimes, deleteDoctorWorkingTime} = this.props;

        const sortedAndFilteredDoctorWokingTimes = transformDoctorWokingTimes(from, to)(selectedDoctorWokingTimes);
        const totalPages = getTotalPages(elementPerPage, sortedAndFilteredDoctorWokingTimes);
        const renderRows = renderRowsByPage(elementPerPage, offset + 1, deleteDoctorWorkingTime);

        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col">
                                        <h5 className="card-title">Select a time range</h5>
                                    </div>
                                    <div className="col">
                                        <button className="btn btn-primary float-right">Add new working time</button>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-5 offset-1">
                                        <DatePicker title='From' value={from} handleChange={this.handleChangeFrom}/>
                                    </div>
                                    <div className="col-5">
                                        <DatePicker title='To' value={to} handleChange={this.handleChangeTo}/>
                                    </div>
                                </div>
                                {(totalPages > 0) &&
                                (<div className="working-time-unit-container">
                                    <div className="row">
                                        <div className="col-5 title">
                                            Open
                                        </div>
                                        <div className="col-5 title">
                                            Close
                                        </div>
                                        <div className="col-2 title">
                                            Actions
                                        </div>
                                    </div>
                                    { renderRows(sortedAndFilteredDoctorWokingTimes) }
                                    { <Paginate pageCount={totalPages} onPageChange={this.handlePageChange} />}
                                </div>)}
                            </div>                
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const selectors = [userSelector, selectedDoctorWokingTimes];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    getDoctorWorkingTimes: (doctorId) => dispatch(getDoctorWorkingTimes.actions.DEFAULT({doctorId})),
    deleteDoctorWorkingTime: (workingTimeId) => dispatch(deleteDoctorWorkingTime.actions.DEFAULT({workingTimeId})),
});

export default connect(mapStateToProps, mapDispatchToProps)(DoctorWorkingTime);