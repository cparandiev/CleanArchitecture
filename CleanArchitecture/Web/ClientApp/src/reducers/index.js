import {authReducer, selectedDoctorWokingTimesReducer, selectedPatientBodyExaminationsReducer} from '../features/common/reducers';
import notificationReducer from '../features/notifications/reducers';
import patientMedicalExaminationsReducer from '../features/patientMedicalExaminations/reducers';
import requestMedicalExaminationReducer from '../features/requestMedicalExamination/reducers';
import doctorExaminationsReducer from '../features/doctorExaminations/reducers';
import doctorPatientsReducer from '../features/doctorPatients/reducers';

export default ({
    user: authReducer,
    selectedDoctorWokingTimes: selectedDoctorWokingTimesReducer,
    selectedPatientBodyExaminations: selectedPatientBodyExaminationsReducer,
    notification: notificationReducer,
    patientMedicalExaminations: patientMedicalExaminationsReducer,
    requestMedicalExamination: requestMedicalExaminationReducer,
    doctorExaminations: doctorExaminationsReducer,
    doctorPatients: doctorPatientsReducer,
})