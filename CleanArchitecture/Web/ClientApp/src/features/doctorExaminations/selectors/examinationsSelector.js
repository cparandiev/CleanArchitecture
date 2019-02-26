import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['doctorExaminations', 'examinations']),
    assoc('examinations', __, Object.create(null))
)