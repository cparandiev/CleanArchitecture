import React, { Component } from 'react';
import { connect } from 'react-redux';

import Navbar from "./components/Navbar";
import {userSelector, currentRouteSelector} from "../common/selectors";
import mergeSelectors from "../../utils/mergeSelectors";
import {configureRoutes, getUserAllowedRoutes, initializePathParameters} from "./utils";
import routesConfig from "../../routes/routesConfig";
import navbarConfigs from "./navbarConfigs";

class Navigation extends Component {
    
    render() {
        const {currentRoute, user} = this.props;

        const allowedRoutes = getUserAllowedRoutes(user.roles, navbarConfigs);
        const routes = configureRoutes(allowedRoutes, routesConfig);
        const initializedRoutes = initializePathParameters(routes, user);

        return (
            <Navbar currentRoute={currentRoute} user={user} routes={initializedRoutes}/>
        );
    }
}

const selectors = [currentRouteSelector, userSelector];

const mapStateToProps = mergeSelectors(selectors);


export default connect(mapStateToProps)(Navigation);