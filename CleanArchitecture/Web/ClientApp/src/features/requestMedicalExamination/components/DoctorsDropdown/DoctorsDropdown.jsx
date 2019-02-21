import React, { Component } from 'react';
import PropTypes from "prop-types";
import {map} from 'ramda';

class ClinicsDropdown extends Component {
    render() {
        const {doctors, handleSelected, selectedDoctorId, disabled} = this.props;

        return (
            <select className="custom-select" value={selectedDoctorId} onChange={handleSelected} disabled={disabled}>
                <option value="0">Select doctor</option>
                {map(({id, user}) => <option key={id} value={id}>{user.firstName} {user.lastName}</option>, doctors)}                
            </select>
        );
    }
}

ClinicsDropdown.propTypes = {
    doctors: PropTypes.array,
    handleSelected: PropTypes.func,
    selectedDoctorId: PropTypes.number,
    disabled: PropTypes.bool,
}

export default ClinicsDropdown;