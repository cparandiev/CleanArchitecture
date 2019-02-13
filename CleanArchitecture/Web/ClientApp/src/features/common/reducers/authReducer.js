import login from "../../login/actions";

const initialState = {
    authenticated: false,
    username: 'anonymous',
    roles: ['anonymous']
}

const authReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case login.types.FULFILLED:
            return {authenticated: true, username: 'somename', roles: ['anonymous']};
        default: 
            return state;
    }
}

export default authReducer;