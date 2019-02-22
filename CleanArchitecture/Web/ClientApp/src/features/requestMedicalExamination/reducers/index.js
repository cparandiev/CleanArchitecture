import { prop } from "ramda";

import clinicsReducer from "./clinicsReducer";

export default (state, action)=> ({
    clinics: clinicsReducer(prop('clinics', state), action)
});