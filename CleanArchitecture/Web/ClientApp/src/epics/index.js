import { combineEpics } from 'redux-observable';

import loginEpics from "../features/login/epics";
import apiRequestEpic from "../features/common/epics/apiRequestEpic";


export default (apiService) => combineEpics(
    apiRequestEpic(apiService),
    ...loginEpics
);