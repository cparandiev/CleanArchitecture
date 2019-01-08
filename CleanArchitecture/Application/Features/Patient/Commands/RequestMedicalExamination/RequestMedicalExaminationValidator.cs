using Application.Helpers;
using Application.Interfaces;
using FluentValidation;
using System;
using System.Linq;
using Application.Constants.Validation;
using Application.Specifications.DoctorSpecifications;

namespace Application.Features.Patient.Commands.RequestMedicalExamination
{
    public class RequestMedicalExaminationValidator : AbstractValidator<RequestMedicalExaminationCommand>
    {
        private readonly IUnitOfWork _context;

        public RequestMedicalExaminationValidator(IUnitOfWork context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            _context = context;
            
            RuleFor(x => x.DoctorId).NotNull().DoctorExists(context);
            RuleFor(x => x.PatientId).NotNull().PatientExists(context);
            RuleFor(x => x.DurationInMinutes).NotNull().GreaterThan(0);
            RuleFor(x => x.RequestDate).NotNull().GreaterThan(DateTime.Now);

            RuleSet("Second Phase", () => {
                RuleFor(x => x).Must(DoctorToBeFree)
                    .WithMessage(ErrorMessages.UNAVAILABLE_DOCTOR_TIME_RANGE)
                    .OverridePropertyName(ErrorNames.ModelCompossibleErrorName);
            });
        }

        private bool DoctorToBeFree(RequestMedicalExaminationCommand command)
        {
            var date = command.RequestDate.Value;
            var durationInMinutes = command.DurationInMinutes.Value;
            var doctor = _context.Doctors.GetSingleBySpec(new DoctorWithUserPropsSpecifications(command.DoctorId));

            var doctorIsAtWork = doctor.WorkingTimes.Any(w => w.Open <= date && date.AddMinutes(durationInMinutes) <= w.Close);
            if (doctorIsAtWork)
            {
                var doctorIsFree = !doctor.MedicalExaminationRequests
                    .Where(m => m.IsApproved.Value)
                    .Any(m =>
                    {
                        var currentStartTime = m.RequestDate.Value;
                        var currentEndTime = m.RequestDate.Value.AddMinutes(m.DurationInMinutes.Value);
                        var featureStartTime = command.RequestDate.Value;
                        var featureEndTime = command.RequestDate.Value.AddMinutes(command.DurationInMinutes.Value);

                        return (currentStartTime <= featureStartTime && featureStartTime <= currentEndTime) ||
                            (currentStartTime <= featureEndTime && featureEndTime <= currentEndTime);
                    });

                return doctorIsFree;
            }

            return false;
        }
    }
}
