using Application.Features.Patient.Models;
using Application.Models;
using MediatR;

namespace Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientByIdQuery : UserIdentity, IRequest<PatientDto>
    {
        public int? PatientId { get; set; }
    }
}
