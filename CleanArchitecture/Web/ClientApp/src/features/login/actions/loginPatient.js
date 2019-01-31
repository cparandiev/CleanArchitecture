import { createAction } from 'redux-actions';
import { mapObjIndexed } from "ramda";

import createAsynActionTypes from "../../../utils/createAsynActionTypes";

const types = createAsynActionTypes('LOGIN');

const actions = mapObjIndexed((actionType) => createAction(actionType), types);

export default {
    types,
    actions
}