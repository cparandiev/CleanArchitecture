using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.BodyЕxamination.Commands.AddPulseRateExamination
{
    public class AddPulseRateExaminationCommand : UserIdentity, IRequest
    {
        public int? PatientId { get; set; }

        public DateTime? ЕxaminationDate { get; set; }

        public decimal? Rate { get; set; }
    }
}
