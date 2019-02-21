using Application.Features.Doctor.Models;
using System.Collections.Generic;

namespace Application.Features.Clinic.Models
{
    public class ClinicDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<DoctorDto> Doctors { get; set; }
    }
}
