import { mergeMap, tap } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { ofType, combineEpics } from 'redux-observable';

import { addBodyTemperatureExaminationActions } from "../actions";
import { userSelector } from "../../common/selectors";
import { apiRequest, notification } from "../../common/actions";

const addBodyTemperatureExamination$ = (action$, state$) => action$.pipe(
    ofType(addBodyTemperatureExaminationActions.types.DEFAULT),
    tap(console.log),
    mergeMap(({payload}) =>
        merge( 
            of(addBodyTemperatureExaminationActions.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'POST',
                    url: `bodyexamination/temperature`,
                    data: payload,
                    token: userSelector(state$.value).user.jwt,
                    ...addBodyTemperatureExaminationActions.actions,
                }
            ))
        )
    )
);

export default combineEpics(addBodyTemperatureExamination$);