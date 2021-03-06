import { createAction } from 'redux-actions';
import { mapObjIndexed, nthArg } from "ramda";

const types = {DEFAULT: 'API_REQUEST'};

const actions = mapObjIndexed((actionType) => createAction(actionType, null, nthArg(1)), types);

export default {
    types,
    actions
}