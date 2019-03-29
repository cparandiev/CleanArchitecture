import toByteArray from "./toByteArrayFromHexSting";

export default rawData => {
    rawData = toByteArray(rawData);
    
    const temperature = ((0xFF & rawData[7]) << 8 || (0xFF & rawData[8])) * 0.01;
    
    return {temperature}
}