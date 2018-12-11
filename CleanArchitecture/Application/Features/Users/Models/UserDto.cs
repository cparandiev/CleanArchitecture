using Application.Models;
using System.Collections.Generic;

namespace Application.Features.Users.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
