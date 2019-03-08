import React, { Component } from 'react';
import PropTypes from "prop-types";
import {Link} from "react-router-dom";

import BaseButton from "./BaseButton";
import routesConfig from "../../../../../routes/routesConfig";

class MedicalExaminationsButton extends Component {
    render() {
        const {id} = this.props;

        return (
            <Link to={routesConfig.patientMedicalExaminations.path.replace(':patientId(\\d+)', id)}>
                <BaseButton label={"Patient Medical Examinations"} size={32} icon="event_note"/>
            </Link>
        );
    }
}

MedicalExaminationsButton.propTypes = {
    id: PropTypes.number,
}

export default MedicalExaminationsButton;