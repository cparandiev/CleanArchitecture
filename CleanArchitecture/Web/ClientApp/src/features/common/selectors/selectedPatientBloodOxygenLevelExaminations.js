import { createSelector } from 'reselect';
import { path, __, assoc, pipe, includes, prop, filter } from "ramda";

const isBloodOxygenLevelExamination = pipe(
    prop('bodyExaminationResultTypes'),
    includes('BloodOxygenLevel')
);

export default createSelector(
    pipe(
        path(['selectedPatientBodyExaminations']),
        filter(isBloodOxygenLevelExamination)
    ),
    assoc('selectedPatientBloodOxygenLevelExaminations', __, Object.create(null))
)