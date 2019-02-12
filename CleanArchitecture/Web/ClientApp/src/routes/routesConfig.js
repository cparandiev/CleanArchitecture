import { Home } from '../components/Home';
import { Counter } from '../components/Counter';

export default {
    signIn: {
        path: '/login',
        component: Home,
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
        component: Home,
        authenticated: true,
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
        path: '/two',
        requiredRoles: [],
        component: Counter
    },
    contacts: {
        path: '/counter',
        requiredRoles: [],
        component: Counter
    },
    two: {
        path: '/two2',
        requiredRoles: [],
        component: Counter
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