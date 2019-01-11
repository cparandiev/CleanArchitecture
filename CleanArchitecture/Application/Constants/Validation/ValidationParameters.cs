namespace Application.Constants.Validation
{
    public static class ValidationParameters
    {
        public const string PASSWORD_REGEX = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W)";
        public const string EMAIL_REGEX = @"^[^@]+@[^\.]+\..+$";
        public const int NOTES_MIN_LENGTH = 10;
        public const int NOTES_MAX_LENGTH = 200;
    }
}
