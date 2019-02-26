import React, { Component } from 'react';
import PropTypes from "prop-types";

import DatePicker from "../../../common/components/DatePicker";

class RangePicker extends Component {
    render() {
        const {titleFrom, titleTo, dateFrom, dateTo, handleChangeFrom, handleChangeTo} = this.props;

        return (
            <div className="row">
                <div className="col-5 offset-1">
                    <DatePicker title={titleFrom} value={dateFrom} handleChange={handleChangeFrom} datePickerContainerClassName="col" rowClassName="row"  titleContainerClassName="col-2 col-form-label"/>
                </div>
                <div className="col-5">
                    <DatePicker title={titleTo} value={dateTo} handleChange={handleChangeTo} datePickerContainerClassName="col" rowClassName="row" titleContainerClassName="col-2 col-form-label"/>
                </div>
            </div>
        );
    }
}

RangePicker.propTypes = {
    titleFrom: PropTypes.string,
    titleTo: PropTypes.string,
    dateFrom: PropTypes.instanceOf(Date),
    dateTo: PropTypes.instanceOf(Date),
    handleChangeFrom: PropTypes.func,
    handleChangeTo: PropTypes.func,
}

export default RangePicker;