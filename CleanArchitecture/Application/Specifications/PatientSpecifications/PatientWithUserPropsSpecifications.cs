using System;
using System.Linq.Expressions;
using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;

namespace Application.Specifications.PatientSpecifications
{
    public class PatientWithUserPropsSpecifications : BaseSpecification<Patient>
    {
        public PatientWithUserPropsSpecifications(int patientId) 
            : base(p => p.Id == patientId)
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
