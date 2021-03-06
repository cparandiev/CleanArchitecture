import { createStore, applyMiddleware } from 'redux';
import { createEpicMiddleware } from 'redux-observable';
import {composeWithDevTools} from "redux-devtools-extension"
import { combineReducers } from 'redux';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { createBrowserHistory } from 'history';

import reducers from "../reducers";
import rootEpic from "../epics";

export const history = createBrowserHistory();

const configureStore = (apiService) => {
    const epicMiddleware = createEpicMiddleware();
    
    const middlewares = applyMiddleware(
        routerMiddleware(history),
        epicMiddleware
    );
    
    const store = createStore(
        combineReducers({router: connectRouter(history), ...reducers}),
        composeWithDevTools(middlewares)
    );

    
    epicMiddleware.run(rootEpic(apiService));
    return store;
};

export default configureStore;