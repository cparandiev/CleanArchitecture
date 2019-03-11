import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['doctorPatients', 'patients']),
    assoc('patients', __, Object.create(null))
)