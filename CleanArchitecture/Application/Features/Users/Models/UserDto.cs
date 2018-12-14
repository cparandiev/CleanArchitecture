using System.Collections.Generic;

namespace Application.Features.Users.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
