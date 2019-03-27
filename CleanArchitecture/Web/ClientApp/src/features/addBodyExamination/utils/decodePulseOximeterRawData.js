import toByteArray from "./toByteArrayFromHexSting";

export default rawData => {
    rawData = toByteArray(rawData);
    
    const pulse = 0xff & rawData[1];
    const spO2 = 0xff & rawData[2];

    return {
        pulse,
        spO2
    }
}