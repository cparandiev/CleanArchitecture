import { prop } from "ramda";

import examinationsReducer from "./examinationsReducer";

export default (state, action)=> ({
    examinations: examinationsReducer(prop('examinations', state), action)
});