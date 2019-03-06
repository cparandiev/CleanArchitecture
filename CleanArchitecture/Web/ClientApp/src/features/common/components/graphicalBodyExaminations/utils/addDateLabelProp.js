import { map } from "ramda";

export default map( item => ({...item, examinationDateShort: item.examinationDate.toString()}))