import React, { Component } from 'react';
import DatePicker from "react-datepicker";
import PropTypes from "prop-types";

class Custom extends Component {
    render() {
        const {value, handleChange, title} = this.props;

        return (
            <div className="row">
                <div className="col-2 col-form-label">
                    <label className="title">{title}</label>
                </div>
                <div className="col">
                    <DatePicker showTimeSelect selected={value} onChange={handleChange} className="form-control"
                        timeFormat="HH:mm" timeIntervals={15} dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                </div>
            </div>
        );
    }
}

Custom.propTypes = {
    title: PropTypes.string,
    handleChange: PropTypes.func,
    value: PropTypes.instanceOf(Date),
}

export default Custom;