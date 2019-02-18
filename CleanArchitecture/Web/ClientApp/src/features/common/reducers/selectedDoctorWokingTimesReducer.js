import {getDoctorWorkingTimes} from "../actions";
import mapDatesStringsToDates from "../../../utils/mapDatesStringsToDates";

const initialState = [];
const transformResponse = mapDatesStringsToDates([['open'], ['close']]);

const selectedDoctorWokingTimesReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case getDoctorWorkingTimes.types.FULFILLED:
        
            return transformResponse(payload.data);
        default: 
            return state;
    }
}

export default selectedDoctorWokingTimesReducer;