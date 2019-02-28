import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Route, Redirect } from 'react-router-dom';
import {connect} from 'react-redux';

import {userSelector} from "../features/common/selectors";
import mergeSelectors from "../utils/mergeSelectors";
import routesConfig from "./routesConfig";

const ComponentWrapper = ({Component, user, ...rest}) => {
    
    return !user.authenticated     
        ? (<Component {...rest}/>)
        : (<Redirect to={routesConfig.home.path} />);
}

const selectors = [userSelector];
const mapStateToProps = mergeSelectors(selectors);
const ConnectedComponentWrapper = connect(mapStateToProps)(ComponentWrapper);

class AnonymousRoute extends Component {
    render() {
        const {exact, path, component} = this.props;

        return (
            <Route 
                exact={exact}
                path={path}
                component={(props) => <ConnectedComponentWrapper Component={component} {...props}/>} 
            />
        );
    }
}

AnonymousRoute.propTypes = {
    exact: PropTypes.bool,
    path: PropTypes.string,
    component: PropTypes.func,
}

export default AnonymousRoute;