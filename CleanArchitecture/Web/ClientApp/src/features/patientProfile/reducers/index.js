import { prop } from "ramda";

import profileReducer from "./profileReducer";

export default (state, action)=> ({
    profile: profileReducer(prop('profile', state), action)
});