using MediatR;
using System;

namespace Application.Features.Patient.Commands.RequestMedicalExamination
{
    public class RequestMedicalExaminationCommand : IRequest
    {
        public DateTime? RequestDate { get; set; }

        public int? DurationInMinutes { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }
    }
}
