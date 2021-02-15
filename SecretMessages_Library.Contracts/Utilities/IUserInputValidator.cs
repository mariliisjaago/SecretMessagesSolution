namespace SecretMessages_Library.Contracts.Utilities
{
    public interface IUserInputValidator
    {
        bool PasswordEqualsConfirmedPassword(string password, string passwordAgain);
    }
}