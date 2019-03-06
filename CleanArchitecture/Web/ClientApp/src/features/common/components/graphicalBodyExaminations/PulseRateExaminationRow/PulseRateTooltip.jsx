import React from 'react';
import {  } from "../../DatePicker";
import DatePicker from "react-datepicker";
import { head, path, pipe, prop } from "ramda";

import "./pulse-rate-tooltip.css";

const getExaminationDate = pipe(head, path(['payload', 'examinationDate']));
const getPusleRate = pipe(head, prop('value'))

const PulseRateTooltip = ({ payload, label, active }) => {
    return active 
        ? ( <div className="pulse-rate-tooltip">
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
                    Pusle Rate:
                </div>
                <div className="col text">
                    {`${getPusleRate(payload)} bpm`}
                </div>
            </div>
        </div>)
        : null;
}

export default PulseRateTooltip;