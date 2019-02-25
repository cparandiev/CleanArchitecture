import { mergeMap,debounceTime, mapTo } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';

import { requestMedicalExamination } from "../actions";
import { apiRequest} from "../../common/actions";
import { userSelector } from "../../common/selectors";

const requestMedicalExamination$ = (action$, state$) => action$.pipe(
    ofType(requestMedicalExamination.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(requestMedicalExamination.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'POST',
                    url: `patient/${payload.patientId}/RequestMedicalExamination`,
                    ...requestMedicalExamination.actions,
                    data: payload,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

export default combineEpics(requestMedicalExamination$);