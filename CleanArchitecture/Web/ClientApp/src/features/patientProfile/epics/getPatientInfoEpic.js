import { mergeMap,debounceTime } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';

import { getPatientInfo } from "../actions";
import { apiRequest } from "../../common/actions";
import { userSelector } from "../../common/selectors";

const getPatientInfo$ = (action$, state$) => action$.pipe(
    ofType(getPatientInfo.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(getPatientInfo.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'GET',
                    url: `patient/${payload.patientId}/info`,
                    ...getPatientInfo.actions,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

export default combineEpics(getPatientInfo$);