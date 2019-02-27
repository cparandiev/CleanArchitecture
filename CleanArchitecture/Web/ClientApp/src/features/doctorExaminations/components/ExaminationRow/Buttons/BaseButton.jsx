import React, { Component } from 'react';
import PropTypes from "prop-types";
import MaterialIcon from 'material-icons-react';

import Tooltip from "../../../../common/components/Tooltip";

class BaseButton extends Component {
    render() {
        const {onClick, icon, size, label} = this.props;

        return (
            <Tooltip label={<div>{label}</div>} >
                <MaterialIcon onClick={onClick} className={`material-icons ${size} md-dark clickable-icon`} icon={icon} size={`${size}`} />
            </Tooltip>
        );
    }
}

BaseButton.propTypes = {
    onClick: PropTypes.func,
    icon: PropTypes.string,
    size: PropTypes.number,
    label: PropTypes.string,
}

export default BaseButton;