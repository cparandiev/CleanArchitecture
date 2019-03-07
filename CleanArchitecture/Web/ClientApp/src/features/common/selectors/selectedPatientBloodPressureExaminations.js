import { createSelector } from 'reselect';
import { path, __, assoc, pipe, includes, prop, filter } from "ramda";

const isBloodPressureExamination = pipe(
    prop('bodyExaminationResultTypes'),
    includes('BloodPressure')
);

export default createSelector(
    pipe(
        path(['selectedPatientBodyExaminations']),
        filter(isBloodPressureExamination)
    ),
    assoc('selectedPatientBloodPressureExaminations', __, Object.create(null))
)