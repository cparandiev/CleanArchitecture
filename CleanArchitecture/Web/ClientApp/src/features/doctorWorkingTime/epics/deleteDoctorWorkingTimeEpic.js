import { mergeMap,debounceTime, mapTo } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';
import { flatten, map as Rmap, values, apply } from "ramda";

import { deleteDoctorWorkingTime } from "../actions";
import { apiRequest, notification, getDoctorWorkingTimes } from "../../common/actions";
import { userSelector } from "../../common/selectors";

const deleteDoctorWorkingTime$ = (action$, state$) => action$.pipe(
    ofType(deleteDoctorWorkingTime.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(deleteDoctorWorkingTime.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'DELETE',
                    url: `doctor/workingtime/${payload.workingTimeId}/`,
                    ...deleteDoctorWorkingTime.actions,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

const deleteDoctorWorkingTimeFulfilled$ = (action$, state$) => action$.pipe(
    ofType(deleteDoctorWorkingTime.types.FULFILLED),
    mergeMap(() =>
        merge( 
            of(notification.actions.NOTIFY_SUCCESS('Successfully deleted')),
            of(getDoctorWorkingTimes.actions.DEFAULT({doctorId: userSelector(state$.value).user.doctorId})),
        )
    )
);

const deleteDoctorWorkingTimeRejected$ = action$ => action$.pipe(
    ofType(deleteDoctorWorkingTime.types.REJECTED),
    mapTo(notification.actions.NOTIFY_ERROR('Failed to delete'))
);

export default combineEpics(deleteDoctorWorkingTime$, deleteDoctorWorkingTimeFulfilled$, deleteDoctorWorkingTimeRejected$);