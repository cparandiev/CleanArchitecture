import React, { Component } from "react";
import PropTypes from 'prop-types';
import {map, filter, propEq} from 'ramda';
import MaterialIcon from 'material-icons-react';

import NavItem from "../NavItem";

const createNavItems = (currentRoute, routes) => map(({route, text}) => (
  <NavItem key={route} active={currentRoute === route} route={route}>
    {text}
  </NavItem>
))(routes);

class Navbar extends Component {
  render() {
    const {currentRoute, routes} = this.props;
    
    const leftRoutes = filter(propEq('position', 'left'), routes);
    const userDropdownRoutes = filter(propEq('position', 'user-dropdown'), routes);

    return (
      <nav className="navbar fixed-top navbar-expand-lg navbar-light bg-light">
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarText">
          <ul className="navbar-nav mr-auto nav-pills">
            {createNavItems(currentRoute, leftRoutes)}
          </ul>
          <div className={`nav-item dropdown float-right `}>
              <a className="nav-link" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <MaterialIcon icon="person" size="32" />
              </a>
              <div className="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown">
                {createNavItems(currentRoute, userDropdownRoutes)}
              </div>
          </div>
        </div>
      </nav>
    );
  }
}

Navbar.propTypes = {
  currentRoute: PropTypes.string,
  user: PropTypes.object,
  routes: PropTypes.array,
}

export default Navbar;