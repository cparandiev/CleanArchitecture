import React, { Component } from 'react';
import { Route } from 'react-router';
import { map, compose, values } from "ramda";

import routesConfig from "./routesConfig";
import PrivateRoute from "./PrivateRoute";
import AnonymousRoute from "./AnonymousRoute";

const createRoutes = compose(
    map((props) => props.authenticated === true
        ? <PrivateRoute key={props.path} {...props}/>
        : props.authenticated === false
            ? <AnonymousRoute key={props.path} {...props}/>
            : <Route key={props.path} {...props}/>
    ),
    values
);

class Routes extends Component {
    render() {
        return (
            createRoutes(routesConfig)
        );
    }
}

export default Routes;