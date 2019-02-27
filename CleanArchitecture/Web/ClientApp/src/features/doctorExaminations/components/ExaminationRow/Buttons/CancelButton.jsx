import React, { Component } from 'react';
import PropTypes from "prop-types";

import BaseButton from "./BaseButton";

class CancelButton extends Component {
    render() {
        const {onClick} = this.props;

        return (
            <BaseButton onClick={onClick} label={"Cancel request"} size={32} icon="cancel"/>
        );
    }
}

CancelButton.propTypes = {
    onClick: PropTypes.func,
}

export default CancelButton;