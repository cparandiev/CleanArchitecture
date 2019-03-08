import React, { Component } from 'react';
import PropTypes from "prop-types";
import {Link} from "react-router-dom";

import BaseButton from "./BaseButton";
import routesConfig from "../../../../../routes/routesConfig";

class BodyExaminationsButton extends Component {
    render() {
        const {id} = this.props;

        return (
            <Link to={routesConfig.patientBodyExaminations.path.replace(':patientId(\\d+)', id)}>
                <BaseButton label={"Patient Body Examinations"} size={32} icon="accessibility"/>
            </Link>
        );
    }
}

BodyExaminationsButton.propTypes = {
    id: PropTypes.number,
}

export default BodyExaminationsButton;