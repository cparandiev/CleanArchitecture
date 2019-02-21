import {getPatientMedicalExaminations} from "../actions";
import mapDatesStringsToDates from "../../../utils/mapDatesStringsToDates";

const initialState = [];
const transformResponse = mapDatesStringsToDates([['requestDate']]);

const requestsReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case getPatientMedicalExaminations.types.FULFILLED:
        
            return transformResponse(payload.data);
        default: 
            return state;
    }
}

export default requestsReducer;