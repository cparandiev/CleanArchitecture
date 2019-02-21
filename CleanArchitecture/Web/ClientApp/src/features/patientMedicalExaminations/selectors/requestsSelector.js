import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['patientMedicalExaminations', 'requests']),
    assoc('requests', __, Object.create(null))
)