import {getAllClinicsWithDoctors} from "../actions";

const initialState = [];
const requestsReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case getAllClinicsWithDoctors.types.FULFILLED:
        
            return payload.data;
        default: 
            return state;
    }
}

export default requestsReducer;