import loginPatient from "../../login/actions";

const initialState = {
    authenticated: false,
    userName: 'anonymous',
    roles: ['anonymous']
}

const authReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case loginPatient.types.FULFILLED:

            return {authenticated: true, userName: 'somename'};
        default: 
            return state;
    }
}

export default authReducer;