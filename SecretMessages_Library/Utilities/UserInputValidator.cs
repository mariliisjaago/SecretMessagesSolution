using SecretMessages_Library.Contracts.Utilities;

namespace SecretMessages_Library.Utilities
{
    public class UserInputValidator : IUserInputValidator
    {
        public bool PasswordEqualsConfirmedPassword(string password, string passwordAgain)
        {
            bool passwordsEqual = true;

            if (password != passwordAgain)
            {
                passwordsEqual = false;
            }

            return passwordsEqual;
        }
    }
}
