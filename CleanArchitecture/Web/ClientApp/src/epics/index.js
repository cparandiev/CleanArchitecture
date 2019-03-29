import { combineEpics } from 'redux-observable';

import loginEpics from "../features/login/epics";
import {apiRequestEpic, getDoctorWorkingTimesEpic, getPatienBodyExaminationsEpic} from "../features/common/epics";
import { deleteDoctorWorkingTime } from "../features/doctorWorkingTime/epics";
import { addWorkingTimeEpic } from "../features/addWorkingTime/epics";
import { getPatientMedicalExaminationsEpic } from "../features/patientMedicalExaminations/epics";
import { getAllClinicsWithDoctorsEpic, requestMedicalExaminationEpic } from "../features/requestMedicalExamination/epics";
import { getDoctorExaminationsEpic, reviewMedicalExaminationeEpic } from "../features/doctorExaminations/epics";
import { accomplishMedicalExaminationEpic } from "../features/accomplishMedicalExamination/epics";
import { getDoctorPatientsEpic } from "../features/doctorPatients/epics";
import { getPatientInfoEpic } from "../features/patientProfile/epics";
import { addBloodPressureExaminationEpic, addPulseRateExaminationEpic, addBloodOxygenExaminationEpic, addBodyTemperatureExaminationEpic } from "../features/addBodyExamination/epics";

export default (apiService) => combineEpics(
    apiRequestEpic(apiService),
    getDoctorWorkingTimesEpic,
    deleteDoctorWorkingTime,
    addWorkingTimeEpic,
    getPatientMedicalExaminationsEpic,
    getAllClinicsWithDoctorsEpic,
    requestMedicalExaminationEpic,
    getDoctorExaminationsEpic,
    reviewMedicalExaminationeEpic,
    accomplishMedicalExaminationEpic,
    getPatienBodyExaminationsEpic,
    getDoctorPatientsEpic,
    getPatientInfoEpic,
    addBloodPressureExaminationEpic,
    addPulseRateExaminationEpic,
    addBloodOxygenExaminationEpic,
    addBodyTemperatureExaminationEpic,
    ...loginEpics
);