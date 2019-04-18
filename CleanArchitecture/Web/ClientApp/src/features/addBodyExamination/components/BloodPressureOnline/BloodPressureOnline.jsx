import React, { Component } from 'react';

class BloodPressureOnline extends Component {
    render() {
        const {imgSrc, systolic, diastolic, handleClose} = this.props;

        return (
            <React.Fragment>
                <div className="col-6">
                    <h5 className="img-text">
                        Systolic: {systolic} mmHg Diastolic: {diastolic} mmHg
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

export default BloodPressureOnline;    