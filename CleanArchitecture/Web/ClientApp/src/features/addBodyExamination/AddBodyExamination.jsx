import React, { Component } from 'react';
import { connect } from "react-redux";

import BodyExaminationItem from "./components/BodyExaminationItem";
import koogeekBP from "../../images/koogeek-bp1.jpg";
import koogeekBT from "../../images/koogeek-bt1.jpg";
import jumperJpd from "../../images/jumper-jpd-500a.jpg";
import {addBloodPressureExaminationActions, addBloodOxygenExaminationActions, addPulseRateExaminationActions, addBodyTemperatureExaminationActions} from "./actions";
import {decodeBloodPressureRawData, decodeBodyTemperatureRawData, decodePulseOximeterRawData} from "./utils";
import mergeSelectors from "../../utils/mergeSelectors";
import { userSelector } from "../common/selectors";
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

    examineBloodPressure = (rawData) => {
        const {addBloodPressureExamination, user} = this.props;
        const {systolic, diastolic} = decodeBloodPressureRawData(rawData);
        console.log(systolic, diastolic);
        addBloodPressureExamination({systolicBloodPressure: systolic, diastolicBloodPressure: diastolic, patientId: user.patientId, examinationDate: new Date()});
    }

    examineBloodOxygen = (rawData) => {
        const {addBloodOxygenExamination, addPulseRateExamination, user} = this.props;
        const {spO2, pulse} = decodePulseOximeterRawData(rawData);
        console.log(spO2, pulse);
        addBloodOxygenExamination({oxygenLevel: spO2, patientId: user.patientId, examinationDate: new Date()});
        addPulseRateExamination({rate: pulse, patientId: user.patientId, examinationDate: new Date()});
    }

    examineBodyTemperature = (rawData) => {
        const {addBodyTemperatureExamination, user} = this.props;
        const {temperature} = decodeBodyTemperatureRawData(rawData);
        console.log(temperature);
        addBodyTemperatureExamination({temperature, patientId: user.patientId, examinationDate: new Date()});
    }

    render() {
        // this.examineBloodPressure('98774651332');
        // this.examineBloodOxygen('2134235356456546456');
        // this.examineBodyTemperature('3563543463435422844');
        
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

const selectors = [userSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    addBloodPressureExamination: ({systolicBloodPressure, diastolicBloodPressure, patientId, examinationDate}) => dispatch(addBloodPressureExaminationActions.actions.DEFAULT({systolicBloodPressure, diastolicBloodPressure, patientId, examinationDate})),
    addBloodOxygenExamination: ({oxygenLevel, patientId, examinationDate}) => dispatch(addBloodOxygenExaminationActions.actions.DEFAULT({oxygenLevel, patientId, examinationDate})),
    addPulseRateExamination: ({rate, patientId, examinationDate}) => dispatch(addPulseRateExaminationActions.actions.DEFAULT({rate, patientId, examinationDate})),
    addBodyTemperatureExamination: ({temperature, patientId, examinationDate}) => dispatch(addBodyTemperatureExaminationActions.actions.DEFAULT({temperature, patientId, examinationDate})),
});

export default connect(mapStateToProps, mapDispatchToProps)(AddBodyExamination);