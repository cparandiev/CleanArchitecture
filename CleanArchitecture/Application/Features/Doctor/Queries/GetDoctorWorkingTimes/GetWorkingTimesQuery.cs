using Application.Features.Doctor.Models;
using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Doctor.Queries.GetDoctorWorkingTimes
{
    public class GetWorkingTimesQuery : UserIdentity, IRequest<List<DoctorWorkingTimeDto>>
    {
        public int? DoctorId { get; set; }
    }
}
