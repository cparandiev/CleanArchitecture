import React, { Component } from 'react';
import PropTypes from "prop-types";
import MaterialIcon from 'material-icons-react';
import RDatePicker from "react-datepicker";
import DatePicker from "../../../common/components/DatePicker";
import "./working-time-row.css";

class WorkingTimeRow extends Component {
    state = {expand: false}

    toggleOpen = () => {this.setState((state) => ({...state, expand: !state.expand}));}

    render() {
        const {expand} = this.state;
        const {open, close, handleRequestDateChange, handleDurationInMinutesChange, durationInMinutes, requestDate, onSubmit} = this.props;

        return (
            <div className="request-working-time-row-container">
                <div className="row request-working-time-row">
                    <div className="col">
                        <RDatePicker selected={open}  className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                    </div>
                    <div className="col">
                        <RDatePicker selected={close} className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                    </div>
                    <div className="col-1">
                        <MaterialIcon key={expand} className="material-icons 32 md-dark clickable-icon float-right" icon={expand ? "expand_less"  : "expand_more"} size="32" onClick={this.toggleOpen}/>
                    </div>
                </div>
                {expand && 
                (<div className="request-working-time-expandable-row-container">
                    <div className="row ">
                        <div className="col-6 offset-1">
                            <DatePicker title='Request date' value={requestDate} handleChange={handleRequestDateChange} datePickerContainerClassName="col-9" rowClassName="row"  titleContainerClassName="col-3 col-form-label"/>
                        </div>
                        <div className="col-3">
                            <input type="number" className="form-control" id="durationInMinutes" placeholder="Duration in minutes" value={durationInMinutes} onChange={handleDurationInMinutesChange}/>
                        </div>
                        <div className="col-2">
                            <div className="float-right">
                                <button type="button" className="btn btn-primary" onClick={onSubmit}>Request</button>
                            </div>
                        </div>
                    </div>
                </div>)
                }
            </div>
        );
    }
}

WorkingTimeRow.propTypes = {
    open: PropTypes.instanceOf(Date),
    close: PropTypes.instanceOf(Date),
    handleRequestDateChange: PropTypes.func,
    handleDurationInMinutesChange: PropTypes.func,
    durationInMinutes: PropTypes.any,
    requestDate: PropTypes.instanceOf(Date),
    onSubmit: PropTypes.func,
}

export default WorkingTimeRow;