import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { AreaChart, linearGradient, XAxis, YAxis, CartesianGrid, Tooltip, Area, ReferenceLine} from "recharts";

class CAreaChart extends Component {
    render() {
        const {data, dataKey, minHealthyValue, maxHealthyValue, yAxisRange, xDataKey, xTickFormatter, yUnit, CustomTooltip} = this.props;
        return (
            <AreaChart width={800} height={300} data={data} 
                margin={{ top: 10, right: 30, left: 0, bottom: 0 }}>
                <defs>
                    <linearGradient id="colorUv" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#8884d8" stopOpacity={0.8}/>
                    <stop offset="95%" stopColor="#8884d8" stopOpacity={0}/>
                    </linearGradient>
                </defs>
                <XAxis dataKey={xDataKey} tickFormatter={xTickFormatter} />
                <YAxis domain={yAxisRange} unit={yUnit} />
                <CartesianGrid strokeDasharray="3 3" />
                <Tooltip content={CustomTooltip}/>
                <ReferenceLine y={maxHealthyValue} label="Max" stroke="red"/>
                <ReferenceLine y={minHealthyValue} label="Min" stroke="red"/>
                <Area type="monotone" dataKey={dataKey} stroke="#8884d8" fillOpacity={1} fill="url(#colorUv)"/>
            </AreaChart>
        );
    }
}

CAreaChart.propTypes = {
};

export default CAreaChart;