import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {isEmpty, any, includes, __, isNil, all} from "ramda";
import { Route, Redirect } from 'react-router-dom';
import {connect} from 'react-redux';

import {userSelector} from "../features/common/selectors";
import mergeSelectors from "../utils/mergeSelectors";
import routesConfig from "./routesConfig";

const userIsInRole = (userRoles, requiredRoles) => 
    isEmpty(requiredRoles)  || 
    isNil(requiredRoles) ||
    any(all(includes(__, userRoles)), requiredRoles);

const ComponentWrapper = ({Component, user, requiredRoles, ...rest}) => {
    const authorized = userIsInRole(user.roles, requiredRoles);
    
    return (user.authenticated && authorized)
        ? (<Component {...rest}/>)
        : (user.authenticated
            ? (<Redirect to={routesConfig.unauthorized.path} />)
            : (<Redirect to={routesConfig.signIn.path} />));
}

const selectors = [userSelector];
const mapStateToProps = mergeSelectors(selectors);
const ConnectedComponentWrapper = connect(mapStateToProps)(ComponentWrapper);

class PrivateRoute extends Component {
    render() {
        const {requiredRoles, exact, path, component} = this.props;
        
        return (<Route 
            exact={exact}
            path={path}
            component={(props) => <ConnectedComponentWrapper Component={component} requiredRoles={requiredRoles} {...props}/>} />);
    }
}

PrivateRoute.propTypes = {
    exact: PropTypes.bool,
    path: PropTypes.string,
    component: PropTypes.func,
    requiredRoles: PropTypes.array,
}

export default PrivateRoute;