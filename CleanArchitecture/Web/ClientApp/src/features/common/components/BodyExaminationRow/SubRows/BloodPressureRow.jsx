import React, { Component } from 'react';
import PropTypes from 'prop-types';

class BloodPressureRow extends Component {
    render() {
        const {systolicBloodPressure, diastolicBloodPressure} = this.props;

        return (
            <div className="row justify-content-md-center">
                <div className="col-md-auto text">
                    {`Systolic Blood Pressure: ${systolicBloodPressure} mmHg`}
                </div>
                <div className="col-md-auto text">
                    {`Diastolic Blood Pressure: ${diastolicBloodPressure} mmHg`}
                </div>
            </div>
        );
    }
}

BloodPressureRow.propTypes = {
    systolicBloodPressure: PropTypes.number,
    diastolicBloodPressure: PropTypes.number
};

export default BloodPressureRow;