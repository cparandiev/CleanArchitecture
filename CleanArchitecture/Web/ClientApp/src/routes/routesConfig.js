import { Home } from '../components/Home';
import { Counter } from '../components/Counter';

export default {
    signIn: {
        route: '/login',
        roles: [],
        component: Home,
        exact: true,
    },
    signUp: {
        route: '/register',
        roles: [],
        component: Home,
        exact: true,
    },
    myProfile: {
        route: '/profile',
        roles: [],
        component: Home,
        exact: true,
    },
    logout: {
        route: '/logout',
        roles: [],
        component: Home,
        exact: true,
    },
    home: {
        route: '/',
        roles: [],
        component: Home,
        exact: true,
    },
    about: {
        route: '/two',
        roles: [],
        component: Counter
    },
    contacts: {
        route: '/counter',
        roles: [],
        component: Counter
    },
    two: {
        route: '/two2',
        roles: [],
        component: Counter
    },
    counter: {
        route: '/counter2',
        roles: [],
        component: Counter
    },
    fetchdata: {
        route: '/fetchdata',
        roles: [],
        component: Counter
    },
    // notFound: {
    //     route: '*',
    //     roles: [],
    //     component: NotFound
    // },
}