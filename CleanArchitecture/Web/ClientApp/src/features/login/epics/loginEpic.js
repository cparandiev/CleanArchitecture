import { debounceTime, map, mapTo} from 'rxjs/operators';
import { combineEpics, ofType } from 'redux-observable';

import loginPatient from "../actions";
import {apiRequest} from '../../common/actions';

const baseAction$ = action$ => action$.pipe(
    ofType(loginPatient.types.DEFAULT),
    debounceTime(500),
);

const loginPending = action$ => action$.pipe(
    baseAction$,
    mapTo(loginPatient.actions.PENDING()),
);

const loginRequest = action$ => action$.pipe(
    baseAction$,
    map(({payload}) => 
        apiRequest.actions.DEFAULT({method: 'GET', url: 'https://jsonplaceholder.typicode.com/todos/1', ...loginPatient.actions, data: payload})
    )
);

export default combineEpics(loginPending, loginRequest);