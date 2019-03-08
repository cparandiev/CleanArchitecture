import React, { Component } from 'react';
import PropTypes from "prop-types";
import {Link} from "react-router-dom";

import BaseButton from "./BaseButton";
import routesConfig from "../../../../../routes/routesConfig";

class ProfileButton extends Component {
    render() {
        const {id} = this.props;

        return (
            <Link to={routesConfig.accomplishMedicalExamination.path.replace(':id(\\d+)', id)}>
                <BaseButton label={"Patient Profile"} size={32} icon="person_pin"/>
            </Link>
        );
    }
}

ProfileButton.propTypes = {
    id: PropTypes.number,
}

export default ProfileButton;