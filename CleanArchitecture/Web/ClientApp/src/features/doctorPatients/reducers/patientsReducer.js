import { getDoctorPatients } from "../actions";
import mapDatesStringsToDates from "../../../utils/mapDatesStringsToDates";

const initialState = [];
const transformResponse = mapDatesStringsToDates([['user', 'birthdate']]);

const patientsReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case getDoctorPatients.types.FULFILLED:
        
            return transformResponse(payload.data);
        default: 
            return state;
    }
}

export default patientsReducer;