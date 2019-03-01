import React, { Component } from 'react';
import PropTypes from 'prop-types';

class BloodOxygenLevelRow extends Component {
    render() {
        const {oxygenLevel} = this.props;

        return (
            <div className="row justify-content-md-center">
                <div className="col-md-auto text">
                    {`Blood Oxygen Level: ${oxygenLevel} %`}
                </div>
            </div>
        );
    }
}

BloodOxygenLevelRow.propTypes = {
    oxygenLevel: PropTypes.number
};

export default BloodOxygenLevelRow;