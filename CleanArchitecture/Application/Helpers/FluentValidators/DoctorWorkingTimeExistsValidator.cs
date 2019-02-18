using Application.Constants.Doctor.Validation;
using Application.Interfaces;
using FluentValidation.Validators;

namespace Application.Helpers.FluentValidators
{
    public class DoctorWorkingTimeExistsValidator<T> : PropertyValidator
    {
        private readonly IUnitOfWork _context;

        public DoctorWorkingTimeExistsValidator(IUnitOfWork context)
            : base(ErrorMessages.DOCTOR_WORKING_TIME_NOT_FOUND)
        {
            _context = context;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            int doctorWorkingTimeId = (int)context.PropertyValue;
            return _context.DoctorWorkingTimes.GetById(doctorWorkingTimeId) != null;
        }
    }
}
