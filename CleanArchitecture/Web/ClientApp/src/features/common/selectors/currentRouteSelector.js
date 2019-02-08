import { createSelector } from 'reselect';
import { path, __, assoc } from "ramda";

export default createSelector(
    path(['router', 'location', 'pathname']),
    assoc('currentRoute', __, Object.create(null))
)