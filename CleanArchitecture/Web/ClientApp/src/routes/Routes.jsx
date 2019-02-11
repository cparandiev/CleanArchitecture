import React, { Component } from 'react';
import { Route } from 'react-router';
import { map, compose, values } from "ramda";

import routesConfig from "./routesConfig";

const createRoutes = compose(
    map(({exact, route, component}) => <Route key={route} exact={exact} path={route} component={component}/>),
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