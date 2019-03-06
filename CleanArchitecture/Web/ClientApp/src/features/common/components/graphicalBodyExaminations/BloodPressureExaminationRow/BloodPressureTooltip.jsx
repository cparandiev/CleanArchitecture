import React from 'react';
import {  } from "../../DatePicker";
import DatePicker from "react-datepicker";
import { head, path, pipe, prop, nth } from "ramda";

import "./blood-pressure-tooltip.css";

const getExaminationDate = pipe(head, path(['payload', 'examinationDate']));
const getSystolicBloodPressure = pipe(head, prop('value'), nth(1));
const getDiastolicBloodPressure = pipe(head, prop('value'), nth(0));

const BloodPressureTooltip = ({ payload, label, active }) => {
    return active 
        ? ( <div className="blood-pressure-tooltip">
            <div className="row">
                <div className="col title">
                    Examination Date: 
                </div>
                <div className="col">
                    <DatePicker selected={getExaminationDate(payload)}  className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                </div>
            </div>
            <div className="row">
                <div className="col title">
                    Systolic Blood Pressure:
                </div>
                <div className="col text">
                    {`${getSystolicBloodPressure(payload)} mmHg`}
                </div>
            </div>
            <div className="row">
                <div className="col title">
                    Diastolic Blood Pressure:
                </div>
                <div className="col text">
                    {`${getDiastolicBloodPressure(payload)} mmHg`}
                </div>
            </div>
        </div>)
        : null;
}

export default BloodPressureTooltip;