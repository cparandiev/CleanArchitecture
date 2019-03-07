import {getPatienBodyExaminations} from "../actions";
import mapDatesStringsToDates from "../../../utils/mapDatesStringsToDates";

const initialState = [];
const transformResponse = mapDatesStringsToDates([['examinationDate']]);

const selectedPatientBodyExaminationsReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case getPatienBodyExaminations.types.FULFILLED:
        
            return transformResponse(payload.data);
        default: 
            return state;
    }
}

export default selectedPatientBodyExaminationsReducer;