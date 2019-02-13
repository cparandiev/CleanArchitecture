import commonReducers from '../features/common/reducers';
import notificationReducer from '../features/notifications/reducers';

export default ({
    user: commonReducers.authReducer,
    notification: notificationReducer
})