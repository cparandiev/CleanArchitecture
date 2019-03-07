using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.BodyExamination.Commands.AddPulseRateExamination
{
    public class AddPulseRateExaminationCommand : UserIdentity, IRequest
    {
        public int? PatientId { get; set; }

        public DateTime? ExaminationDate { get; set; }

        public decimal? Rate { get; set; }
    }
}
