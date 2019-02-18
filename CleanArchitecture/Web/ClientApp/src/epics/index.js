import { combineEpics } from 'redux-observable';

import loginEpics from "../features/login/epics";
import {apiRequestEpic, getDoctorWorkingTimesEpic} from "../features/common/epics";
import { deleteDoctorWorkingTime } from "../features/doctorWorkingTime/epics";

export default (apiService) => combineEpics(
    apiRequestEpic(apiService),
    getDoctorWorkingTimesEpic,
    deleteDoctorWorkingTime,
    ...loginEpics
);