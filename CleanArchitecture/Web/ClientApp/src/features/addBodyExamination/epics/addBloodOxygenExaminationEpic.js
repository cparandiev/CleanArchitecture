import { mergeMap, tap } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { ofType, combineEpics } from 'redux-observable';

import { addBloodOxygenExaminationActions } from "../actions";
import { userSelector } from "../../common/selectors";
import { apiRequest, notification } from "../../common/actions";

const addBloodOxygenExamination$ = (action$, state$) => action$.pipe(
    ofType(addBloodOxygenExaminationActions.types.DEFAULT),
    tap(console.log),
    mergeMap(({payload}) =>
        merge( 
            of(addBloodOxygenExaminationActions.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'POST',
                    url: `bodyexamination/bloodoxygen`,
                    data: payload,
                    token: userSelector(state$.value).user.jwt,
                    ...addBloodOxygenExaminationActions.actions,
                }
            ))
        )
    )
);

export default combineEpics(addBloodOxygenExamination$);