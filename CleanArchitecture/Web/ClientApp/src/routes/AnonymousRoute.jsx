import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Route, Redirect } from 'react-router';
import {connect} from 'react-redux';

import {userSelector} from "../features/common/selectors";
import mergeSelectors from "../utils/mergeSelectors";
import routesConfig from "./routesConfig";

class AnonymousRoute extends Component {
    render() {
        const {user, exact, path, component} = this.props;

        return (
            !user.authenticated     
                ? <Route exact={exact} path={path} component={component}/>
                : <Route exact={exact} path={path} render={() => (<Redirect to={routesConfig.home.path} />)}/>
        );
    }
}

const selectors = [userSelector];

const mapStateToProps = mergeSelectors(selectors);

AnonymousRoute.propTypes = {
    exact: PropTypes.bool,
    path: PropTypes.string,
    component: PropTypes.func,
}

export default connect(mapStateToProps)(AnonymousRoute);