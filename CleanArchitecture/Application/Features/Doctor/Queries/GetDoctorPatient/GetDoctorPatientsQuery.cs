using Application.Features.Patient.Models;
using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Doctor.Queries.GetDoctorPatient
{
    public class GetDoctorPatientsQuery : UserIdentity, IRequest<List<PatientDto>>
    {
        public int? DoctorId { get; set; }
    }
}
