using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Specifications.UserSpecifications
{
    public class UserWithRolesSpecification : BaseSpecification<User>
    {
        public UserWithRolesSpecification(string username)
            : base(u => u.Username == username)
        {
            AddInclude(u => u.UserRoles);
            AddInclude($"{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }

        public UserWithRolesSpecification(int id)
            : base(u => u.Id == id)
        {
            AddInclude(u => u.UserRoles);
            AddInclude($"{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }
    }
}
