using Application.Features.BodyExamination.Models;
using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Patient.Queries.GetPatienBodyExaminations
{
    public class GetPatienBodyExaminationsQuery : UserIdentity, IRequest<List<BodyExaminationResultDto>>
    {
        public int? PatientId { get; set; }
    }
}
