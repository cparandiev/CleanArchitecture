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

export default {
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
    unauthorized: {
        path: '/unauthorized',
        component: Unauthorized,
        authenticated: true,
        exact: true,
    },
    myProfile: {
        path: '/profile',
        requiredRoles: [],
        component: Home,
        exact: true,
        authenticated: true,
    },
    logout: {
        path: '/logout',
        requiredRoles: [],
        component: Home,
        exact: true,
        authenticated: true,
    },
    home: {
        path: '/home',
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
        path: '/counter',
        requiredRoles: [],
        component: Contacts,
        exact: true,
    },
    doctorWorkingTime: {
        path: '/doctor/working-time',
        requiredRoles: ['doctor'],
        component: doctorWorkingTime,
        exact: true,
        authenticated: true,
    },
    addWorkingTime: {
        path: '/doctor/add-working-time',
        requiredRoles: ['doctor'],
        component: addWorkingTime,
        exact: true,
        authenticated: true,
    },
    patientMedicalExaminations: {
        path: '/patient/medical-examination',
        requiredRoles: ['patient'],
        component: patientMedicalExaminations,
        exact: true,
        authenticated: true,
    },
    requestMedicalExamination: {
        path: '/patient/request-medical-examination',
        requiredRoles: ['patient'],
        component: requestMedicalExamination,
        exact: true,
        authenticated: true,
    },
    doctorExaminations: {
        path: '/doctor/examinations',
        requiredRoles: ['doctor'],
        component: doctorExaminations,
        exact: true,
        authenticated: true,
    },
    accomplishMedicalExamination: {
        path: '/medicalexamination/:id(\\d+)/accomplish',
        requiredRoles: ['doctor'],
        component: accomplishMedicalExamination,
        exact: true,
        authenticated: true,
    }
    // notFound: {
    //     path: '*',
    //     requiredRoles: [],
    //     component: NotFound
    // },
}