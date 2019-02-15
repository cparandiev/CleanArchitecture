import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {isEmpty, all, includes, __, isNil} from "ramda";
import { Route, Redirect } from 'react-router-dom';
import {connect} from 'react-redux';

import {userSelector} from "../features/common/selectors";
import mergeSelectors from "../utils/mergeSelectors";
import routesConfig from "./routesConfig";

const userIsInRole = (userRoles, requiredRoles) => 
    isEmpty(requiredRoles)  || 
    isNil(requiredRoles) ||
    all(includes(__, userRoles), (requiredRoles));

class PrivateRoute extends Component {
    render() {
        const {user, requiredRoles, exact, path, component} = this.props;
        const authorized = userIsInRole(user.roles, requiredRoles);

        return (
            (user.authenticated && authorized)
                ? (<Route exact={exact} path={path} component={component}/>)
                : (<Route exact={exact} path={path} render={() =>
                    user.authenticated
                        ? (<Redirect to={routesConfig.unauthorized.path} />)
                        : (<Redirect to={routesConfig.signIn.path} />)}
                    />)
        );
    }
}

const selectors = [userSelector];

const mapStateToProps = mergeSelectors(selectors);

PrivateRoute.propTypes = {
    exact: PropTypes.bool,
    path: PropTypes.string,
    component: PropTypes.func,
    requiredRoles: PropTypes.array,
}

export default connect(mapStateToProps)(PrivateRoute);