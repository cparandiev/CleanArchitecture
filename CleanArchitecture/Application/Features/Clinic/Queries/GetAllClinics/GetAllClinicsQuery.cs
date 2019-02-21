using Application.Features.Clinic.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Clinic.Queries.GetAllClinics
{
    public class GetAllClinicsQuery : IRequest<List<ClinicDto>>
    {
    }
}
