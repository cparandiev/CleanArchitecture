using Application.Features.Patient.Models;
using MediatR;

namespace Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientByUsernameQuery : IRequest<PatientDto>
    {
        public string Username { get; set; }
    }
}
