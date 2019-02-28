import { mergeMap, debounceTime } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { ofType, combineEpics } from 'redux-observable';
import { flatten, map as Rmap, values, apply } from "ramda";
import { push } from 'connected-react-router';

import { accomplishMedicalExamination } from "../actions";
import { userSelector } from "../../common/selectors";
import { apiRequest, notification } from "../../common/actions";
import routesConfig from "../../../routes/routesConfig";

const accomplishMedicalExamination$ = (action$, state$) => action$.pipe(
    ofType(accomplishMedicalExamination.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(accomplishMedicalExamination.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'POST',
                    url: `medicalexamination/${payload.requestId}/accomplish`,
                    ...accomplishMedicalExamination.actions,
                    data: {notes: payload.notes},
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);


const accomplishMedicalExaminationFulfilled$ = (action$, state$) => action$.pipe(
    ofType(accomplishMedicalExamination.types.FULFILLED),
    mergeMap(() =>
        merge( 
            of(notification.actions.NOTIFY_SUCCESS('Successfully accomplished')),
        )
    )
);

const accomplishMedicalExaminationRejected$ = action$ => action$.pipe(
    ofType(accomplishMedicalExamination.types.REJECTED),
    mergeMap(({payload}) =>
        merge(
            of(push(routesConfig.home.path)),
            apply(merge, Rmap(a => of(notification.actions.NOTIFY_ERROR(a)), flatten(values(payload.response.data))))
        )
    )
);

export default combineEpics(accomplishMedicalExamination$, accomplishMedicalExaminationFulfilled$, accomplishMedicalExaminationRejected$);