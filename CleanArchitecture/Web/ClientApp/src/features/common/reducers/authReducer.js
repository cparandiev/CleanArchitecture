import { toLower, map } from "ramda";

import login from "../../login/actions";

const initialState = {
    authenticated: false,
    username: 'anonymous',
    roles: ['anonymous']
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