import { mergeMap, debounceTime} from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';

import { apiRequest } from "../../common/actions";
import { userSelector} from "../../common/selectors";
import { getDoctorExaminations } from "../actions";

const getDoctorExaminationsEpic$ = (action$, state$) => action$.pipe(
    ofType(getDoctorExaminations.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(getDoctorExaminations.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'GET',
                    url: `doctor/${payload.doctorId}/MedicalExaminations`,
                    ...getDoctorExaminations.actions,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

export default combineEpics(getDoctorExaminationsEpic$);