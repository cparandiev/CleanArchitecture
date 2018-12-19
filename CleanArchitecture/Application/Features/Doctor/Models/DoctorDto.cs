using Application.Features.Patient.Models;
using Application.Features.Users.Models;

namespace Application.Features.Doctor.Models
{
    public class DoctorDto
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }

        public string Summary { get; set; }

        public UserDto User { get; set; }
    }
}
