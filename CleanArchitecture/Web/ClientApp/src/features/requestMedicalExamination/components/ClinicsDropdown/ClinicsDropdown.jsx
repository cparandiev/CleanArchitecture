import React, { Component } from 'react';
import PropTypes from "prop-types";
import {map} from 'ramda';

class ClinicsDropdown extends Component {
    render() {
        const {clinics, handleSelected, selectedClinicId} = this.props;

        return (
            <select className="custom-select" value={selectedClinicId} onChange={handleSelected}>
                <option value="0">Select clinic</option>
                {map(({id, name}) => <option key={id} value={id}>{name}</option>, clinics)}                
            </select>
        );
    }
}

ClinicsDropdown.propTypes = {
    clinics: PropTypes.array,
    handleSelected: PropTypes.func,
    selectedClinicId: PropTypes.number
}

export default ClinicsDropdown;