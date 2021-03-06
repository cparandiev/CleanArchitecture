﻿using Application.Helpers;
using Application.Helpers.FluentValidators;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Doctor.Commands.SetWeeklyWorkingTime
{
    public class SetWeeklyWorkingTimeCommandValidator : AbstractValidator<SetWeeklyWorkingTimeCommand>
    {
        public SetWeeklyWorkingTimeCommandValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("Authorization Phase", () => {
                RuleFor(x => x.DoctorId)
                    .Equal(x => x.CurrentDoctorId);
            });

            RuleFor(x => x.DoctorId)
                .NotNull()
                .GreaterThan(0)
                .DoctorExists(context);

            RuleFor(x => x.NumOfWeeks)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.WorkingTimes)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.WorkingTimes)
                .SetValidator(new WorkingTimeUnitValidator());
        }
    }
}
