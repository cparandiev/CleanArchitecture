using Application.Helpers;
using Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.BodyExamination.Commands.AddPulseRateExamination
{
    public class AddPulseRateExaminationCommandValidator : AbstractValidator<AddPulseRateExaminationCommand>
    {
        private readonly IUnitOfWork _context;

        public AddPulseRateExaminationCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;

            RuleSet("default", () =>
            {
                RuleFor(x => x.PatientId)
                    .NotNull();

                RuleFor(x => x.ExaminationDate)
                    .NotNull();

                RuleFor(x => x.Rate)
                    .NotNull();
            });

            RuleSet("Authorization Phase", () =>
            {
                RuleFor(x => x.PatientId)
                    .PatientExists(context);
            });

            RuleSet("Second Phase", () =>
            {
                RuleFor(x => x.Rate)
                    .GreaterThan(0)
                    .LessThan(200);
            });
        }
    }
}
