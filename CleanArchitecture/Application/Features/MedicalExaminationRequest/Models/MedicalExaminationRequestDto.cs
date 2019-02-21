using Application.Features.MedicalExaminationResult.Models;
using System;

namespace Application.Features.MedicalExaminationRequest.Models
{
    public class MedicalExaminationRequestDto
    {
        public int? Id { get; set; }

        public bool? IsApproved { get; set; }

        public bool? IsAccomplished { get; set; }

        public DateTime? RequestDate { get; set; }

        public int? DurationInMinutes { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }

        public string Clinic { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public MedicalExaminationResultDto Result { get; set; }
    }
}
