namespace App.UserUseCases
{
    public class UserErrors
    {
        public static readonly Error UserNotFound = new(
            "Users.NotFound",
            "User not found");

        public static readonly Error EmailUsed = new(
            "Users.EmailUsed",
            "The email is already being used");

        public static readonly Error EmailNotMatch = new(
            "Users.EmailNotMatch",
            "The email do not match the confirming email");

        public static readonly Error PasswordNotMatch = new(
            "Users.PasswordNotMatch",
            "The password do not match the confirming password");
    }
}