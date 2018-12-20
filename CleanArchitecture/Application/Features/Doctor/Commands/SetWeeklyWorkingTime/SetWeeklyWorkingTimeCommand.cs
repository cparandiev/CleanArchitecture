using Application.Features.Doctor.Models;
using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Application.Features.Doctor.Commands.SetWeeklyWorkingTime
{
    public class SetWeeklyWorkingTimeCommand : IRequest
    {
        public int? DoctorId { get; set; }

        public int? NumOfWeeks { get; set; }

        public IEnumerable<WorkingTimeUnit> WorkingTimes { get; set; }
    }
}
