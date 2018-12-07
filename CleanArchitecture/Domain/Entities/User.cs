using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public Role? Role { get; set; }
    }
}
