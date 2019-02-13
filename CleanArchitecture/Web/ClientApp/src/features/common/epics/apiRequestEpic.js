import { filter, mapTo, debounceTime, timer, mergeMap, map, catchError } from 'rxjs/operators';
import { from, of } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';

import { apiRequest } from "../actions/";

// const loginRequest = (apiService) => action$ => action$.pipe(
//     ofType('API_REQUEST'),
//     from(apiService.execute)
// );
// new Promise((resolve, reject) => resolve('Hello World!')

const apiRequestEpic = (apiService) => action$ => action$.pipe(
    ofType(apiRequest.types.DEFAULT),
    mergeMap(({payload, meta}) => from(apiService.execute(payload))
        .pipe(
            map((response) => 
                payload.FULFILLED(response, meta)
            ),
            catchError(error => 
                of(payload.REJECTED(error, meta))
            )
        )
    )
);

export default apiRequestEpic;