import { mergeMap, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';

import { getPatienBodyExaminations, apiRequest } from "../actions/";
import { userSelector} from "../selectors";

const getPatienBodyExaminations$ = (action$, state$) => action$.pipe(
    ofType(getPatienBodyExaminations.types.DEFAULT),
    distinctUntilChanged((x, y) => x.payload.patientId === y.payload.patientId),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(getPatienBodyExaminations.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'GET',
                    url: `patient/${payload.patientId}/bodyexaminations`,
                    ...getPatienBodyExaminations.actions,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

export default combineEpics(getPatienBodyExaminations$);