using Application.Features.Patient.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientQuery : IRequest<PatientDto>
    {
        public int UserId { get; set; }
    }
}
