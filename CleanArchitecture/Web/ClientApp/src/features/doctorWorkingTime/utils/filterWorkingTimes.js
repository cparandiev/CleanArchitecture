import { filter, allPass, compose, prop } from "ramda";

const inRange = (low, high) => allPass([
    x => x >= low, 
    x => x <= high
]);

const whereClause = (from, to) => compose(inRange(from, to), prop('open'))

export default (from, to) => filter(whereClause(from, to));