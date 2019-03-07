import React from 'react';
import {  } from "../../DatePicker";
import DatePicker from "react-datepicker";
import { head, path, pipe, prop } from "ramda";

import "./blood-oxygen-tooltip.css";

const getExaminationDate = pipe(head, path(['payload', 'examinationDate']));
const getBloodOxygen = pipe(head, prop('value'))

const BloodOxygenTooltip = ({ payload, label, active }) => {
    return active 
        ? ( <div className="blood-oxygen-tooltip">
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
                    Blood Oxygen Level: 
                </div>
                <div className="col text">
                    {`${getBloodOxygen(payload)} %`}
                </div>
            </div>
        </div>)
        : null;
}

export default BloodOxygenTooltip;