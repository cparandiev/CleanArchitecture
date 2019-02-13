import { debounceTime, map, mapTo, tap, concat, mergeMap, merge} from 'rxjs/operators';
import { of} from 'rxjs';
import { combineEpics, ofType } from 'redux-observable';
import { pick } from "ramda";
import { push } from 'connected-react-router';

import login from "../actions";
import {apiRequest, notification} from '../../common/actions';
import routesConfig from "../../../routes/routesConfig";

const baseAction$ = action$ => action$.pipe(
    ofType(login.types.DEFAULT),
    debounceTime(500),
);

const loginPending = action$ => action$.pipe(
    baseAction$,
    mapTo(login.actions.PENDING()),
);

const loginRequest = action$ => action$.pipe(
    baseAction$,
    map(({payload, meta}) =>
        apiRequest.actions.DEFAULT(
            {method: 'POST', url: `Account/login/${payload.role}`, ...login.actions, data: pick(['username', 'password'], payload)},
            meta
        )
    )
);

const loginFulfilled = action$ => action$.pipe(
    ofType(login.types.FULFILLED),
    tap(({meta}) => {
        meta.setSubmitting(false);
    }),
    mergeMap(
        of(notification.actions.NOTIFY_SUCCESS('Successful login')),
        of(push(routesConfig.home.route))
    )
);

const loginFulfilledBase = action$ => action$.pipe(
    ofType(login.types.FULFILLED),
    tap(({meta}) => {
        meta.setSubmitting(false);
    })
);

const loginFulfilledNotify = action$ => action$.pipe(
    loginFulfilledBase,
    mapTo(notification.actions.NOTIFY_SUCCESS('Successful login'))
);

const loginFulfilledRedirect = action$ => action$.pipe(
    loginFulfilledBase,
    mapTo(push(routesConfig.home.route))
);

const loginRejected = action$ => action$.pipe(
    ofType(login.types.REJECTED),
    tap(({meta}) => {
        meta.setSubmitting(false);
    }),
    map(({payload}) => (notification.actions.NOTIFY_ERROR('Failed to login')))
);

export default combineEpics(loginPending, loginRequest, loginFulfilledNotify, loginFulfilledRedirect, loginRejected);