import React, { Component } from 'react';
import PropTypes from "prop-types";

import BaseButton from "./BaseButton";

class InformationButton extends Component {
    render() {
        const {onClick} = this.props;

        return (
            <BaseButton onClick={onClick} label={"More info"} size={24} icon="info"/>
        );
    }
}

InformationButton.propTypes = {
    onClick: PropTypes.func,
}

export default InformationButton;