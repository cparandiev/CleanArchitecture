import { mergeMap,debounceTime, mapTo } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';
import { push } from 'connected-react-router';
import { pick, flatten, map as Rmap, values, apply } from "ramda";

import { requestMedicalExamination } from "../actions";
import { apiRequest, notification} from "../../common/actions";
import { userSelector } from "../../common/selectors";
import routesConfig from "../../../routes/routesConfig";

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

const requestMedicalExaminationFulfilled$ = (action$, state$) => action$.pipe(
    ofType(requestMedicalExamination.types.FULFILLED),
    mergeMap(() =>
        merge( 
            of(notification.actions.NOTIFY_SUCCESS('Successfully requested')),
            of(push(routesConfig.home.route))
        )
    )
);

const requestMedicalExaminationRejected$ = action$ => action$.pipe(
    ofType(requestMedicalExamination.types.REJECTED),
    mergeMap(({payload}) => 
        apply(merge, Rmap(a => of(notification.actions.NOTIFY_ERROR(a)), flatten(values(payload.response.data))))
    )
);

export default combineEpics(requestMedicalExamination$, requestMedicalExaminationFulfilled$, requestMedicalExaminationRejected$);