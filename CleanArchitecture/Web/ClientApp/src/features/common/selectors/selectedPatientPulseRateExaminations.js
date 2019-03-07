import { createSelector } from 'reselect';
import { path, __, assoc, pipe, includes, prop, filter } from "ramda";

const isPulseRateExamination = pipe(
    prop('bodyExaminationResultTypes'),
    includes('PulseRate')
);

export default createSelector(
    pipe(
        path(['selectedPatientBodyExaminations']),
        filter(isPulseRateExamination)
    ),
    assoc('selectedPatientPulseRateExaminations', __, Object.create(null))
)