import { mergeMap,debounceTime, mapTo } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';

import { getPatientMedicalExaminations } from "../actions";
import { apiRequest, notification } from "../../common/actions";
import { userSelector } from "../../common/selectors";

const getPatientMedicalExaminations$ = (action$, state$) => action$.pipe(
    ofType(getPatientMedicalExaminations.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(getPatientMedicalExaminations.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'GET',
                    url: `patient/${payload.patientId}/medicalexaminations`,
                    ...getPatientMedicalExaminations.actions,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

export default combineEpics(getPatientMedicalExaminations$);