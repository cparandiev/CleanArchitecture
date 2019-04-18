import React, { Component } from 'react';
import { connect } from "react-redux";
import { isNil } from "ramda";

import { notification } from "../common/actions";
import BodyExaminationItem from "./components/BodyExaminationItem";
import BodyTemperatureOnline from "./components/BodyTemperatureOnline";
import BloodPressureOnline from "./components/BloodPressureOnline";
import PulseOximeterOnline from "./components/PulseOximeterOnline";
import koogeekBP from "../../images/koogeek-bp1.jpg";
import koogeekBT from "../../images/koogeek-bt1.jpg";
import jumperJpd from "../../images/jumper-jpd-500a.jpg";
import {addBloodPressureExaminationActions, addBloodOxygenExaminationActions, addPulseRateExaminationActions, addBodyTemperatureExaminationActions} from "./actions";
import {decodeBloodPressureRawData, decodeBodyTemperatureRawData, decodePulseOximeterRawData, toByteArrayFromHexSting} from "./utils";
import mergeSelectors from "../../utils/mergeSelectors";
import { userSelector } from "../common/selectors";
import "./add-body-examination.css";

class AddBodyExamination extends Component {
    state = {selectedExamination: null};
    bluetoothDevice = null;
    
    connectBluetoothDevice = ({service_uuid, characteristic_uuid, decoder}) => {
        navigator.bluetooth
            .requestDevice({ 
                acceptAllDevices: true,
                optionalServices: [service_uuid]
            })
            .then(device => {
                this.bluetoothDevice = device;
                return device.gatt.connect();   
            })
            .then(server => server.getPrimaryService(service_uuid))
            .then(service => service.getCharacteristic(characteristic_uuid))
            .then(characteristic => characteristic.startNotifications())
            .then(characteristic => {
                characteristic.addEventListener(
                    'characteristicvaluechanged',
                    (e) => {
                        console.log(e);
                        let value = e.target.value;
                        let a = [];
                        for (let i = 0; i < value.byteLength; i++) {
                        a.push(('00' + value.getUint8(i).toString(16)).slice(-2));
                        }
                        console.log(a);
                        decoder(toByteArrayFromHexSting(a.join('')));
                    }
                );
            })
            .catch(error => { 
                this.props.notifyForFailedConnection();
                // this.disconnectBluetoothDevice();
                console.log(error); 
            });
    }

    disconnectBluetoothDevice = () => {
        this.setState({selectedExamination: null});
        if(this.bluetoothDevice){    
            this.bluetoothDevice.gatt.disconnect();
            this.bluetoothDevice = null;
        }
    }

    examineBloodPressure = (rawData) => {
        const {addBloodPressureExamination, user} = this.props;
        const {systolic, diastolic} = decodeBloodPressureRawData(rawData);

        this.setState(state => ({...state, systolic, diastolic}));
        addBloodPressureExamination({systolicBloodPressure: systolic, diastolicBloodPressure: diastolic, patientId: user.patientId, examinationDate: new Date()});
    }

    examineBloodOxygen = (rawData) => {
        const {addBloodOxygenExamination, addPulseRateExamination, user} = this.props;

        if (rawData.length === 4 && rawData[3] !== '00') {
            const {spO2, pulse} = decodePulseOximeterRawData(rawData);
            
            this.setState(state => ({...state, spO2, pulse}));
            addPulseRateExamination({rate: pulse, patientId: user.patientId, examinationDate: new Date()});
            addBloodOxygenExamination({oxygenLevel: spO2, patientId: user.patientId, examinationDate: new Date()});
        }
    }

    examineBodyTemperature = (rawData) => {
        const {addBodyTemperatureExamination, user} = this.props;
        const {temperature} = decodeBodyTemperatureRawData(rawData);
        
        this.setState(state => ({...state, temperature}));
        addBodyTemperatureExamination({temperature, patientId: user.patientId, examinationDate: new Date()});
    }

    componentWillUnmount() {
        this.disconnectBluetoothDevice();
    }

    render() {
        const { selectedExamination, temperature } = this.state;

        return (
            <React.Fragment>
                {isNil(selectedExamination) &&
                <div style={{fontWeight: 'bold', color: 'black', fontSize: '40px', textAlign: 'center', marginBottom: "50px"}}>
                    Select body examination
                </div>}
                <div className="container d-flex justify-content-center">
                    <div className="row">
                        {
                            isNil(selectedExamination) &&   
                            <BodyExaminationItem
                                imgSrc={koogeekBP}
                                imgTitle="Blood pressure" 
                                handleClick={() => {
                                    this.setState({selectedExamination: 'blood pressure'});
                                    this.connectBluetoothDevice({
                                        service_uuid: '0000fff0-0000-1000-8000-00805f9b34fb', 
                                        characteristic_uuid: '0000fff4-0000-1000-8000-00805f9b34fb',
                                        decoder: this.examineBloodPressure
                                    })
                                }}
                            />
                        }
                        {
                            selectedExamination === "blood pressure" &&
                            <BloodPressureOnline 
                                imgSrc={koogeekBP}
                                handleClose={this.disconnectBluetoothDevice}
                            />
                        }
                        {
                            isNil(selectedExamination) &&   
                            <BodyExaminationItem 
                                imgSrc={koogeekBT}
                                imgTitle="Body temperature"
                                handleClick={() => {
                                    this.setState({selectedExamination: 'body temperature'});
                                    this.connectBluetoothDevice({
                                        service_uuid: '0000fff0-0000-1000-8000-00805f9b34fb', 
                                        characteristic_uuid: '0000fff1-0000-1000-8000-00805f9b34fb',
                                        decoder: this.examineBodyTemperature
                                    })
                                }}
                            />
                        }
                        {
                            selectedExamination === "body temperature" &&
                            <BodyTemperatureOnline 
                                imgSrc={koogeekBT}
                                temperature={temperature}
                                handleClose={this.disconnectBluetoothDevice}
                            />
                        }
                        {
                            isNil(selectedExamination) &&   
                            <BodyExaminationItem
                                imgSrc={jumperJpd}
                                imgTitle="Pulse oximeter" 
                                handleClick={() => {
                                    this.setState({selectedExamination: 'pulse oximeter'});
                                    this.connectBluetoothDevice({
                                        service_uuid: 'cdeacb80-5235-4c07-8846-93a37ee6b86d', 
                                        characteristic_uuid: 'cdeacb81-5235-4c07-8846-93a37ee6b86d',
                                        decoder: this.examineBloodOxygen
                                    })
                                }} 
                            />
                        }
                        {
                            selectedExamination === "pulse oximeter" &&
                            <PulseOximeterOnline 
                                imgSrc={jumperJpd}
                                handleClose={this.disconnectBluetoothDevice}
                            />
                        }
                    </div>
                </div>
            </React.Fragment>
        );
    }
}

const selectors = [userSelector];

const mapStateToProps = mergeSelectors(selectors);

const mapDispatchToProps = (dispatch) => ({
    notifyForFailedConnection: () => dispatch(notification.actions.NOTIFY_ERROR('Bluetooth connection failed!')),
    addBloodPressureExamination: ({systolicBloodPressure, diastolicBloodPressure, patientId, examinationDate}) => dispatch(addBloodPressureExaminationActions.actions.DEFAULT({systolicBloodPressure, diastolicBloodPressure, patientId, examinationDate})),
    addBloodOxygenExamination: ({oxygenLevel, patientId, examinationDate}) => dispatch(addBloodOxygenExaminationActions.actions.DEFAULT({oxygenLevel, patientId, examinationDate})),
    addPulseRateExamination: ({rate, patientId, examinationDate}) => dispatch(addPulseRateExaminationActions.actions.DEFAULT({rate, patientId, examinationDate})),
    addBodyTemperatureExamination: ({temperature, patientId, examinationDate}) => dispatch(addBodyTemperatureExaminationActions.actions.DEFAULT({temperature, patientId, examinationDate})),
});

export default connect(mapStateToProps, mapDispatchToProps)(AddBodyExamination);