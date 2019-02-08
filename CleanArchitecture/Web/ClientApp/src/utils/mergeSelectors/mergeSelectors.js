import { converge, mergeAll, unapply } from 'ramda';

export default converge(unapply(mergeAll));