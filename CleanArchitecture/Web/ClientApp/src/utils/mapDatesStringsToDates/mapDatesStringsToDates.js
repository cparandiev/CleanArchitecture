import { map, lensPath, set, path, reduce } from "ramda";

const mapObj = (obj, elPath) => set(lensPath(elPath), new Date(path(elPath, obj)), obj);

export default (paths) => map((obj) => reduce(mapObj, obj, paths))