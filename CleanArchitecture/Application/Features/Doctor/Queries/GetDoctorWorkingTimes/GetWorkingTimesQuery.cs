using Application.Features.Doctor.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Doctor.Queries.GetDoctorWorkingTimes
{
    public class GetWorkingTimesQuery : IRequest<List<DoctorWorkingTimeDto>>
    {
        public int? DoctorId { get; set; }
    }
}
