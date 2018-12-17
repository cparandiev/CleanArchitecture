using Domain.Entities.UserAggregate;

namespace Application.Specifications.RoleSpecifications
{
    public class RoleByValueSpecifications : BaseSpecification<Role>
    {
        public RoleByValueSpecifications(Domain.Enums.Role role) 
            : base(r => r.Value == role)
        {
        }
    }
}
