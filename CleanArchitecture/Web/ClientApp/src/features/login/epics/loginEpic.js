import { debounceTime, tap, mergeMap} from 'rxjs/operators';
import { of, merge} from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';
import { pick, flatten, map as Rmap, values, apply } from "ramda";
import { push } from 'connected-react-router';

import login from "../actions";
import {apiRequest, notification} from '../../common/actions';
import routesConfig from "../../../routes/routesConfig";

const login$ = action$ => action$.pipe(
    ofType(login.types.DEFAULT),
    debounceTime(500),
    mergeMap(({payload, meta}) =>
        merge( 
            of(login.actions.PENDING()),
            of(apiRequest.actions.DEFAULT(
                {method: 'POST', url: `Account/login/${payload.role}`, ...login.actions, data: pick(['username', 'password'], payload)},
                meta
            ))
        )
    )
);

const loginFulfilled$ = action$ => action$.pipe(
    ofType(login.types.FULFILLED),
    tap(({meta}) => {
        meta.setSubmitting(false);
    }),
    mergeMap(action =>
        merge( 
            of(notification.actions.NOTIFY_SUCCESS('Successful login')),
            of(push(routesConfig.home.route))
        )
    )
);

const loginRejected$ = action$ => action$.pipe(
    ofType(login.types.REJECTED),
    tap(({meta}) => {
        meta.setSubmitting(false);
    }),
    mergeMap(({payload}) => 
        apply(merge, Rmap(a => of(notification.actions.NOTIFY_ERROR(a)), flatten(values(payload.response.data))))
    )
);

export default combineEpics(login$, loginFulfilled$, loginRejected$);