using Application.Models;
using MediatR;
using System;

namespace Application.Features.BodyExamination.Commands.AddBloodOxygenLevelExamination
{
    public class AddBloodOxygenLevelExaminationCommand : UserIdentity, IRequest
    {
        public int? PatientId { get; set; }

        public DateTime? ExaminationDate { get; set; }

        public decimal? OxygenLevel { get; set; }
    }
}
