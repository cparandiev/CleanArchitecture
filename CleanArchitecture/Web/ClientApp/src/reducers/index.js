import commonReducers from '../features/common/reducers';
import notificationReducer from '../features/notifications/reducers';
import patientMedicalExaminationsReducer from '../features/patientMedicalExaminations/reducers';
import requestMedicalExaminationReducer from '../features/requestMedicalExamination/reducers';
import doctorExaminationsReducer from '../features/doctorExaminations/reducers';

export default ({
    user: commonReducers.authReducer,
    selectedDoctorWokingTimes: commonReducers.selectedDoctorWokingTimesReducer,
    notification: notificationReducer,
    patientMedicalExaminations: patientMedicalExaminationsReducer,
    requestMedicalExamination: requestMedicalExaminationReducer,
    doctorExaminations: doctorExaminationsReducer,
})