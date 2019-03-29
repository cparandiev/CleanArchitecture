import { mergeMap, tap } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { ofType, combineEpics } from 'redux-observable';

import { addPulseRateExaminationActions } from "../actions";
import { userSelector } from "../../common/selectors";
import { apiRequest, notification } from "../../common/actions";

const addPulseRateExamination$ = (action$, state$) => action$.pipe(
    ofType(addPulseRateExaminationActions.types.DEFAULT),
    tap(console.log),
    mergeMap(({payload}) =>
        merge( 
            of(addPulseRateExaminationActions.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'POST',
                    url: `bodyexamination/pulserate`,
                    data: payload,
                    token: userSelector(state$.value).user.jwt,
                    ...addPulseRateExaminationActions.actions,
                }
            ))
        )
    )
);

export default combineEpics(addPulseRateExamination$);