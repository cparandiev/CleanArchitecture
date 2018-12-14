using System;
using System.Linq.Expressions;
using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;

namespace Application.Specifications.PatientSpecifications
{
    public class PatientWithUserPropsSpecifications : BaseSpecification<Patient>
    {
        public PatientWithUserPropsSpecifications(int userId) 
            : base(p => p.User.Id == userId)
        {
            AddInclude(u => u.User);
            AddInclude($"{nameof(User)}.{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }
    }
}
