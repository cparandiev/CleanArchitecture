import { prop } from "ramda";

import requestsReducer from "./requestsReducer";

export default (state, action)=> ({
    requests: requestsReducer(prop('requests', state), action)
});