using SecretMessages_Library.Services;

namespace SecretMessages_Library.Routines
{
    public class LoginRoutine
    {
        private readonly IUserService _userService;

        public LoginRoutine(IUserService userService)
        {
            _userService = userService;
        }

        public bool SignUp(string userName, string password)
        {
            return _userService.CreateUser(userName, password);
        }

        public (bool, int) SignIn(string userName, string password)
        {
            return _userService.ConfirmUser(userName, password);
        }
    }
}
