import React, { Component } from 'react';
import PropTypes from "prop-types";
import {Link} from "react-router-dom";

import BaseButton from "./BaseButton";
import routesConfig from "../../../../../routes/routesConfig";

class AccomplishButton extends Component {
    render() {
        const {id} = this.props;

        return (
            <Link to={routesConfig.accomplishMedicalExamination.path.replace(':id(\\d+)', id)}>
                <BaseButton label={"Start examination"} size={32} icon="rate_review"/>
            </Link>
        );
    }
}

AccomplishButton.propTypes = {
    id: PropTypes.number,
}

export default AccomplishButton;