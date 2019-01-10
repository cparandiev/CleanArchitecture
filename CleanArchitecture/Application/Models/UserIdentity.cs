using Domain.Enums;
using System.Collections.Generic;

namespace Application.Models
{
    public class UserIdentity
    {
        public UserIdentity()
            : this(null, null, null, new List<string>())
        { }
        public UserIdentity(int? userId, int? doctorId, int? patientId, List<string> roles)
        {
            CurrentUserId = userId;
            CurrentDoctorId = doctorId;
            CurrentPatientId = patientId;
            CurrentRoles = roles;
        }
        public int? CurrentUserId { get; set; }
        public int? CurrentDoctorId { get; set; }
        public int? CurrentPatientId { get; set; }
        public IEnumerable<string> CurrentRoles { get; set; }
    }
}
