import {map, replace, pipe} from 'ramda';

const addPathParams = (path, user) => pipe(
    replace(':patientId(\\d+)', user.patientId),
)(path)

export default (routes, user) => map(
    (route) => ({...route, path: addPathParams(route.path, user)}),
    routes
);