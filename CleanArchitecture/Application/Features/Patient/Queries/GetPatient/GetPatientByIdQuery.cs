using Application.Features.Patient.Models;
using MediatR;

namespace Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientByIdQuery : IRequest<PatientDto>
    {
        public int UserId { get; set; }
    }
}
