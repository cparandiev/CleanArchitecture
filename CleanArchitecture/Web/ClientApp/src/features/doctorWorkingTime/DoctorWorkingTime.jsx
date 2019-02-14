import React, { Component } from 'react';
import DatePicker from "react-datepicker";

import './doctor-working-time.css';

class DoctorWorkingTime extends Component {
    state = {from: new Date(), to: new Date()}

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

    render() {
        const a = new Date();
        return (
            // <div style={{fontWeight: 'bold', color: 'white', fontSize: '40px'}}>
            //     DOCTOR WEEKLY TIME PAGE
            // </div>
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <h5 className="card-title">Select a time range</h5>
                                <div className="row">
                                    <div className="col-5 offset-1">
                                        <div className="row">
                                            <div className="col-2 col-form-label">
                                                <label htmlFor="from-date">From</label>
                                            </div>
                                            <div className="col">
                                                <DatePicker showTimeSelect name="from-date" selected={this.state.from} onChange={this.handleChangeFrom} className="form-control"
                                                    timeFormat="HH:mm" timeIntervals={15} dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="col-5">
                                        <div className="row">
                                            <div className="col-1 col-form-label">
                                                <label htmlFor="from-to">To</label>
                                            </div>
                                            <div className="col">
                                                <DatePicker showTimeSelect name="from-to" selected={this.state.to} onChange={this.handleChangeTo} className="form-control"
                                                    timeFormat="HH:mm" timeIntervals={15} dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                                            </div>
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

export default DoctorWorkingTime;