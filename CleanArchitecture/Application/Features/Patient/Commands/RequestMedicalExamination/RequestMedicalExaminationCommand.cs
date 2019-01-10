using Application.Models;
using MediatR;
using System;

namespace Application.Features.Patient.Commands.RequestMedicalExamination
{
    public class RequestMedicalExaminationCommand : UserIdentity, IRequest
    {
        public DateTime? RequestDate { get; set; }

        public int? DurationInMinutes { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }
    }
}
