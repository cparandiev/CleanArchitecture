import { createSelector } from 'reselect';
import { path, __, assoc, pipe, includes, prop, filter } from "ramda";

const isBodyTemperatureExamination = pipe(
    prop('bodyExaminationResultTypes'),
    includes('BodyTemperature')
);

export default createSelector(
    pipe(
        path(['selectedPatientBodyExaminations']),
        filter(isBodyTemperatureExamination)
    ),
    assoc('selectedPatientBodyTemperatureExaminations', __, Object.create(null))
)