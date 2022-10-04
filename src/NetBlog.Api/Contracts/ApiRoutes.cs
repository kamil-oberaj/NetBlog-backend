namespace NetBlog.Api.Contracts;

public static class ApiRoutes
{
    public const string Base = "api";

    public static class Identity
    {
        public const string SignUp = Base + "/identity/signUp";
        public const string SignIn = Base + "/identity/signIn";
        public const string ChangePassword = Base + "/identity/changePassword";
        public const string ConfirmEmail = Base + "/identity/confirmEmail";
        public const string ResetPassword = Base + "/identity/resetPassword";
    }
}