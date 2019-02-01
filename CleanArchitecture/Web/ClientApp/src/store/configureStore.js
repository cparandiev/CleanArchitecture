import { createStore, applyMiddleware } from 'redux';
import { createEpicMiddleware } from 'redux-observable';
import {composeWithDevTools} from "redux-devtools-extension";

import rootReducer from "../reducers";
import rootEpic from "../epics";

const configureStore = () => {
    const epicMiddleware = createEpicMiddleware();
    
    const middlewares = applyMiddleware(
        epicMiddleware
    );
    
    const store = createStore(
        rootReducer,
        composeWithDevTools(middlewares)
    );

    epicMiddleware.run(rootEpic);

    return store;
};

export default configureStore;