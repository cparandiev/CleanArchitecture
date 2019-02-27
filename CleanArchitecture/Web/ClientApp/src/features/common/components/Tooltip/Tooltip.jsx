import React, { Component } from 'react';
import RTooltip from 'react-tooltip-lite';
import PropTypes from "prop-types";

import "./tooltip.css";

class Tooltip extends Component {
    render() {
        const {label, children} = this.props

        return (
            <RTooltip content={label}>
                {children}
            </RTooltip>
        );
    }
}

Tooltip.propTypes = {
    label: PropTypes.object
}

export default Tooltip;