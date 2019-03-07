using Application.Features.BodyЕxamination.Models;
using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Patient.Queries.GetPatienBodyЕxaminations
{
    public class GetPatienBodyЕxaminationsQuery : UserIdentity, IRequest<List<BodyЕxaminationResultDto>>
    {
        public int? PatientId { get; set; }
    }
}
