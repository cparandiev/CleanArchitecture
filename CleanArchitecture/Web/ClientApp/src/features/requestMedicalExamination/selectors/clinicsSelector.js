import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['requestMedicalExamination', 'clinics']),
    assoc('clinics', __, Object.create(null))
)