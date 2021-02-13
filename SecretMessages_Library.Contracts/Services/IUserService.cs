namespace SecretMessages_Library.Services
{
    public interface IUserService
    {
        (bool, int) ConfirmUser(string userName, string password);
        bool CreateUser(string userName, string password);
        (bool, int) GetUserIdByUserName(string toUserName);
        string GetUserNameById(int userId);
    }
}