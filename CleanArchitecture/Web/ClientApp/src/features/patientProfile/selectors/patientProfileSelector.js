import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['patientProfile', 'profile']),
    assoc('profile', __, Object.create(null))
)