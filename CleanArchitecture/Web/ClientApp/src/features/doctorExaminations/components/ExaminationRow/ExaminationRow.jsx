import React, { Component } from 'react';
import DatePicker from "react-datepicker";
import MaterialIcon from 'material-icons-react';
import PropTypes from "prop-types";
import { equals, pickAll, map } from "ramda";

import {AccomplishButton, AcceptButton, CancelButton, InformationButton} from "./Buttons"
import "./examination-row.css";

class ExaminationRow extends Component {
    state = {open: false}

    toggleOpen = () => {this.setState((state) => ({...state, open: !state.open}));}

    shouldComponentUpdate(nextProps, nextState) {
        const objs = map(pickAll(['isAccomplished', 'isApproved']), [nextProps, this.props]);

        return !equals(objs[0], objs[1]) || !equals(nextState, this.state);
    }

    handleAccept = () => {
        const {handleReview, id} = this.props

        handleReview(id, true);
    }

    
    handleCancel = () => {
        const {handleReview, id} = this.props

        handleReview(id, false);
    }

    render() {
        const {open} = this.state;
        const {requestDate, isAccomplished, isApproved, result, id} = this.props;

        return (
            <div className="doctor-examination-row">
                <div className="row align-items-center">
                    <div className="col-3 d-flex justify-content-center title">
                        <DatePicker selected={requestDate}  className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                    </div>
                    <div className="col-3 d-flex justify-content-center title">
                        Cvetko Parandiev
                    </div>
                    <div className="col-2 d-flex justify-content-center title">
                        <MaterialIcon key={isApproved} icon={isApproved ? "check_circle" : "block"} size="24"/>
                    </div>
                    <div className="col-2 d-flex justify-content-center title">
                        <MaterialIcon key={isAccomplished} icon={isAccomplished ? "check_circle" : "block"} size="24" />
                    </div>
                    <div className="col-2 d-flex justify-content-center title">
                        {isApproved && !isAccomplished && <AccomplishButton id={id}/>}
                        {!isApproved && <AcceptButton onClick={this.handleAccept}/>}
                        {isApproved && !isAccomplished && <CancelButton onClick={this.handleCancel}/>}
                        {isAccomplished && <InformationButton onClick={this.toggleOpen}/>}
                    </div>
                </div>
                {open && (<div className="doctor-examination-expandable-row-container">
                    <div className="row">
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

ExaminationRow.propTypes = {
    handleReview: PropTypes.func,
    durationInMinutes: PropTypes.number,
    requestDate: PropTypes.instanceOf(Date),
    isAccomplished: PropTypes.bool,
    isApproved: PropTypes.bool,
    id: PropTypes.number,
    result: PropTypes.object,
}

export default ExaminationRow;