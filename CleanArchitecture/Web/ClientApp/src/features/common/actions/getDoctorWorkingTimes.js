import { createAction } from 'redux-actions';
import { mapObjIndexed, nthArg } from "ramda";

import createAsynActionTypes from "../../../utils/createAsynActionTypes";

const types = createAsynActionTypes('GET_DOCTOR_WORKING_TIMES');

const actions = mapObjIndexed((actionType) => createAction(actionType, null, nthArg(1)), types);

export default {
    types,
    actions
}