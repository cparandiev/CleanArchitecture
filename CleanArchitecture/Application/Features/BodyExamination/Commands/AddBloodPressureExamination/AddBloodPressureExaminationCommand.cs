using Application.Models;
using MediatR;
using System;

namespace Application.Features.BodyExamination.Commands.AddBloodPressureExamination
{
    public class AddBloodPressureExaminationCommand : UserIdentity, IRequest
    {
        public int? PatientId { get; set; }

        public DateTime? ExaminationDate { get; set; }

        public decimal? SystolicBloodPressure { get; set; }

        public decimal? DiastolicBloodPressure { get; set; }
    }
}
