using Application.Constants.Patient.Validation;
using Application.Interfaces;
using FluentValidation.Validators;

namespace Application.Helpers.FluentValidators
{
    public class PatientExistsValidator<T> : PropertyValidator
    {
        private readonly IUnitOfWork _context;

        public PatientExistsValidator(IUnitOfWork context) 
            : base(ErrorMessages.PATIENT_NOT_FOUND)
        {
            _context = context;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            int patient = (int)context.PropertyValue;
            return _context.Patients.GetById(patient) != null;
        }
    }
}
