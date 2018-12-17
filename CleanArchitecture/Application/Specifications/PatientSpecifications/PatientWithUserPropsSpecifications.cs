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
            AddInclude($"{nameof(Patient.User)}.{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }

        public PatientWithUserPropsSpecifications(string username)
            : base(p => p.User.Username == username)
        {
            AddInclude(u => u.User);
            AddInclude($"{nameof(Patient.User)}.{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }
    }
}
