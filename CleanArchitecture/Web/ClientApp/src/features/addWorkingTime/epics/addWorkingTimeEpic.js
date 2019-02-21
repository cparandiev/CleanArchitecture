import { mergeMap, debounceTime } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { ofType, combineEpics } from 'redux-observable';
import { flatten, map as Rmap, values, apply } from "ramda";

import { addWorkingTime } from "../actions";
import { userSelector } from "../../common/selectors";
import { apiRequest, notification } from "../../common/actions";

const addWorkingTime$ = (action$, state$) => action$.pipe(
    ofType(addWorkingTime.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(addWorkingTime.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'POST',
                    url: `doctor/${meta.doctorId}/WeeklyWorkingTime`,
                    ...addWorkingTime.actions,
                    data: payload,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);


const addWorkingTimeFulfilled$ = (action$, state$) => action$.pipe(
    ofType(addWorkingTime.types.FULFILLED),
    mergeMap(() =>
        merge( 
            of(notification.actions.NOTIFY_SUCCESS('Successfully added')),
        )
    )
);

const addWorkingTimeRejected$ = action$ => action$.pipe(
    ofType(addWorkingTime.types.REJECTED),
    mergeMap(({payload}) => 
        apply(merge, Rmap(a => of(notification.actions.NOTIFY_ERROR(a)), flatten(values(payload.response.data))))
    )
);


export default combineEpics(addWorkingTime$, addWorkingTimeFulfilled$, addWorkingTimeRejected$);