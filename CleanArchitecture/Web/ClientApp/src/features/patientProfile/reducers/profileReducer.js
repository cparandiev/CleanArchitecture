import {getPatientInfo} from "../actions";
import mapDatesStringsToDates from "../../../utils/mapDatesStringsToDates";

const initialState = null;
const transformResponse = mapDatesStringsToDates([['user', 'birthdate']]);

const profileReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case getPatientInfo.types.FULFILLED:
        
            return transformResponse([payload.data])[0];
        default: 
            return state;
    }
}

export default profileReducer;