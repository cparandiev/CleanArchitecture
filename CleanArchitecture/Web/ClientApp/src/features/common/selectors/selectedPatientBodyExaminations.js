import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['selectedPatientBodyExaminations']),
    assoc('selectedPatientBodyExaminations', __, Object.create(null))
)