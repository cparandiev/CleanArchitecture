using Domain.Entities.DoctorAggregate;
using Domain.Entities.UserAggregate;

namespace Application.Specifications.DoctorSpecifications
{
    public class DoctorWithUserPropsSpecifications : BaseSpecification<Doctor>
    {
        public DoctorWithUserPropsSpecifications(int userId)
            : base(p => p.User.Id == userId)
        {
            AddInclude(u => u.User);
            AddInclude(u => u.WorkingTimes);
            AddInclude($"{nameof(Doctor.User)}.{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }

        public DoctorWithUserPropsSpecifications(string username)
            : base(p => p.User.Username == username)
        {
            AddInclude(u => u.User);
            AddInclude(u => u.WorkingTimes);
            AddInclude($"{nameof(Doctor.User)}.{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }

        public DoctorWithUserPropsSpecifications(int? doctorId)
            : base(p => p.Id == doctorId)
        {
            AddInclude(u => u.User);
            AddInclude(u => u.WorkingTimes);
            AddInclude($"{nameof(Doctor.User)}.{nameof(User.UserRoles)}.{nameof(UserRole.Role)}");
        }
    }
}
