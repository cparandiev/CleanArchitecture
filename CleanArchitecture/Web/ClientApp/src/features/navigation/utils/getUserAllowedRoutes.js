import {pick, compose, values, mergeAll} from 'ramda';

export default (userRoles, navbarConfigs) => compose(
    mergeAll,
    values,
    pick(['base', ...userRoles])
)(navbarConfigs);
  