import {map, replace, pipe} from 'ramda';

const addPathParams = (path, user) => pipe(
    replace(':patientId(\\d+)', user.patientId),
    replace(':doctorId(\\d+)', user.doctorId),
)(path)

export default (routes, user) => map(
    (route) => ({...route, path: addPathParams(route.path, user)}),
    routes
);