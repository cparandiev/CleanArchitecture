import Home from '../features/home';
import About from '../features/about';
import Contacts from '../features/contacts';
import Login from '../features/login';
import Unauthorized from '../features/unauthorized';
import doctorWorkingTime from '../features/doctorWorkingTime';
import { Counter } from '../components/Counter';

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
        component: doctorWorkingTime,
        // component: Home,
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
    counter: {
        path: '/counter2',
        requiredRoles: [],
        component: Counter
    },
    fetchdata: {
        path: '/fetchdata',
        requiredRoles: [],
        component: Counter
    },
    // notFound: {
    //     path: '*',
    //     requiredRoles: [],
    //     component: NotFound
    // },
}