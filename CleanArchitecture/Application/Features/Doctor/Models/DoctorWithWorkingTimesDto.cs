using Application.Features.Users.Models;
using System.Collections.Generic;

namespace Application.Features.Doctor.Models
{
    public class DoctorWithWorkingTimesDto
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }

        public string Summary { get; set; }

        public UserDto User { get; set; }

        public List<DoctorWorkingTimeDto> WorkingTimes { get; set; }
    }
}
