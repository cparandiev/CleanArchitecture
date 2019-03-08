import { toLower, map } from "ramda";

import login from "../../login/actions";
import {logout} from "../../logout/actions";

// const initialState = {
//     authenticated: false,
//     username: 'anonymous',
//     roles: ['anonymous']
// }

// const fakePatient = {
//     authenticated: true,
//     patientId: 3,
//     userId: 3,
//     jwt: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIzIiwicGF0aWVudElkIjoiMyIsImV4cCI6MTU4MzU5NTQ5OCwiaXNzIjoieW91cmRvbWFpbi5jb20iLCJhdWQiOiJ5b3VyZG9tYWluLmNvbSJ9.tjHqeH-acn2xJMDqBN4Zw-iIlDgt1bNJDletGINRPeY',
//     username: 'Hank',
//     firstname: 'Tony',
//     lastname: 'Hill',
//     roles: [
//         'patient'
//     ]
// }

const fakeDoctor = {
    authenticated: true,
    patientId: 2,
    doctorId: 2,
    userId: 2,
    jwt: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiZG9jdG9ySWQiOiIyIiwiZXhwIjoxNTgzNTk2MTc1LCJpc3MiOiJ5b3VyZG9tYWluLmNvbSIsImF1ZCI6InlvdXJkb21haW4uY29tIn0.OHaSk4KBz1h8e-xiQMJr36hSLiJYeyOBxPc22lF6PGg',
    username: 'Tony',
    firstname: 'Tony',
    lastname: 'Watts',
    roles: [
        'doctor'
    ]
}

const authReducer = (state = fakeDoctor, {type, payload})=> {
    switch(type){
        case login.types.FULFILLED:

            return {authenticated: true, ...payload.data, roles: map(toLower, payload.data.roles)};
        case  logout.types.DEFAULT:
            return {authenticated: false, roles: ['anonymous']}
        default: 
            return state;
    }
}

export default authReducer;