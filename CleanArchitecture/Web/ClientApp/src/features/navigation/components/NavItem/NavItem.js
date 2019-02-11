import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {Link} from "react-router-dom";

import "./nav-item.css";

const baseClassName = 'nav-item nav-link';

class NavItem extends Component {
    render() {
        const {active, route, children} = this.props;
        
        const className = active ? `${baseClassName} active-route` : baseClassName;

        return (
            <li className={className}>
                <Link to={route} className={className}>
                    {children}
                </Link>
            </li>
        );
    }
}

NavItem.propTypes = {
    route: PropTypes.string,
    active: PropTypes.bool
}

export default NavItem;