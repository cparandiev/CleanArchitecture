import React, { Component } from 'react';
import { Link } from "react-router-dom";
import Toggle from "react-toggle";

import routesConfig from "../../routes/routesConfig";
import DatePicker from "../common/components/DatePicker";
import BodyExaminationRow from "../common/components/BodyExaminationRow";
import Paginate from "../common/components/Paginate";
import AreaChart from "../common/components/AreaChart";

class PatientBodyЕxaminations extends Component {
    state = {from: new Date('2010-01-12T20:01:00'), to: new Date(), offset: 0, graphicalView: true}

    handleChangeFrom = (date) => {this.setState((state) => ({...state, from: date}));}
    handleChangeTo = (date) => {this.setState((state) => ({...state, to: date}));}
    handlePageChange = (data) => { this.setState((state) => ({...state, offset: data.selected}));}
    handleBaconChange = (e) => {const value = e.target.checked;this.setState((state) => ({...state, graphicalView: value}));};

    render() {
        const {from, to, offset, graphicalView} = this.state;
        // console.log(graphicalView);
        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col">
                                        <h5 className="card-title">Body Examination</h5>
                                    </div>
                                    <div className="col">
                                        <Link to={routesConfig.home.path} className="btn btn-primary float-right"> {/* todo */}
                                            Add body examination
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
                                <div className="row">
                                    <div className="col-2 title">
                                        Graphical View
                                    </div>
                                    <div className="col">
                                    <Toggle
                                        checked={graphicalView}
                                        onChange={this.handleBaconChange} />
                                    </div>
                                </div>
                                
                                {graphicalView 
                                    ? (<React.Fragment>
                                        <div style={{backgroundColor: "#F8F9FA", margin: "0 -20px"}}>
                                            <div className="row justify-content-md-center">
                                                <div className="col col-md-auto title">
                                                    Blood Oxygen Level
                                                </div>
                                            </div>
                                            <div className="row justify-content-md-center">
                                                <div className="col col-md-auto">
                                                    <AreaChart />
                                                </div>
                                            </div>
                                        </div>
                                        <div className="row justify-content-md-center">
                                            <div className="col col-md-auto title">
                                                Blood Pressure
                                            </div>
                                        </div>
                                        <div className="row justify-content-md-center">
                                            <div className="col col-md-auto">
                                                <AreaChart />
                                            </div>
                                        </div>
                                        <div style={{backgroundColor: "#F8F9FA", margin: "0 -20px"}}>
                                            <div className="row justify-content-md-center">
                                                <div className="col col-md-auto title">
                                                    Body Temperature
                                                </div>
                                            </div>
                                            <div className="row justify-content-md-center">
                                                <div className="col col-md-auto">
                                                    <AreaChart />
                                                </div>
                                            </div>
                                        </div>
                                        <div className="row justify-content-md-center">
                                            <div className="col col-md-auto title">
                                                Pulse Rate
                                            </div>
                                        </div>
                                        <div className="row justify-content-md-center">
                                            <div className="col col-md-auto">
                                                <AreaChart />
                                            </div>
                                        </div>
                                    </React.Fragment>) 
                                    : (<div>
                                        <BodyExaminationRow examinationDate={new Date()}/>
                                        <BodyExaminationRow examinationDate={new Date()}/>
                                        <BodyExaminationRow examinationDate={new Date()}/>
                                        <BodyExaminationRow examinationDate={new Date()}/>
                                        <BodyExaminationRow examinationDate={new Date()}/>
                                        {/* todo */}
                                        <Paginate pageCount={3} onPageChange={this.handlePageChange} /> 
                                    </div>)}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}


export default PatientBodyЕxaminations;