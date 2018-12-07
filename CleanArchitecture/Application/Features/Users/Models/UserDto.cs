using Application.Models;

namespace Application.Features.Users.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public RoleDto Role { get; set; }
    }
}
