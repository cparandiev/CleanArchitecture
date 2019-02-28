import { Component } from 'react';
import { connect } from 'react-redux';

import { logout } from "./actions";

class Logout extends Component {

    constructor(props){
        super(props);
        const {logout} = props;

        logout();
    }

    render() {
        return null;
    }
}


const mapDispatchToProps = (dispatch) => ({
    logout: () => dispatch(logout.actions.DEFAULT()),
});

export default connect(null, mapDispatchToProps)(Logout);