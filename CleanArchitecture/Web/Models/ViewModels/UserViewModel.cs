﻿using System;
using System.Collections.Generic;

namespace Web.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string Blood { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
