import { combineEpics } from 'redux-observable';

import loginEpics from "../features/login/epics";
import {apiRequestEpic, getDoctorWorkingTimesEpic} from "../features/common/epics";
import { deleteDoctorWorkingTime } from "../features/doctorWorkingTime/epics";
import { addWorkingTimeEpic } from "../features/addWorkingTime/epics";

export default (apiService) => combineEpics(
    apiRequestEpic(apiService),
    getDoctorWorkingTimesEpic,
    deleteDoctorWorkingTime,
    addWorkingTimeEpic,
    ...loginEpics
);