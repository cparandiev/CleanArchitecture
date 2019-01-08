using Domain.Entities.DoctorAggregate;
using Domain.Entities.UserAggregate;

namespace Application.Specifications.DoctorSpecifications
{
    public class DoctorWithUserPropsSpecifications : BaseSpecification<Doctor>
    {
        public DoctorWithUserPropsSpecifications(int userId)
            : base(p => p.User.Id == userId)
        {
            AddIncludes();
        }

        public DoctorWithUserPropsSpecifications(string username)
            : base(p => p.User.Username == username)
        {
            AddIncludes();
        }

        public DoctorWithUserPropsSpecifications(int? doctorId)
            : base(p => p.Id == doctorId)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(u => u.User);
            AddInclude(u => u.WorkingTimes);
            AddInclude(u => u.MedicalExaminationRequests);
            AddInclude($"{nameof(Doctor.User)}.{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }
    }
}
