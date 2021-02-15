namespace SecretMessages_Library.Services
{
    public interface IUserService
    {
        (bool, int) ConfirmUserAndPassword(string userName, string password);
        bool CreateUser(string userName, string password);
        (bool, int) GetUserIdByUserName(string toUserName);
        string GetUserNameById(int userId);
    }
}