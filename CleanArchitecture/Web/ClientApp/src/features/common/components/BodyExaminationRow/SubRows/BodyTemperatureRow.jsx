import React, { Component } from 'react';
import PropTypes from 'prop-types';

class BodyTemperatureRow extends Component {
    render() {
        const {temperature} = this.props;

        return (
            <div className="row justify-content-md-center">
                <div className="col-md-auto text">
                    {`Temperature: ${temperature} °C`}
                </div>
            </div>
        );
    }
}

BodyTemperatureRow.propTypes = {
    temperature: PropTypes.number,
};

export default BodyTemperatureRow;