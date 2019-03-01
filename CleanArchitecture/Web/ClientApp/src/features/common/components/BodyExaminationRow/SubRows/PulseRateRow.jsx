import React, { Component } from 'react';
import PropTypes from 'prop-types';

class PulseRateRow extends Component {
    render() {
        const {rate} = this.props;

        return (
            <div className="row justify-content-md-center">
                <div className="col-md-auto text">
                    {`Pulse Rate: ${rate} bpm`}
                </div>
            </div>
        );
    }
}

PulseRateRow.propTypes = {
    rate: PropTypes.number,
};

export default PulseRateRow;