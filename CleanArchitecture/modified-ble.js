const toByteArray = hexString => {
    if(hexString.length % 2 > 0) {
        hexString = "0" + hexString;
    }
    var result = [];
    while (hexString.length >= 2) {
      result.push(parseInt(hexString.substring(0, 2), 16));
      hexString = hexString.substring(2, hexString.length);
    }
    return result;
}

const bloodPressure = (rawData) => {
    rawData = toByteArray(rawData);

    const systolic = 0xFF & rawData[1];
    const diastolic = 0xFF & rawData[3];
    const heartRate = 0xFF & rawData[14];

    console.log('Blood pressure measurement');
    console.log(`\tSystolic: ${systolic}`);
    console.log(`\tDiastolic: ${diastolic}`);
    console.log(`\tHeart rate: ${heartRate}`);
}



const KOOGEEK_SERVICE_UUID = "0000fff0-0000-1000-8000-00805f9b34fb";
const KS_BP1_ONLINE_MEASUREMENTS_UUID = "0000fff4-0000-1000-8000-00805f9b34fb";
const KS_BP1_OFFLINE_MEASUREMENTS_UUID = "0000fff5-0000-1000-8000-00805f9b34fb";

//#region raw data
// 00002a00-0000-1000-8000-00805f9b34fb - 0x546f6d546f705f4865616c7468 // maybe correct blood pressure
// 00002a04-0000-1000-8000-00805f9b34fb - 0x5000a0000000e803
// 00002a23-0000-1000-8000-00805f9b34fb - 0x5843cd4248056460
// 00002a24-0000-1000-8000-00805f9b34fb - 0x30343136
// 00002a25-0000-1000-8000-00805f9b34fb - 0x3430303138383232
// 00002a26-0000-1000-8000-00805f9b34fb - 0x3136313032363031
// 00002a27-0000-1000-8000-00805f9b34fb - 0x5031333332313041
// 00002a28-0000-1000-8000-00805f9b34fb - 0x5843cd4248056460
// 00002a24-0000-1000-8000-00805f9b34fb - 0x30343136
// 00002a25-0000-1000-8000-00805f9b34fb - 0x3430303138383232
// 00002a26-0000-1000-8000-00805f9b34fb - 0x3136313032363031
// 00002a27-0000-1000-8000-00805f9b34fb - 0x5031333332313041
// 00002a28-0000-1000-8000-00805f9b34fb - 0x3534375430313430
// 00002a29-0000-1000-8000-00805f9b34fb - 0x426f7567682054656368 // maybe correct blood pressure
// 00002a2a-0000-1000-8000-00805f9b34fb - 0xfe006578706572696d656e74616c
// 00002a50-0000-1000-8000-00805f9b34fb - 0x0100bb03120002
// 00002908-0000-1000-8000-00805f9b34fb - 0x0401
// 00002901-0000-1000-8000-00805f9b34fb - 0x53797374656d2053657474696e67 // maybe correct blood pressure
// 00002901-0000-1000-8000-00805f9b34fb - 0x46756e6374696f6e20436f6e74726f6c // maybe correct blood pressure
// 00002901-0000-1000-8000-00805f9b34fb - 0x4d6561737572656d656e74 // maybe correct blood pressure
// 0000fff6-0000-1000-8000-00805f9b34fb - 0x4f41445331363039 // maybe correct blood pressure
// 00002901-0000-1000-8000-00805f9b34fb - 0x4f4144204669726d777261726520566572 // maybe correct heart rate
// 0000fff7-0000-1000-8000-00805f9b34fb - 0xe30703140a2123
// 00002901-0000-1000-8000-00805f9b34fb - 0x4461746520616e642054696d65
//#endregion

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

const bloodPressure2 = (rawData) => {
    const systolic = 0xFF & rawData[1];
    const diastolic = 0xFF & rawData[3];
    const heartRate = 0xFF & rawData[14];

    console.log('Blood pressure measurement');
    console.log(`\tSystolic: ${systolic}`);
    console.log(`\tDiastolic: ${diastolic}`);
    console.log(`\tHeart rate: ${heartRate}`);
}

const KS_BT1_ONLINE_MEASUREMENTS_UUID = "0000fff1-0000-1000-8000-00805f9b34fb";
const KS_BT1_OFFLINE_MEASUREMENTS_UUID = "0000fff2-0000-1000-8000-00805f9b34fb";


//#region raw data
// 00002a00-0000-1000-8000-00805f9b34fb - 0x4b532d425431
// 00002a04-0000-1000-8000-00805f9b34fb - 0x5000a0000000e803
// 00002a19-0000-1000-8000-00805f9b34fb - 0x56
// 00002a23-0000-1000-8000-00805f9b34fb - 0x28d6850000a9ce10
// 00002a24-0000-1000-8000-00805f9b34fb - 0x4d6f64656c204e756d626572
// 00002a25-0000-1000-8000-00805f9b34fb - 0x313431373532303133333638
// 00002a26-0000-1000-8000-00805f9b34fb - 0x302e3620284a616e203235203230313829
// 00002a27-0000-1000-8000-00805f9b34fb - 0x302e36
// 00002a28-0000-1000-8000-00805f9b34fb - 0x42302e3537
// 00002a29-0000-1000-8000-00805f9b34fb - 0x202020
// 00002a2a-0000-1000-8000-00805f9b34fb - 0xfe006578706572696d656e74616c
// 00002a50-0000-1000-8000-00805f9b34fb - 0x010d0000001001
// 00002901-0000-1000-8000-00805f9b34fb - 0x43686172616374657269737469632031
// 0000fff2-0000-1000-8000-00805f9b34fb - 0xc00100000000000000c1
// 00002901-0000-1000-8000-00805f9b34fb - 0x43686172616374657269737469632032
//#endregion


const bodyTemperature = (rawData) => {
    rawData = toByteArray(rawData);
    
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