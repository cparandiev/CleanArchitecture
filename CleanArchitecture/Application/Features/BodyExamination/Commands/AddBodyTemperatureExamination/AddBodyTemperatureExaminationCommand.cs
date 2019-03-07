using Application.Models;
using MediatR;
using System;

namespace Application.Features.BodyExamination.Commands.AddBodyTemperatureExamination
{
    public class AddBodyTemperatureExaminationCommand : UserIdentity, IRequest
    {
        public int? PatientId { get; set; }

        public DateTime? ExaminationDate { get; set; }

        public decimal? Temperature { get; set; }
    }
}
