import { toLower, map } from "ramda";

import login from "../../login/actions";

const initialState = {
    // authenticated: false,
    // username: 'anonymous',
    // roles: ['anonymous']
    // todo
    authenticated: true,
    doctorId: 1003,
    userId: 1005,
    jwt: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIxMDA1IiwiZG9jdG9ySWQiOiIxMDAzIiwicGF0aWVudElkIjoiMTAwNSIsImV4cCI6MTU4MjEyNTgyMiwiaXNzIjoieW91cmRvbWFpbi5jb20iLCJhdWQiOiJ5b3VyZG9tYWluLmNvbSJ9._GE3Mbg6tFeDnNb3W3cWU0EqDPQssvxrMLgDJfTc9yM',
    username: 'boris',
    firstname: 'Cvetko',
    lastname: 'Parandiev',
    roles: [
        'patient',
        'doctor'
    ]
}

const authReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case login.types.FULFILLED:

            return {authenticated: true, ...payload.data, roles: map(toLower, payload.data.roles)};
        default: 
            return state;
    }
}

export default authReducer;