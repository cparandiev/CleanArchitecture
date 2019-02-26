import React, { Component } from 'react';
import PropTypes from "prop-types";
import DatePicker from "react-datepicker";
import MaterialIcon from 'material-icons-react';

import "./medical-examination-request-row.css";

class MedicalExaminationRequestRow extends Component {
    state={open: false}

    toggleOpen = () => {
        this.setState((state) => ({...state, open: !state.open}));
    }

    render() {
        const {open} = this.state;
        const {isApproved, clinic, isAccomplished, requestDate, doctor, result} = this.props;

        return (
            <div className="medical-examination-request-row">
                <div className="row align-items-center">
                    <div className="col-3 d-flex justify-content-center title">
                        <DatePicker selected={requestDate}  className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                    </div>
                    <div className="col-2 d-flex justify-content-center title">
                        {clinic}
                    </div>
                    <div className="col-2 d-flex justify-content-center title">
                        {doctor}
                    </div>
                    <div className="col-2 d-flex justify-content-center title">
                        <MaterialIcon icon={isApproved ? "check_circle" : "block"} size="24"/>
                    </div>
                    <div className="col-2 d-flex justify-content-center title">
                        <MaterialIcon icon={isAccomplished ? "check_circle" : "block"} size="24" />
                    </div>
                    <div className="col d-flex justify-content-center title">
                        <MaterialIcon key={open} className="material-icons 32 md-dark clickable-icon" icon={open ? "expand_less"  : "expand_more"} size="32" onClick={this.toggleOpen}/>
                    </div>
                </div>
                {open &&
                (<div className="medical-examination-request-expandable-content-container">
                    <div className="row align-items-center medical-examination-request-expandable-content-row">
                        <div className="col-2 offset-1 title">
                            Result:
                        </div>
                        <div className="col-8">
                            {result.notes}
                        </div>
                    </div>
                </div>)}
            </div>
        );
    }
}

MedicalExaminationRequestRow.protoTypes = {
    id: PropTypes.number,
    isApproved: PropTypes.bool,
    isAccomplished: PropTypes.bool,
    requestDate: PropTypes.instanceOf(Date),
    doctor: PropTypes.string,
    clinic: PropTypes.string,
    result: PropTypes.object,
}

export default MedicalExaminationRequestRow;