import { mergeMap, map, catchError } from 'rxjs/operators';
import { from, of } from 'rxjs';
import { ofType } from 'redux-observable';
import { pathEq } from "ramda";

import { apiRequest, notification } from "../actions/";

const isUnauthorized = pathEq(['response', 'status'], 401);

const apiRequestEpic$ = (apiService) => action$ => action$.pipe(
    ofType(apiRequest.types.DEFAULT),
    mergeMap(({payload, meta}) => from(apiService.execute(payload))
        .pipe(
            map((response) => 
                payload.FULFILLED(response, meta)
            ),
            catchError(error => isUnauthorized(error)
                ? of(notification.actions.NOTIFY_ERROR("Unauthorized"))
                : of(payload.REJECTED(error, meta))
            )
        )
    )
);

export default apiRequestEpic$;