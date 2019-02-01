import { combineEpics } from 'redux-observable';

import loginEpics from "../features/login/epics";

export default combineEpics(
    ...loginEpics
);