import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['selectedDoctorWokingTimes']),
    assoc('selectedDoctorWokingTimes', __, Object.create(null))
)