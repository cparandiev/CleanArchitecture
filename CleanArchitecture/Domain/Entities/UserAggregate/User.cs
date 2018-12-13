using Domain.Entities.AdminAggregate;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.PatientAggregate;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities.UserAggregate
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public DateTime? Birthdate { get; set; }

        public Gender? Gender { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public Blood? Blood { get; set; }
        
        public virtual Admin Admin { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
