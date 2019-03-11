using Application.Helpers;
using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Doctor.Queries.GetDoctorPatient
{
    public class GetDoctorPatientsQueryValidator : AbstractValidator<GetDoctorPatientsQuery>
    {
        private readonly IUnitOfWork _context;

        public GetDoctorPatientsQueryValidator(IUnitOfWork context)
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
                    .Must(x => x.DoctorId == x.CurrentDoctorId);
            });
        }
    }
}
