import React from 'react';

import "./patient-header.css";

export default () => (<div className="patient-header-container">
    <div className="row align-items-center patient-header">
        <div className="col d-flex justify-content-center patient-header-title">First Name</div>
        <div className="col d-flex justify-content-center patient-header-title">Last Name</div>
        <div className="col d-flex justify-content-center patient-header-title">Gender</div>
        <div className="col d-flex justify-content-center patient-header-title">Actions</div>        
    </div>
</div>);