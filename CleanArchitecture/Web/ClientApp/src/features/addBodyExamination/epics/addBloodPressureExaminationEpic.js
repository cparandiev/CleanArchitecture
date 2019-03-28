import { mergeMap, tap } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { ofType, combineEpics } from 'redux-observable';

import { addBloodPressureExaminationActions } from "../actions";
import { userSelector } from "../../common/selectors";
import { apiRequest, notification } from "../../common/actions";

const addBloodPressureExamination$ = (action$, state$) => action$.pipe(
    ofType(addBloodPressureExaminationActions.types.DEFAULT),
    tap(console.log),
    mergeMap(({payload}) =>
        merge( 
            of(addBloodPressureExaminationActions.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'POST',
                    url: `bodyexamination/bloodpressure`,
                    data: payload,
                    token: userSelector(state$.value).user.jwt,
                    ...addBloodPressureExaminationActions.actions,
                }
            ))
        )
    )
);

export default combineEpics(addBloodPressureExamination$);