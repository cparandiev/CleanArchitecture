using Application.Models;
using MediatR;
using System;

namespace Application.Features.BodyЕxamination.Commands.AddBloodPressureExamination
{
    public class AddBloodPressureExaminationCommand : UserIdentity, IRequest
    {
        public int? PatientId { get; set; }

        public DateTime? ЕxaminationDate { get; set; }

        public decimal? SystolicBloodPressure { get; set; }

        public decimal? DiastolicBloodPressure { get; set; }
    }
}
