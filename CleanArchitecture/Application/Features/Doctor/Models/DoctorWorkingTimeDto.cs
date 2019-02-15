using System;

namespace Application.Features.Doctor.Models
{
    public class DoctorWorkingTimeDto
    {
        public int? Id { get; set; }

        public int? DoctorId { get; set; }

        public DateTime? Open { get; set; }

        public DateTime? Close { get; set; }
    }
}
