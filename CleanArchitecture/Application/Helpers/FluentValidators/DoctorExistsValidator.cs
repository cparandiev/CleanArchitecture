using Application.Constants.Doctor.Validation;
using Application.Interfaces;
using FluentValidation.Validators;

namespace Application.Helpers.FluentValidators
{
    public class DoctorExistsValidator<T> : PropertyValidator
    {
        private readonly IUnitOfWork _context;

        public DoctorExistsValidator(IUnitOfWork context) 
            : base(ErrorMessages.DOCTOR_NOT_FOUND)
        {
            _context = context;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            int doctorId = (int)context.PropertyValue;
            return _context.Doctors.GetById(doctorId) != null;
        }
    }
}
