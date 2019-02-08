import React, { Component } from "react";
import PropTypes from 'prop-types';
import {map, compose} from 'ramda';

import NavItem from "./NavItem";
import renderClassAsFunction from "../../../../utils/renderClassAsFunction";

const createNavItemProps = (currentRoute) => ({route, text}) => ({key: route, route, active: currentRoute === `/${route}`, children: text});

const createNavItems = (currentRoute, routes) => map(compose(renderClassAsFunction(NavItem), createNavItemProps(currentRoute)))(routes);

class Navbar extends Component {
  render() {
    const {currentRoute, user} = this.props;
    
    console.log(user);

    const routes = [{
      route: 'one',
      text: 'one-text'
    },{
      route: 'two',
      text: 'two-text'
    },{
      route: 'three',
      text: 'three-text'
    }];

    return (
      <nav className="navbar fixed-top navbar-expand-lg navbar-light bg-light">
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarText">
          <ul className="navbar-nav mr-auto nav-pills">
            {createNavItems(currentRoute, routes)}
          </ul>
        </div>
      </nav>
      );
  }
}

Navbar.propTypes = {
  currentRoute: PropTypes.string,
  user: PropTypes.object,
}

export default Navbar;