import React, { Component } from 'react';
import DatePicker from "react-datepicker";
import PropTypes from "prop-types";

class Custom extends Component {
    render() {
        const {value, handleChange, title, datePickerContainerClassName, rowClassName, titleContainerClassName} = this.props;

        return (
            <div className={rowClassName}>
                <div className={titleContainerClassName}>
                    <label className="title">{title}</label>
                </div>
                <div className={datePickerContainerClassName}>
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
    datePickerContainerClassName: PropTypes.string,
    titleContainerClassName: PropTypes.string,
    rowClassName: PropTypes.string,
}

export default Custom;