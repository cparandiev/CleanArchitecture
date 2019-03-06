import { mergeMap, debounceTime, tap} from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';
import { flatten, map as Rmap, values, apply } from "ramda";

import { apiRequest, notification } from "../../common/actions";
import { userSelector} from "../../common/selectors";
import { reviewMedicalExamination, getDoctorExaminations } from "../actions";

const reviewMedicalExaminationEpic$ = (action$, state$) => action$.pipe(
    ofType(reviewMedicalExamination.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(reviewMedicalExamination.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'POST',
                    url: `medicalexamination/${payload.id}/review`,
                    data: {isApproved: payload.isApproved},
                    ...reviewMedicalExamination.actions,
                    token: userSelector(state$.value).user.jwt
                },
                {...meta, isApproved: payload.isApproved}
            ))
        )
    )
);

const reviewMedicalExaminationFulfilledEpic$ = (action$, state$) => action$.pipe(
    ofType(reviewMedicalExamination.types.FULFILLED),
    mergeMap(({meta}) =>
        merge( 
            of(notification.actions.NOTIFY_SUCCESS(`Successfully ${meta.isApproved ? "approved" : "disapproved"}`)),
            of(getDoctorExaminations.actions.DEFAULT({doctorId: userSelector(state$.value).user.doctorId}))
        )
    )
);

const reviewMedicalExaminationRejectedeEpic$ = action$ => action$.pipe(
    ofType(reviewMedicalExamination.types.REJECTED),
    mergeMap(({payload}) => 
        apply(merge, Rmap(a => of(notification.actions.NOTIFY_ERROR(a)), flatten(values(payload.response.data))))
    )
);

export default combineEpics(reviewMedicalExaminationEpic$, reviewMedicalExaminationFulfilledEpic$, reviewMedicalExaminationRejectedeEpic$);