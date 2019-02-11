import {pick, compose, mapObjIndexed, keys, merge, values} from 'ramda';

export default (navbarConfig, routesConfig) => compose(
    values,
    mapObjIndexed((value, key) => merge(value, navbarConfig[key])),
    pick(keys(navbarConfig)),
)(routesConfig);