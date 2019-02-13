import { createAction } from 'redux-actions';
import { mapObjIndexed, nthArg } from "ramda";

const types = {
    NOTIFY_SUCCESS: 'NOTIFY_SUCCESS',
    NOTIFY_ERROR: 'NOTIFY_ERROR'
};

const actions = mapObjIndexed((actionType) => createAction(actionType, null, nthArg(1)), types);

export default {
    types,
    actions
}