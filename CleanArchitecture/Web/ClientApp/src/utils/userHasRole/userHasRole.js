import { includes, prop, pipe } from "ramda";

const userHasRole = (user, role) => pipe(
    prop('roles'),
    includes(role)
)(user);

export default userHasRole;