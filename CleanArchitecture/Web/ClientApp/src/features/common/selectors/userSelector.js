import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['user']),
    assoc('user', __, Object.create(null))
)