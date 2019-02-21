using FluentValidation.Resources;

namespace Application.Constants.Clinic.Validation
{
    public static class ErrorMessages
    {
        public const string CLINIC_NOT_FOUND = "Clinic not found.";

        public static IStringSource USER_NOT_FOUND { get; internal set; }
    }
}
