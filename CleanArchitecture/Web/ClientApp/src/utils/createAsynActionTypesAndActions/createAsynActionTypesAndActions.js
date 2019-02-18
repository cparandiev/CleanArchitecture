
import { createAction } from 'redux-actions';
import { mapObjIndexed, nthArg } from "ramda";
import createAsynActionTypes from "../createAsynActionTypes";

export default (type) => {    
    const types = createAsynActionTypes(type);

    const actions = mapObjIndexed((actionType) => createAction(actionType, null, nthArg(1)), types);
   
    return {
        types,
        actions
    }
};