import { createAction } from 'redux-actions';
import { mapObjIndexed } from "ramda";

const types = {DEFAULT: 'API_REQUEST'};

const actions = mapObjIndexed((actionType) => createAction(actionType), types);

export default {
    types,
    actions
}