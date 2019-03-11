import React, { Component } from 'react';
import MaterialIcon from 'material-icons-react';
import PropTypes from "prop-types";

import "./info-row.css";

class InfoRow extends Component {
    render() {
        const {title, value} = this.props;

        return (
            <div className="row info-row align-items-center">
                <div className="col col-4 title">
                    {title}
                </div>
                <div className="col col-7 text">
                    {value}
                </div>
                <div className="col col-1">
                    <MaterialIcon icon="arrow_forward_ios" size={32} color="#DFDFDF"/>
                </div>
            </div>
        );
    }
}

InfoRow.propTypes = {
    title: PropTypes.string,
    value: PropTypes.any,
}

export default InfoRow;