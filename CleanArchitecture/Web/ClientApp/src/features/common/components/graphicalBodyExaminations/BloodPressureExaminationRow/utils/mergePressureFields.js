import { map } from "ramda";

export default map(item => ({...item, bloodPressure: [item.diastolicBloodPressure, item.systolicBloodPressure]}))