import toByteArray from "./toByteArrayFromHexSting";

export default rawData => {
    rawData = toByteArray(rawData);

    const systolic = 0xFF & rawData[1];
    const diastolic = 0xFF & rawData[3];
    const heartRate = 0xFF & rawData[14];

    return {
        systolic,
        diastolic,
        heartRate
    };
}