import { slice } from "ramda";

export default (elementPerPage, currentPage) => (elements) =>
    slice(elementPerPage * (currentPage - 1), elementPerPage * currentPage, elements);