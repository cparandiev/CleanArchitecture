import loginPatient from "../../login/actions";

const initialState = {
    
}

const authReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case loginPatient.types.FULFILLED:

            return {status: 'ok'};
        default: 
            return state;
    }
}

export default authReducer;