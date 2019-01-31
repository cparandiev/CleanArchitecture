import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'reactstrap';

class Button extends Component {
    render() {
        return (
            <Button {...this.props}/>     
        );
    }
}

Button.PropTypes = {
    active: PropTypes.bool,
    size: PropTypes.oneOf(['sm', 'lg']),
    disabled: PropTypes.bool,
    color: PropTypes.oneOf(['primary', 'secondary', 'success', 'info', 'warning', 'danger', 'link']),
    className: PropTypes.string,
    onClick: PropTypes.func,
}

export default Button;