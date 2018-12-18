using System.Collections.Generic;

namespace Web.Models.ViewModels
{
    public class LoggedUserViewModel
    {
        public string JWT { get; set; }

        public string Username { get; set; }

        public List<string> Roles { get; set; }
    }
}
