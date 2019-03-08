import { mergeMap, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { ofType } from 'redux-observable';

import { getDoctorWorkingTimes, apiRequest } from "../actions/";
import { userSelector} from "../selectors";

const getDoctorWorkingTimesEpic$ = (action$, state$) => action$.pipe(
    ofType(getDoctorWorkingTimes.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(getDoctorWorkingTimes.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'GET',
                    url: `doctor/${payload.doctorId}/workingtimes`,
                    ...getDoctorWorkingTimes.actions,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

export default getDoctorWorkingTimesEpic$;