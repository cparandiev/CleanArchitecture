import { find, prop, propEq, defaultTo} from "ramda";


export default (clinics, selectedId) => defaultTo([], prop('doctors', find(propEq('id', selectedId), clinics)));