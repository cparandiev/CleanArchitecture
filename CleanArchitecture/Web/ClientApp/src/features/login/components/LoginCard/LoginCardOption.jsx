import React, { Component } from 'react';
import PropTypes from 'prop-types';

class LoginCardOption extends Component {
    render() {
        const {active, onClick, children} = this.props;
        const className = active ? 'btn nav-link active' : 'btn nav-link';

        return (
            <li className="nav-item">
                <a className={className} onClick={onClick}>
                    {children}
                </a>
            </li>
        );
    }
}

LoginCardOption.propTypes = {
    role: PropTypes.string,
    active: PropTypes.bool,
    onClick: PropTypes.func,
}

export default LoginCardOption;