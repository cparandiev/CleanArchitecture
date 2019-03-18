const KOOGEEK_SERVICE_UUID = "0000fff0-0000-1000-8000-00805f9b34fb";
const KS_BP1_ONLINE_MEASUREMENTS_UUID = "0000fff4-0000-1000-8000-00805f9b34fb";
const KS_BP1_OFFLINE_MEASUREMENTS_UUID = "0000fff5-0000-1000-8000-00805f9b34fb";

const bloodPressure = (rawData) => {
    if(rawData[0] == 14) {
        const systolic = 0xFF & rawData[1];
        const diastolic = 0xFF & rawData[3];
        const heartRate = 0xFF & rawData[14];
    
        console.log('Blood pressure measurement');
        console.log(`\tSystolic: ${systolic}`);
        console.log(`\tDiastolic: ${diastolic}`);
        console.log(`\tHeart rate: ${heartRate}`);

        return;
    };

    console.log('Failed to read blood pressure data.');
}

const KS_BT1_ONLINE_MEASUREMENTS_UUID = "0000fff1-0000-1000-8000-00805f9b34fb";
const KS_BT1_OFFLINE_MEASUREMENTS_UUID = "0000fff2-0000-1000-8000-00805f9b34fb";


const bodyTemperature = (rawData) => {
    const temperature = ((0xFF & rawData[7]) << 8 | (0xFF & rawData[8])) * 0.01;
    
    console.log('Body temperature measurement');
    console.log(`\tTemperature: ${temperature}`);
}


const JPD500F_PULSEOXIMETER_SERVICE_UUID = "CDEACB80-5235-4C07-8846-93A37EE6B86D".toLowerCase(); //"00002a37-0000-1000-8000-00805f9b34fb";
const JPD500F_PULSEOXIMETER_CHARACTERISTIC = "CDEACB81-5235-4C07-8846-93A37EE6B86D".toLowerCase();

const pulseOximeter = (rawData) => {
    if (rawData.length >= 4 && rawData[0] == -127) {
        const pulse = 0xff & raw[1];
        const spO2 = 0xff & raw[2];

        console.log('Pulse oximeter measurement');
        console.log(`\tHeart rate: ${pulse}`);
        console.log(`\tOxygen level: ${spO2}`);

        return;
    }

    console.log('Failed to read pulse oximeter data.');
}