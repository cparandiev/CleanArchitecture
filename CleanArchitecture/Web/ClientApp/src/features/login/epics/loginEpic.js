import loginPatient from "../actions";
import { filter, mapTo } from 'rxjs/operators';

const loginEpic = action$ => action$.pipe(
    filter(action => action.type === loginPatient.types.DEFAULT),
    mapTo({ type: 'PONG' })
);

export default loginEpic;