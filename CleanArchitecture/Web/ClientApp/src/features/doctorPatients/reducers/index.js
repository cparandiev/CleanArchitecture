import { prop } from "ramda";

import patientsReducer from "./patientsReducer";

export default (state, action)=> ({
    patients: patientsReducer(prop('patients', state), action)
});