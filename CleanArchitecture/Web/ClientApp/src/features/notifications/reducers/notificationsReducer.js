import {notification} from "../../common/actions";

const initialState = {
    type: '',
    message: ''
}

const notificationsReducer = (state = initialState, {type, payload})=> {
    switch(type){
        case notification.types.NOTIFY_SUCCESS:
            return {type: 'SUCCESS', message: payload};
        case notification.types.NOTIFY_ERROR:
            return {type: 'ERROR', message: payload};
        default: 
            return state;
    }
}

export default notificationsReducer;