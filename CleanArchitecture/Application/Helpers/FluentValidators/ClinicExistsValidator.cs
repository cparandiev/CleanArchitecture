using Application.Constants.Clinic.Validation;
using Application.Interfaces;
using FluentValidation.Validators;

namespace Application.Helpers.FluentValidators
{
    public class ClinicExistsValidator<T> : PropertyValidator
    {
        private readonly IUnitOfWork _context;

        public ClinicExistsValidator(IUnitOfWork context) 
            : base(ErrorMessages.CLINIC_NOT_FOUND)
        {
            _context = context;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            int clinicId = (int)context.PropertyValue;
            return _context.Clinics.GetById(clinicId) != null;
        }
    }
}
