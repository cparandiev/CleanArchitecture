import {getDoctorWorkingTimes} from "../actions";

const initialState = [];

const selectedDoctorWokingTimesReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case getDoctorWorkingTimes.types.FULFILLED:

            return payload.data;
        default: 
            return state;
    }
}

export default selectedDoctorWokingTimesReducer;