import { sortBy, prop } from "ramda";

export default sortBy(prop('requestDate'));