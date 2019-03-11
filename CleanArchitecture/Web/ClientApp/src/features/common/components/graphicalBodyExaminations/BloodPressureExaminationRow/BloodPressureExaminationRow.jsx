import React, { Component } from 'react';
import { map, split, pipe, nth, isEmpty } from "ramda";

import BaseExaminationRow from "../BaseExaminationRow";
import BloodPressureTooltip from "./BloodPressureTooltip";
import { orderBodyExaminations, addDateLabelProp } from "../utils";
import { mergePressureFields } from "./utils";

// const data = [
//     {systolicBloodPressure: 110, diastolicBloodPressure: 80, examinationDate: new Date("2019-02-20T10:30:00")},
//     {systolicBloodPressure: 100, diastolicBloodPressure: 60, examinationDate: new Date("2019-02-21T10:30:00")},
//     {systolicBloodPressure: 130, diastolicBloodPressure: 90, examinationDate: new Date("2019-02-22T10:30:00")},
//     {systolicBloodPressure: 150, diastolicBloodPressure: 110, examinationDate: new Date("2019-02-23T10:30:00")},
//     {systolicBloodPressure: 90, diastolicBloodPressure: 60, examinationDate: new Date("2019-02-24T10:30:00")},
//     {systolicBloodPressure: 110, diastolicBloodPressure: 80, examinationDate: new Date("2019-02-25T10:30:00")},
// ]

const transformData = pipe(
    orderBodyExaminations,
    addDateLabelProp,
    map(a => ({...a, systolicBloodPressure: a.bloodPressure.systolicBloodPressure, diastolicBloodPressure: a.bloodPressure.diastolicBloodPressure})), //todo
    mergePressureFields
);

const minHealthyValue = 90;
const maxHealthyValue = 120;

const xTickFormatter = pipe(split(' '), nth(2));

class BloodPressureExaminationRow extends Component {
    render() {
        const {data} = this.props;

        return isEmpty(data)
            ? null
            : (<BaseExaminationRow title="Blood Pressure" data={transformData(data)} dataKey={'bloodPressure'} minHealthyValue={minHealthyValue} maxHealthyValue={maxHealthyValue}
                xDataKey="examinationDateShort" xTickFormatter={xTickFormatter} CustomTooltip={BloodPressureTooltip} />);
    }
}

export default BloodPressureExaminationRow;