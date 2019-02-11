import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {isEmpty, all, includes, __} from "ramda";

import {userSelector} from "../features/common/selectors";
import mergeSelectors from "../utils/mergeSelectors";

const userIsInRole = (userRoles, requiredRoles) => 
    isEmpty(requiredRoles) || 
    all(includes(__, userRoles))(require);

class PrivateRoute extends Component {
    render() {
        const {user, requiredRoles} = this.props;
        
        return (
            <React.Fragment>
                {(user.authenticated && userIsInRole(user.roles, requiredRoles))
                    ? (<div> </div>)
                    :(<div> </div>)}
            </React.Fragment>
        );
    }
}

const selectors = [userSelector];

const mapStateToProps = mergeSelectors(selectors);

PrivateRoute.PropTypes = {
    exact: PropTypes.bool,
    path: PropTypes.string,
    component: PropTypes.object,
    requiredRoles: PropTypes.array,
}

export default connect(mapStateToProps)(Navigation);