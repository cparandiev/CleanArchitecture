using Application.Models;
using MediatR;
using System;

namespace Application.Features.BodyЕxamination.Commands.AddBodyTemperatureExamination
{
    public class AddBodyTemperatureExaminationCommand : UserIdentity, IRequest
    {
        public int? PatientId { get; set; }

        public DateTime? ЕxaminationDate { get; set; }

        public decimal? Temperature { get; set; }
    }
}
