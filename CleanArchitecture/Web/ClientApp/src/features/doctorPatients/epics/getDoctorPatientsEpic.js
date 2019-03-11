import { mergeMap, debounceTime} from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';

import { apiRequest } from "../../common/actions";
import { userSelector} from "../../common/selectors";
import { getDoctorPatients } from "../actions";

const getDoctorPatientsEpic$ = (action$, state$) => action$.pipe(
    ofType(getDoctorPatients.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(getDoctorPatients.actions.PENDING()),
            of(apiRequest.actions.DEFAULT({
                    method: 'GET',
                    url: `doctor/${payload.doctorId}/patients`,
                    ...getDoctorPatients.actions,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

export default combineEpics(getDoctorPatientsEpic$);