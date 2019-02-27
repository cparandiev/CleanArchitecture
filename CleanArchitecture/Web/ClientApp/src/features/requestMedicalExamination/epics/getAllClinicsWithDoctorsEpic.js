import { mergeMap,debounceTime } from 'rxjs/operators';
import { of, merge } from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';

import { getAllClinicsWithDoctors } from "../actions";
import { apiRequest} from "../../common/actions";
import { userSelector } from "../../common/selectors";

const getAllClinicsWithDoctors$ = (action$, state$) => action$.pipe(
    ofType(getAllClinicsWithDoctors.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(getAllClinicsWithDoctors.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {
                    method: 'GET',
                    url: `clinic`,
                    ...getAllClinicsWithDoctors.actions,
                    token: userSelector(state$.value).user.jwt
                },
                meta
            ))
        )
    )
);

export default combineEpics(getAllClinicsWithDoctors$);