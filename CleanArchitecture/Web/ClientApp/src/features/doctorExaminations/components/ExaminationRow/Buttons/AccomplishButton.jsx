import React, { Component } from 'react';
import PropTypes from "prop-types";

import BaseButton from "./BaseButton";

class ReviewButton extends Component {
    render() {
        const {onClick} = this.props;

        return (
            <BaseButton onClick={onClick} label={"Start examination"} size={24} icon="rate_review"/>
        );
    }
}

ReviewButton.propTypes = {
    onClick: PropTypes.func,
}

export default ReviewButton;