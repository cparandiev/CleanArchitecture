import React, { Component } from 'react';
import { map, split, pipe, nth, isEmpty } from "ramda";

import BaseExaminationRow from "../BaseExaminationRow";
import BodyTemperatureTooltip from "./BodyTemperatureTooltip";
import { addDateLabelProp, orderBodyExaminations } from "../utils";

// const data = [
//     {temperature: 36.6, examinationDate: new Date("2019-02-20T10:30:00")},
//     {temperature: 37.6, examinationDate: new Date("2019-02-21T10:30:00")},
//     {temperature: 35.6, examinationDate: new Date("2019-02-22T10:30:00")},
//     {temperature: 34.6, examinationDate: new Date("2019-02-23T10:30:00")},
//     {temperature: 38.6, examinationDate: new Date("2019-02-24T10:30:00")},
//     {temperature: 36.3, examinationDate: new Date("2019-02-25T10:30:00")},
// ]

const transformData = pipe(
    orderBodyExaminations,
    addDateLabelProp,
    map(a => ({...a, temperature: a.bodyTemperature.temperature})) //todo
);

const minHealthyValue = 36.5;
const maxHealthyValue = 37.5;

const xTickFormatter = pipe(split(' '), nth(2));

class BodyTemperatureExaminationRow extends Component {
    render() {
        const {data} = this.props;
        if(isEmpty(data)) //todo
            return null;

        return (
            <BaseExaminationRow title="Body Temprature" data={transformData(data)} dataKey={'temperature'} minHealthyValue={minHealthyValue} maxHealthyValue={maxHealthyValue}
            xDataKey="examinationDateShort" xTickFormatter={xTickFormatter} yUnit="°C" CustomTooltip={BodyTemperatureTooltip}/>
        ); 
    }
}

export default BodyTemperatureExaminationRow;