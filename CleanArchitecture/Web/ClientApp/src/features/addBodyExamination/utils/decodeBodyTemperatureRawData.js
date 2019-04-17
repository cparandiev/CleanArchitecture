export default rawData => {
    const temperature = ((0xFF & rawData[7]) << 8 || (0xFF & rawData[8])) * 0.01;
    
    return {temperature}
}