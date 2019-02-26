using Application.Features.MedicalExaminationRequest.Models;
using Application.Helpers;
using Application.Interfaces;
using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Doctor.Queries.GetDoctorMedicalExaminations
{
    public class GetDoctorMedicalExaminationsQueryValidator : AbstractValidator<GetDoctorMedicalExaminationsQuery>
    {
        private readonly IUnitOfWork _context;

        public GetDoctorMedicalExaminationsQueryValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;

            RuleSet("default", () => {
                RuleFor(x => x.DoctorId)
                    .NotNull()
                    .DoctorExists(context);
            });

            RuleSet("Authorization Phase", () => {
                RuleFor(x => x)
                   .Must(VerifyDoctorIdentity);
            });
        }

        private bool VerifyDoctorIdentity(GetDoctorMedicalExaminationsQuery query)
        {
            return query.CurrentDoctorId == query.DoctorId;
        }
    }
}
