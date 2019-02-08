import React from "react";

const renderClassAsFunction = (Component) => (props) => <Component {...props}/>;

export default renderClassAsFunction;