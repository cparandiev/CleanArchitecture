using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public Enums.Role? Value { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
