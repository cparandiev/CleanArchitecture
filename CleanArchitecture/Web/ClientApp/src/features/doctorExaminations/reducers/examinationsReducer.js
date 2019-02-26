import { getDoctorExaminations } from "../actions";
import mapDatesStringsToDates from "../../../utils/mapDatesStringsToDates";

const initialState = [];
const transformResponse = mapDatesStringsToDates([['requestDate']]);

const examinationsReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case getDoctorExaminations.types.FULFILLED:
        
            return transformResponse(payload.data);
        default: 
            return state;
    }
}

export default examinationsReducer;