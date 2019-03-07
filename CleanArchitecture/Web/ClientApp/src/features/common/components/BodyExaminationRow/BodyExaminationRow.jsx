import React, { Component } from 'react';
import PropTypes from 'prop-types';
import RDatePicker from "react-datepicker";
import MaterialIcon from 'material-icons-react';

import { BloodOxygenLevelRow, BloodPressureRow, BodyTemperatureRow, PulseRateRow } from "./SubRows";
import "./body-examination-row.css";

class BodyExaminationRow extends Component {
    state = {expand: false}

    toggleOpen = () => {this.setState((state) => ({...state, expand: !state.expand}));}

    render() {
        const {expand} = this.state;
        const {examinationDate, pulseRate, bloodOxygenLevel, bodyTemperature, bloodPressure} = this.props;

        return (
            <div className="body-examination-row-container-wrapper">
                <div className="body-examination-row-container">
                    <div className="row body-examination-row align-items-center">
                        <div className="col-3 title offset-1">
                            Examination Date
                        </div>
                        <div className="col-3">
                            <RDatePicker selected={examinationDate} className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                        </div>
                        <div className="col-1 offset-3">
                            <MaterialIcon key={expand} className="material-icons 32 md-dark clickable-icon float-right" icon={expand ? "expand_less"  : "expand_more"} size="32" onClick={this.toggleOpen}/>
                        </div>
                    </div>
                    {expand && 
                        <React.Fragment>
                            {bloodPressure && <BloodPressureRow systolicBloodPressure={bloodPressure.systolicBloodPressure} diastolicBloodPressure={bloodPressure.diastolicBloodPressure}/>}
                            {bloodOxygenLevel && <BloodOxygenLevelRow oxygenLevel={bloodOxygenLevel.oxygenLevel}/>}
                            {bodyTemperature && <BodyTemperatureRow temperature={bodyTemperature.temperature}/>}
                            {pulseRate && <PulseRateRow rate={pulseRate.rate}/>}
                        </React.Fragment>
                    }
                </div>
            </div>
        );
    }
}

BodyExaminationRow.propTypes = {
    examinationDate: PropTypes.instanceOf(Date),
};

export default BodyExaminationRow;