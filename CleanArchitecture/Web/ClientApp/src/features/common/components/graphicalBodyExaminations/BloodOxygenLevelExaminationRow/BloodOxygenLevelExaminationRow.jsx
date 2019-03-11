import React, { Component } from 'react';
import { map, split, pipe, nth, isEmpty } from "ramda";

import BaseExaminationRow from "../BaseExaminationRow";
import BloodOxygenTooltip  from "./BloodOxygenTooltip";
import { addDateLabelProp, orderBodyExaminations } from "../utils";

// const data = [
//     {oxygenLevel: 90, examinationDate: new Date("2019-02-20T10:30:00")},
//     {oxygenLevel: 98, examinationDate: new Date("2019-02-21T10:30:00")},
//     {oxygenLevel: 94, examinationDate: new Date("2019-02-22T10:30:00")},
//     {oxygenLevel: 95, examinationDate: new Date("2019-02-23T10:30:00")},
//     {oxygenLevel: 93, examinationDate: new Date("2019-02-24T10:30:00")},
//     {oxygenLevel: 86, examinationDate: new Date("2019-02-25T10:30:00")},
// ]

const transformData = pipe(
    orderBodyExaminations,
    addDateLabelProp,
    map(a => ({...a, oxygenLevel: a.bloodOxygenLevel.oxygenLevel})) // todo
);

const minHealthyValue = 92;
const maxHealthyValue = 100;

const xTickFormatter = pipe(split(' '), nth(2));

class BloodOxygenLevelExaminationRow extends Component {
    render() {
        const {data} = this.props;

        return isEmpty(data)
            ? null
            : (<BaseExaminationRow title="Blood Oxygen Level" data={transformData(data)} dataKey={'oxygenLevel'} minHealthyValue={minHealthyValue} maxHealthyValue={maxHealthyValue}
                xDataKey="examinationDateShort" xTickFormatter={xTickFormatter} yUnit="%" CustomTooltip={BloodOxygenTooltip}/>);
    }
}

export default BloodOxygenLevelExaminationRow;