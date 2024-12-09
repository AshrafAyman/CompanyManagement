namespace Common;

public static class Constants
{
    public static class ConstantErrorCodes
    {
        public const int InternalError500 = 5000;
        public const int ValidationError400 = 4003;
        public const int BadRequestError400 = 4000;
        public const int NotFoundError404 = 4004;
    }

    public static class ConstantErrorMessages
    {
        public const string InternalErrorMessage = "Something bad happened :(";
        public const string NotFoundErrorMessage = "Not Found Data";
        public const string BadRequestErrorMessage = "BadRequest Data";
        public const string ValidationErrorMessage = "Validation failed";
    }

    public static class ConstantRegex
    {
        public const string EmailRegexPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    }
}
