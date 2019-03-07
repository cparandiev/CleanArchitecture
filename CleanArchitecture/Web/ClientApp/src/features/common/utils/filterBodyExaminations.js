import { filter, compose, prop } from "ramda";
import inRange from "../../../utils/inRange";

const whereClause = (from, to) => compose(inRange(from, to), prop('examinationDate'))

export default (from, to) => filter(whereClause(from, to));