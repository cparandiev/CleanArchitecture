import React, { Component } from 'react';
import { map, split, pipe, nth } from "ramda";

import BaseExaminationRow from "../BaseExaminationRow";
import BloodOxygenTooltip  from "./BloodOxygenTooltip";
import { addDateLabelProp, orderBodyExaminations } from "../utils";

const data = [
    {oxygenLevel: 90, examinationDate: new Date("2019-02-20T10:30:00")},
    {oxygenLevel: 98, examinationDate: new Date("2019-02-21T10:30:00")},
    {oxygenLevel: 94, examinationDate: new Date("2019-02-22T10:30:00")},
    {oxygenLevel: 95, examinationDate: new Date("2019-02-23T10:30:00")},
    {oxygenLevel: 93, examinationDate: new Date("2019-02-24T10:30:00")},
    {oxygenLevel: 86, examinationDate: new Date("2019-02-25T10:30:00")},
]

const transformData = pipe(
    orderBodyExaminations,
    addDateLabelProp
);

const minHealthyValue = 92;
const maxHealthyValue = 100;

const xTickFormatter = pipe(split(' '), nth(2));

class BloodOxygenLevelExaminationRow extends Component {
    render() {
        const transformedData = transformData(data);

        return (
            <BaseExaminationRow title="Blood Oxygen Level" data={transformedData} dataKey={'oxygenLevel'} minHealthyValue={minHealthyValue} maxHealthyValue={maxHealthyValue}
            xDataKey="examinationDateShort" xTickFormatter={xTickFormatter} yUnit="%" CustomTooltip={BloodOxygenTooltip}/>
        );
    }
}

export default BloodOxygenLevelExaminationRow;