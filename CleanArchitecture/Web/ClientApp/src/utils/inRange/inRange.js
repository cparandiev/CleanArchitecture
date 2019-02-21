import { allPass } from "ramda";

const inRange = (low, high) => allPass([
    x => x >= low, 
    x => x <= high
]);

export default inRange;