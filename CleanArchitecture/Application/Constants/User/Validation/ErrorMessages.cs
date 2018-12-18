namespace Application.Constants.User.Validation
{
    public static class ErrorMessages
    {
        public const string UNIQUE_USERNAME = "Username must be unique.";
        public const string PASSWORD_REQUIREMENTS = "Password must contain at least one lower case char, upper case char, digit and symbol.";
        public const string EMAIL_REQUIREMENTS = "Invalid email address.";
        public const string INVALID_CREDENTIALS = "Invalid username or password.";
        public const string USER_NOT_FOUND = "User not found.";
    }
}
