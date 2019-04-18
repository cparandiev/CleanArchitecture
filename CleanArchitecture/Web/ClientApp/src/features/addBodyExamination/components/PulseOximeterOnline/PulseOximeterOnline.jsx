import React, { Component } from 'react';

class PulseOximeterOnline extends Component {
    render() {
        const {imgSrc, pulse, spO2, handleClose} = this.props;

        return (
            <React.Fragment>
                <div className="col-6">
                    <h5 className="img-text">
                        Pulse: {pulse} bpm Oxygen: {spO2} %
                    </h5>
                </div>
                <div className="col-6">
                    <div className="text-right">
                        <button type="button" className="btn btn-primary" onClick={handleClose}>Stop measurement</button>
                    </div>
                </div>
                <div className="col-12 d-flex justify-content-center">
                    <img src={imgSrc} className="img-fluid" />
                </div>
            </React.Fragment>
        );
    }
}

export default PulseOximeterOnline;    