import React, { Component } from 'react';
import { connect } from 'react-redux';
import { map, isNil, isEmpty } from 'ramda';
import ReactPaginate from 'react-paginate';
import MaterialIcon from 'material-icons-react';

import DatePicker from "./components/DatePicker";
import WorkingTimeUnit from "./components/WorkingTimeUnit";
import {userSelector, selectedDoctorWokingTimes} from "../common/selectors";
import {getDoctorWorkingTimes} from "../common/actions";
import mergeSelectors from "../../utils/mergeSelectors";
import './doctor-working-time.css';

class DoctorWorkingTime extends Component {
    state = {from: new Date(), to: new Date(), offset: 0}

    handleChangeFrom = (date) => {
        this.setState((state) => {
            return {...state, from: date}
        });
    }

    handleChangeTo = (date) => {
        this.setState((state) => {
            return {...state, to: date}
        });
    }

    handlePageChange = (data) => {
        this.setState((state) => ({...state, offset: data.offset}));
    }

    componentDidMount(){
        const {user, getDoctorWorkingTimes} = this.props;

        getDoctorWorkingTimes(user.doctorId);
    }

    render() {
        const {from, to} = this.state;
        const {selectedDoctorWokingTimes} = this.props;

        console.log(selectedDoctorWokingTimes);
        return (
            // <div style={{fontWeight: 'bold', color: 'white', fontSize: '40px'}}>
            //     DOCTOR WEEKLY TIME PAGE
            // </div>
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
                                <div className="working-time-unit-container">
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
                                    {!isNil(selectedDoctorWokingTimes) && !isEmpty(selectedDoctorWokingTimes) && Array.isArray(selectedDoctorWokingTimes) &&
                                        map((({open, close, id}) => <WorkingTimeUnit key={id} from={open} to={close}/>), selectedDoctorWokingTimes)
                                    }
                                    <nav aria-label="Page navigation example">
                                    <ReactPaginate
                                        pageClassName='page-item'
                                        pageLinkClassName='page-link'
                                        previousClassName='page-item'
                                        previousLinkClassName='page-link'
                                        nextClassName='page-item'
                                        nextLinkClassName='page-link'

                                        previousLabel={<MaterialIcon icon="arrow_back_ios" size="14" />}
                                        nextLabel={<MaterialIcon icon="arrow_forward_ios" size="14" />}
                                        // previousLabel={'previous'}
                                        // nextLabel={'next'}
                                        breakLabel={<MaterialIcon icon="more_horiz" size="14" />}
                                        breakClassName={'page-item'}
                                        breakLinkClassName='page-link'
                                        pageCount={this.state.pageCount}
                                        marginPagesDisplayed={2}
                                        pageRangeDisplayed={5}
                                        onPageChange={this.handlePageClick}
                                        containerClassName={'pagination'}
                                        subContainerClassName={'pages pagination'}
                                        activeClassName={'active'}
                                        />
                                    </nav>
                                </div>
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
});

export default connect(mapStateToProps, mapDispatchToProps)(DoctorWorkingTime);