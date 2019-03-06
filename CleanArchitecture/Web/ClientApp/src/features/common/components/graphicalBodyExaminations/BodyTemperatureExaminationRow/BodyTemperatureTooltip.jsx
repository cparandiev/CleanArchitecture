import React from 'react';
import {  } from "../../DatePicker";
import DatePicker from "react-datepicker";
import { head, path, pipe, prop } from "ramda";

import "./body-temperature-tooltip.css";

const getExaminationDate = pipe(head, path(['payload', 'examinationDate']));
const getBodyTemperature = pipe(head, prop('value'))

const BodyTemperatureTooltip = ({ payload, label, active }) => {
    return active 
        ? ( <div className="body-temperature-tooltip">
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
                    Body Temperature:
                </div>
                <div className="col text">
                    {`${getBodyTemperature(payload)} °C`}
                </div>
            </div>
        </div>)
        : null;
}

export default BodyTemperatureTooltip;