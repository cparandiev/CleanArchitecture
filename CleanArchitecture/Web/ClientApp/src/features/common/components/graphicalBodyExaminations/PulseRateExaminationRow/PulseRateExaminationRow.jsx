import React, { Component } from 'react';
import { map, split, pipe, nth, isEmpty } from "ramda";

import BaseExaminationRow from "../BaseExaminationRow";
import PulseRateTooltip from "./PulseRateTooltip";
import { addDateLabelProp, orderBodyExaminations } from "../utils";

// const data = [
//     {rate: 70, examinationDate: new Date("2019-02-20T10:30:00")},
//     {rate: 88, examinationDate: new Date("2019-02-21T10:30:00")},
//     {rate: 90, examinationDate: new Date("2019-02-22T10:30:00")},
//     {rate: 110, examinationDate: new Date("2019-02-23T10:30:00")},
//     {rate: 96, examinationDate: new Date("2019-02-24T10:30:00")},
//     {rate: 78, examinationDate: new Date("2019-02-25T10:30:00")},
// ]

const transformData = pipe(
    orderBodyExaminations,
    addDateLabelProp,
    map(a => ({...a, rate: a.pulseRate.rate})) //todo
);

const minHealthyValue = 60;
const maxHealthyValue = 100;

const xTickFormatter = pipe(split(' '), nth(2));

class PulseRateExaminationRow extends Component {
    render() {
        const {data} = this.props;
        if(isEmpty(data)) //todo
            return null;

        return (
            <BaseExaminationRow title="Pusle Rate" data={transformData(data)} dataKey={'rate'} minHealthyValue={minHealthyValue} maxHealthyValue={maxHealthyValue}
            xDataKey="examinationDateShort" xTickFormatter={xTickFormatter} yUnit="bpm" CustomTooltip={PulseRateTooltip}/>
        ); 
    }
}

export default PulseRateExaminationRow;