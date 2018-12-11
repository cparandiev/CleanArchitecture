﻿using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Username { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
