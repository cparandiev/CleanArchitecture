import React, { Component } from 'react';
import { map, split, pipe, nth } from "ramda";

import BaseExaminationRow from "../BaseExaminationRow";
import BodyTemperatureTooltip from "./BodyTemperatureTooltip";
import { addDateLabelProp, orderBodyExaminations } from "../utils";

const data = [
    {temperature: 36.6, examinationDate: new Date("2019-02-20T10:30:00")},
    {temperature: 37.6, examinationDate: new Date("2019-02-21T10:30:00")},
    {temperature: 35.6, examinationDate: new Date("2019-02-22T10:30:00")},
    {temperature: 34.6, examinationDate: new Date("2019-02-23T10:30:00")},
    {temperature: 38.6, examinationDate: new Date("2019-02-24T10:30:00")},
    {temperature: 36.3, examinationDate: new Date("2019-02-25T10:30:00")},
]

const transformData = pipe(
    orderBodyExaminations,
    addDateLabelProp
);

const minHealthyValue = 36.5;
const maxHealthyValue = 37.5;

const xTickFormatter = pipe(split(' '), nth(2));

class BloodOxygenLevelExaminationRow extends Component {
    render() {
        const transformedData = transformData(data);

        return (
            <BaseExaminationRow title="Body Temprature" data={transformedData} dataKey={'temperature'} minHealthyValue={minHealthyValue} maxHealthyValue={maxHealthyValue}
            xDataKey="examinationDateShort" xTickFormatter={xTickFormatter} yUnit="°C" CustomTooltip={BodyTemperatureTooltip}/>
        ); 
    }
}

export default BloodOxygenLevelExaminationRow;