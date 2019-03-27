import React, { Component } from 'react';

import BodyExaminationItem from "./components/BodyExaminationItem";
import koogeekBP from "../../images/koogeek-bp1.jpg";
import koogeekBT from "../../images/koogeek-bt1.jpg";
import jumperJpd from "../../images/jumper-jpd-500a.jpg";
import {decodeBloodPressureRawData, decodeBodyTemperatureRawData, decodePulseOximeterRawData} from "./utils";
import "./add-body-examination.css";

const someFunc = ({service_uuid, characteristic_uuid, decoder}) => {
    navigator.bluetooth
        .requestDevice({ 
            acceptAllDevices: true,
            optionalServices: [service_uuid]
        })
        .then(device => device.gatt.connect())
        .then(server => server.getPrimaryService(service_uuid))
        .then(service => service.getCharacteristic(characteristic_uuid))
        .then(characteristic => characteristic.startNotifications())
        .then(characteristic => {
            characteristic.addEventListener(
                'characteristicvaluechanged',
                decoder
            );
        })
        .catch(error => { console.log(error); });
}

class AddBodyExamination extends Component {
    render() {
        return (
            <React.Fragment>
                <div style={{fontWeight: 'bold', color: 'black', fontSize: '40px', textAlign: 'center', marginBottom: "50px"}}>
                    Select body examination
                </div>
                <div className="container">
                    <div className="row">
                        <BodyExaminationItem imgSrc={koogeekBP} imgTitle="Blood pressure" handleClick={() => console.log("Clicked BP")} onDisconnect={() => console.log("BP will unmout")}/>
                        <BodyExaminationItem imgSrc={koogeekBT} imgTitle="Body temperature"  handleClick={() => console.log("Clicked BT")} onDisconnect={() => console.log("BT will unmout")}/>
                        <BodyExaminationItem imgSrc={jumperJpd} imgTitle="Pulse oximeter"  handleClick={() => console.log("Clicked HR")} onDisconnect={() => console.log("HR will unmout")}/>
                    </div>
                </div>
            </React.Fragment>
        );
    }
}

export default AddBodyExamination;    