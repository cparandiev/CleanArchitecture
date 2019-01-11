using Application.Interfaces;
using FluentValidation.Validators;
using Application.Constants.Validation;

namespace Application.Helpers.FluentValidators
{
    public class MedicalExaminationRequestExistsValidator<T> : PropertyValidator
    {
        private readonly IUnitOfWork _context;

        public MedicalExaminationRequestExistsValidator(IUnitOfWork context)
            : base(ErrorMessages.MEDICAL_EXAMINATION_REQUEST_NOT_FOUND)
        {
            _context = context;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            int requestId = (int)context.PropertyValue;
            return _context.MedicalExaminationRequests.GetById(requestId) != null;
        }
    }
}
