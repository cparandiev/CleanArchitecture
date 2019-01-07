using System.Collections.Generic;

namespace Web.Models.ViewModels
{
    public abstract class LoggedUserViewModel
    {
        public int UserId { get; set; }

        public string JWT { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public List<string> Roles { get; set; }
    }
}
