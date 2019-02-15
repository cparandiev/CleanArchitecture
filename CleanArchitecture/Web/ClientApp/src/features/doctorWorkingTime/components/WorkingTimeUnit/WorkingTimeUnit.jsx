import React, { Component } from 'react';
import PropTypes from "prop-types";
import DatePicker from "react-datepicker";
import MaterialIcon from 'material-icons-react';

import "./working-time-unit.css";

class WorkingTimeUnit extends Component {
    render() {
        const {from, to} = this.props;

        return (
            <div className="row working-time-row">
                <div className="col-5">
                    <DatePicker selected={from}  className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                </div>
                <div className="col-5">
                    <DatePicker selected={to} className="form-control" readOnly timeFormat="HH:mm" dateFormat="MMMM d, yyyy h:mm aa" timeCaption="time"/>
                </div>
                <div className="col-2">
                    <MaterialIcon className="btn material-icons 32 md-dark" icon="delete_forever" size="32" />
                </div>
            </div>
        );
    }
}

WorkingTimeUnit.propTypes = {
    from: PropTypes.instanceOf(Date),
    to: PropTypes.instanceOf(Date),
}


export default WorkingTimeUnit;