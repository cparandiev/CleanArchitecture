import React, { Component } from 'react';

import koogeekBP from "../../images/koogeek-bp1.jpg";
import koogeekBT from "../../images/koogeek-bt1.jpg";
import jumperJpd from "../../images/jumper-jpd-500a.jpg";
import "./add-body-examination.css";

class AddBodyExamination extends Component {
    render() {
        return (
            <React.Fragment>
                <div style={{fontWeight: 'bold', color: 'black', fontSize: '40px', textAlign: 'center', marginBottom: "50px"}}>
                    Select body examination
                </div>
                <div className="container">
                    <div className="row">
                        <div className="col img-wrapper">
                            <img src={koogeekBP} className="img-fluid" />
                            <div className="carousel-caption">
                                <h5 className="img-text">Blood pressure</h5>
                            </div>
                        </div>
                        <div className="col img-wrapper">
                            <img src={koogeekBT} className="img-fluid" />
                            <div className="carousel-caption">
                                <h5 className="img-text">Body temperature</h5>
                            </div>
                        </div>
                        <div className="col img-wrapper">
                            <img src={jumperJpd} className="img-fluid" />
                            <div className="carousel-caption">
                                <h5 className="img-text">Pulse oximeter</h5>
                            </div>
                        </div>
                    </div>
                </div>
            </React.Fragment>
        );
    }
}

export default AddBodyExamination;    