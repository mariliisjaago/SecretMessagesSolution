namespace SecretMessages_Library.Services
{
    public interface IUserService
    {
        bool ConfirmUser(string userName, string password);
        bool CreateUser(string userName, string password);
    }
}