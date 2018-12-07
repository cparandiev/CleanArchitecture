using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Specifications.UserSpecifications
{
    public class UserWithUsernameSpecification : BaseSpecification<User>
    {
        public UserWithUsernameSpecification(string username)
            : base(u => u.Username == username) { }
    }
}
