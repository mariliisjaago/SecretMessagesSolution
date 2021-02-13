using SecretMessages_Library.Services;

namespace SecretMessages_Library.Routines
{
    public class LookupRoutine : ILookupRoutine
    {
        private readonly IUserService _userService;

        public LookupRoutine(IUserService userService)
        {
            _userService = userService;
        }

        public string GetUserNameById(int userId)
        {
            return _userService.GetUserNameById(userId);
        }
    }
}
