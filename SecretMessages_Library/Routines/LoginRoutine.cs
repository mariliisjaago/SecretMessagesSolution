using SecretMessages_Library.Contracts.Utilities;
using SecretMessages_Library.Services;

namespace SecretMessages_Library.Routines
{
    public class LoginRoutine : ILoginRoutine
    {
        private readonly IUserService _userService;
        private readonly IUserInputValidator _validator;

        public LoginRoutine(IUserService userService, IUserInputValidator validator)
        {
            _userService = userService;
            _validator = validator;
        }

        public bool SignUp(string userName, string password)
        {
            return _userService.CreateUser(userName, password);
        }

        public (bool, int) SignIn(string userName, string password)
        {
            return _userService.ConfirmUserAndPassword(userName, password);
        }

        public bool ValidatePassword(string password, string passwordAgain)
        {
            bool isValidPassword = _validator.PasswordEqualsConfirmedPassword(password, passwordAgain);

            return isValidPassword;
        }
    }
}
