import React, { Component } from 'react';
import { connect } from "react-redux";
import { ToastContainer, toast } from 'react-toastify';

import "./notifications.css";

class Notifications extends Component {
    componentWillReceiveProps({notification}){
        console.log(notification);
        switch(notification.type){
            case "SUCCESS":
                return toast(notification.message, {className: "notification-container notification-success"});
            case "ERROR":
                return toast.error(notification.message, {className: "notification-container notification-error"});
        }
    }

    render() {
        return (
            <div>
                <ToastContainer position="bottom-right" hideProgressBar autoClose={false}/>
            </div>
        );
    }
}

const mapStateToProps = (state) => ({
    notification: state.notification
});

export default connect(mapStateToProps)(Notifications);