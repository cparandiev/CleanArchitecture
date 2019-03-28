import Home from '../features/home';
import About from '../features/about';
import Contacts from '../features/contacts';
import Login from '../features/login';
import Unauthorized from '../features/unauthorized';
import doctorWorkingTime from '../features/doctorWorkingTime';
import addWorkingTime from '../features/addWorkingTime';
import patientMedicalExaminations from '../features/patientMedicalExaminations';
import requestMedicalExamination from '../features/requestMedicalExamination';
import doctorExaminations from '../features/doctorExaminations';
import accomplishMedicalExamination from '../features/accomplishMedicalExamination';
import logout from '../features/logout';
import patientBodyExaminations from '../features/patientBodyExaminations';
import doctorPatients from '../features/doctorPatients';
import patientProfile from '../features/patientProfile';
import notFound from '../features/notFound';
import addBodyExamination from '../features/addBodyExamination';

export default {
    //#region Common routes
    home: {
        path: '/',
        requiredRoles: [],
        component: Home,
        exact: true,
    },
    about: {
        path: '/about',
        requiredRoles: [],
        component: About,
        exact: true,
    },
    contacts: {
        path: '/contacts',
        requiredRoles: [],
        component: Contacts,
        exact: true,
    },
    //#endregion
    //#region Anonymous user's routes
    signIn: {
        path: '/login',
        component: Login,
        exact: true,
        authenticated: false,
    },
    signUp: {
        path: '/register',
        component: Home,
        exact: true,
        authenticated: false,
    },
    //#endregion
    //#region Common authorized routes 
    unauthorized: {
        path: '/unauthorized',
        component: Unauthorized,
        authenticated: true,
        exact: true,
    },
    logout: {
        path: '/logout',
        requiredRoles: [],
        component: logout,
        exact: true,
        authenticated: true,
    },
    //#endregion
    //#region Patient's routes
    patientProfile: {
        path: '/patient/:patientId(\\d+)/profile',
        requiredRoles: [['patient'], ['doctor']],
        component: patientProfile,
        exact: true,
        authenticated: true,
    },
    patientMedicalExaminations: {
        path: '/patient/:patientId(\\d+)/medical-examination',
        requiredRoles: [['patient'], ['doctor']],
        component: patientMedicalExaminations,
        exact: true,
        authenticated: true,
    },
    requestMedicalExamination: {
        path: '/patient/request-medical-examination',
        requiredRoles: [['patient']],
        component: requestMedicalExamination,
        exact: true,
        authenticated: true,
    },
    patientBodyExaminations: {
        path: '/patient/:patientId(\\d+)/body-examinations',
        requiredRoles: [['patient'], ['doctor']],
        component: patientBodyExaminations,
        exact: true,
        authenticated: true,
    },
    addBodyExamination: {
        path: '/patient/add-body-examination',
        requiredRoles: [['patient']],
        component: addBodyExamination,
        exact: true,
        authenticated: true,
    },
    //#endregion
    //#region Doctor's routes
    doctorWorkingTime: {
        path: '/doctor/working-time',
        requiredRoles: [['doctor']],
        component: doctorWorkingTime,
        exact: true,
        authenticated: true,
    },
    addWorkingTime: {
        path: '/doctor/add-working-time',
        requiredRoles: [['doctor']],
        component: addWorkingTime,
        exact: true,
        authenticated: true,
    },
    
    doctorExaminations: {
        path: '/doctor/examinations',
        requiredRoles: [['doctor']],
        component: doctorExaminations,
        exact: true,
        authenticated: true,
    },
    accomplishMedicalExamination: {
        path: '/medical-examination/:id(\\d+)/accomplish',
        requiredRoles: [['doctor']],
        component: accomplishMedicalExamination,
        exact: true,
        authenticated: true,
    },
    doctorPatients: {
        path: '/doctor/:doctorId(\\d+)/patients',
        requiredRoles: [['doctor']],
        component: doctorPatients,
        exact: true,
        authenticated: true,
    },
    //#endregion
    //#region Latest routes
    notFound: {
        path: "*",
        component: notFound
    },
    //#endregion
}