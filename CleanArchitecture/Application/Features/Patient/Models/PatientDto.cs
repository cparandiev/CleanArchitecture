using Application.Features.Users.Models;

namespace Application.Features.Patient.Models
{
    public class PatientDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }
    }
}
