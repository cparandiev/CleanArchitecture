using System.Collections.Generic;

namespace Domain.Entities.UserAggregate
{
    public class Role : BaseEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public Enums.Role? Value { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
