using Application.Features.MedicalExaminationRequest.Models;
using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Doctor.Queries.GetDoctorMedicalExaminations
{
    public class GetDoctorMedicalExaminationsQuery : UserIdentity, IRequest<List<MedicalExaminationRequestDto>>
    {
        public int? DoctorId { get; set; }
    }
}
