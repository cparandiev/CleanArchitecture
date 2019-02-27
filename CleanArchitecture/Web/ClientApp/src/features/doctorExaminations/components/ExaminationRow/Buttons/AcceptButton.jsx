import React, { Component } from 'react';
import PropTypes from "prop-types";

import BaseButton from "./BaseButton";

class AcceptButton extends Component {
    render() {
        const {onClick} = this.props;

        return (
            <BaseButton onClick={onClick} label={"Accept request"} size={24} icon="done"/>
        );
    }
}

AcceptButton.propTypes = {
    onClick: PropTypes.func,
}

export default AcceptButton;