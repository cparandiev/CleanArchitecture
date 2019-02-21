using Application.Features.MedicalExaminationRequest.Models;
using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Patient.Queries.GetPatientMedicalExaminations
{
    public class GetPatientMedicalExaminationsQuery : UserIdentity, IRequest<List<MedicalExaminationRequestDto>>
    {
        public int? PatientId { get; set; }
    }
}
