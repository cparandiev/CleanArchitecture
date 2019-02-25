import React, { Component } from 'react';
import DatePicker from "../common/components/DatePicker";
import { connect } from "react-redux";

import { addWorkingTime } from "./actions";
import mergeSelectors from "../../utils/mergeSelectors";
import { userSelector } from "../common/selectors";

class AddWorkingTime extends Component {
    state = {open: new Date(), close: new Date(), numOfWeeks: 0}

    handleChangeOpen = (date) => {this.setState((state) => ({...state, open: date}));}

    handleChangeClose = (date) => {this.setState((state) => ({...state, close: date}));}

    handleSubmit = () => {
        const {open, close, numOfWeeks} = this.state;
        const {addWorkingTime, user} = this.props;

        addWorkingTime(user.doctorId)(open, close, numOfWeeks);
    }

    handleChange = (e) => {
        const value = e.target.value;
        this.setState((state) => ({...state, numOfWeeks: value}));
    }

    render() {
        const {open, close, numOfWeeks} = this.state;

        return (
            <div className="container">
                <div className="card col-8 offset-2">
                    <div className="card-body">
                        <div className="row">
                            <div className="col">
                                <h5 className="card-title">Add working time</h5>
                            </div>                        
                        </div>
                        <DatePicker title='Open' value={open} handleChange={this.handleChangeOpen} datePickerContainerClassName="col-6" rowClassName="row justify-content-md-center"  titleContainerClassName="col-4 col-form-label"/>
                        <DatePicker title='Close' value={close} handleChange={this.handleChangeClose} datePickerContainerClassName="col-6" rowClassName="row justify-content-md-center" titleContainerClassName="col-4 col-form-label"/>
                        <div className="row justify-content-md-center">
                            <div className="col-4 col-form-label">
                                <label className="title" htmlFor="numOfWeeks">Number of weeks</label>
                            </div>
                            <div className="col-6">
                                <input type="number" className="form-control" id="numOfWeeks" placeholder="Number of weeks" value={numOfWeeks} onChange={this.handleChange}/>
                            </div>
                        </div>
                        <div className="text-center">
                            <button type="button" className="btn btn-primary" onClick={this.handleSubmit}>Create</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const selectors = [userSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    addWorkingTime: (doctorId) => (open, close, numOfWeeks) => dispatch(addWorkingTime.actions.DEFAULT({numOfWeeks,workingTimes: [{open, close}]}, {doctorId}))
});

export default connect(mapStateToProps, mapDispatchToProps)(AddWorkingTime);