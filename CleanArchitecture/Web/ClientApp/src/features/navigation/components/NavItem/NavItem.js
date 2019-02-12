import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {Link} from "react-router-dom";

import "./nav-item.css";

const baseClassName = 'nav-item nav-link';

class NavItem extends Component {
    render() {
        const {active, path, children} = this.props;
        
        const className = active ? `${baseClassName} active-route` : baseClassName;

        return (
            <li className={className}>
                <Link to={path} className={className}>
                    {children}
                </Link>
            </li>
        );
    }
}

NavItem.propTypes = {
    path: PropTypes.string,
    active: PropTypes.bool
}

export default NavItem;