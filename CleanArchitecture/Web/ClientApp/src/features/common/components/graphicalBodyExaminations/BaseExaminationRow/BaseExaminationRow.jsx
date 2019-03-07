import React, { Component } from 'react';
import PropTypes from "prop-types";
import { max, map, prop, min, apply } from "ramda";

import AreaChart from "../../AreaChart";

class BaseExaminationRow extends Component {
    state = {expand: false}

    toggleOpen = () => {this.setState((state) => ({...state, expand: !state.expand}));}

    render() {
        const {expand} = this.state;
        const {title, data, dataKey, minHealthyValue, maxHealthyValue, xDataKey, xTickFormatter, yUnit, CustomTooltip} = this.props;

        const dataValues =  map(prop(dataKey), data);
        const yAxisMax = apply(max, [maxHealthyValue, ...dataValues]);
        let yAxisMin = apply(min, [minHealthyValue, ...dataValues]);
        yAxisMin = minHealthyValue === yAxisMin ? 2*yAxisMin - maxHealthyValue : yAxisMin;

        return (
            <div className="body-graphical-examination-row-container-wrapper">
                <div className="body-graphical-examination-row-container">
                    <div className="row body-graphical-examination-row justify-content-md-center">
                        <div className="col col-md-auto title btn" onClick={this.toggleOpen}>
                            {title}
                        </div>
                    </div>
                    {expand &&
                    (<div className="row justify-content-md-center">
                        <div className="col col-md-auto">
                            <AreaChart data={data} dataKey={dataKey} minHealthyValue={minHealthyValue} maxHealthyValue={maxHealthyValue}
                            yAxisRange={[yAxisMin, yAxisMax]} xDataKey={xDataKey} xTickFormatter={xTickFormatter} yUnit={yUnit} CustomTooltip={CustomTooltip} />
                        </div>
                    </div>)}
                </div>
            </div>
        );
    }
}

BaseExaminationRow.propTypes = {
    title: PropTypes.string
}

export default BaseExaminationRow;