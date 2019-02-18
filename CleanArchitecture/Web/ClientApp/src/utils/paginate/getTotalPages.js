import { length, divide } from "ramda";

export default (elementPerPage, elements) => Math.ceil(divide(length(elements), elementPerPage));