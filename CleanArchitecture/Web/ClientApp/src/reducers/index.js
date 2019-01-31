import { combineReducers } from 'redux';

import commonReducers from '../features/common/reducers';

export default combineReducers({
    user: commonReducers.authReducer
})