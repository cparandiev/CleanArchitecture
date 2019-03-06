using Application.Models;
using MediatR;
using System;

namespace Application.Features.BodyЕxamination.Commands.AddBloodOxygenLevelExamination
{
    public class AddBloodOxygenLevelExaminationCommand : UserIdentity, IRequest
    {
        public int? PatientId { get; set; }

        public DateTime? ЕxaminationDate { get; set; }

        public decimal? OxygenLevel { get; set; }
    }
}
