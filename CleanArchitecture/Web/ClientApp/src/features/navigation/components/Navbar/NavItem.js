import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {Link} from "react-router-dom";

import "./nav-item.css";

class NavItem extends Component {
    render() {
        const {active, route, children} = this.props;
        const className = active ? 'nav-item nav-link active-route' : 'nav-item nav-link';

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