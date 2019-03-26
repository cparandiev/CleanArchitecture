import React, { Component } from 'react';
import { Link } from "react-router-dom";
import Toggle from "react-toggle";
import { connect } from 'react-redux';
import { compose, map, head, prop, pipe } from "ramda";

import routesConfig from "../../routes/routesConfig";
import DatePicker from "../common/components/DatePicker";
import BodyExaminationRow from "../common/components/BodyExaminationRow";
import Paginate from "../common/components/Paginate";
import { BloodOxygenLevelExaminationRow, BloodPressureExaminationRow, BodyTemperatureExaminationRow, PulseRateExaminationRow } from "../common/components/graphicalBodyExaminations";
import { getPatienBodyExaminations } from "../common/actions";
import { userSelector, selectedPatientBodyExaminations, selectedPatientBodyTemperatureExaminations, selectedPatientBloodPressureExaminations, selectedPatientPulseRateExaminations, selectedPatientBloodOxygenLevelExaminations} from "../common/selectors";
import mergeSelectors from "../../utils/mergeSelectors";
import {filterBodyExaminations, orderBodyExaminations} from "../common/utils";
import {getCurrentElements, getTotalPages} from "../../utils/paginate";
import userHasRole from "../../utils/userHasRole";

const transformPatientBodyExaminations = (from, to) => compose(
    orderBodyExaminations,
    filterBodyExaminations(from, to),
);


const renderRowsByPage = (elementPerPage, currentPage) => compose(
    map(((props) =><BodyExaminationRow key={props.id} {...props}/> )),
    getCurrentElements(elementPerPage, currentPage),
)

const getPatientName = pipe(head, prop('patient'));

const elementPerPage = 5;

class PatientBodyExaminations extends Component {
    state = {from: new Date('2010-01-12T20:01:00'), to: new Date(), offset: 0, graphicalView: false}

    handleChangeFrom = (date) => {this.setState((state) => ({...state, from: date}));}
    handleChangeTo = (date) => {this.setState((state) => ({...state, to: date}));}
    handlePageChange = (data) => { this.setState((state) => ({...state, offset: data.selected}));}
    handleBaconChange = (e) => {const value = e.target.checked;this.setState((state) => ({...state, graphicalView: value}));};

    componentDidMount(){
        const {match: {params : {patientId}}, getPatienBodyExaminations} = this.props;

        getPatienBodyExaminations(patientId);
    }

    render() {
        const {from, to, offset, graphicalView} = this.state;
        const {user, selectedPatientBodyExaminations, selectedPatientBodyTemperatureExaminations, selectedPatientBloodPressureExaminations, selectedPatientPulseRateExaminations, selectedPatientBloodOxygenLevelExaminations } = this.props;

        const sortedAndFilteredPatientBodyExaminations = transformPatientBodyExaminations(from, to)(selectedPatientBodyExaminations);
        const totalPages = getTotalPages(elementPerPage, sortedAndFilteredPatientBodyExaminations);
        const renderRows = renderRowsByPage(elementPerPage, offset + 1);

        const sortedAndFilteredPatientBodyTemperatureExaminations = transformPatientBodyExaminations(from, to)(selectedPatientBodyTemperatureExaminations);
        const sortedAndFilteredPatientBloodPressureExaminations = transformPatientBodyExaminations(from, to)(selectedPatientBloodPressureExaminations);
        const sortedAndFilteredPatientPulseRateExaminations = transformPatientBodyExaminations(from, to)(selectedPatientPulseRateExaminations);
        const sortedAndFilteredPatientBloodOxygenLevelExaminations = transformPatientBodyExaminations(from, to)(selectedPatientBloodOxygenLevelExaminations);
        
        const userIsADoctor = userHasRole(user, 'doctor');

        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col">
                                        <h5 className="card-title">
                                        {userIsADoctor
                                            ?  totalPages > 0
                                                ? `${getPatientName(selectedPatientBodyExaminations)} Body Examination`
                                                : "Patient Body Examination"
                                            : "Your Body Examination"}
                                        </h5>
                                    </div>
                                    {!userIsADoctor &&
                                    <div className="col">
                                        <Link to={routesConfig.addBodyExamination.path} className="btn btn-primary float-right">
                                            Add body examination
                                        </Link>
                                    </div>}
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
                                        <BloodPressureExaminationRow data={sortedAndFilteredPatientBloodPressureExaminations}/>
                                        <BloodOxygenLevelExaminationRow data={sortedAndFilteredPatientBloodOxygenLevelExaminations}/>
                                        <BodyTemperatureExaminationRow data={sortedAndFilteredPatientBodyTemperatureExaminations} />
                                        <PulseRateExaminationRow data={sortedAndFilteredPatientPulseRateExaminations}/>
                                    </React.Fragment>) 
                                    : (<div>
                                        {renderRows(sortedAndFilteredPatientBodyExaminations)}
                                        <Paginate pageCount={totalPages} onPageChange={this.handlePageChange} /> 
                                    </div>)}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
const selectors = [userSelector, selectedPatientBodyExaminations, selectedPatientBodyTemperatureExaminations, selectedPatientBloodPressureExaminations, selectedPatientPulseRateExaminations, selectedPatientBloodOxygenLevelExaminations];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    getPatienBodyExaminations: (patientId) => dispatch(getPatienBodyExaminations.actions.DEFAULT({patientId})),
});

export default connect(mapStateToProps, mapDispatchToProps)(PatientBodyExaminations);
