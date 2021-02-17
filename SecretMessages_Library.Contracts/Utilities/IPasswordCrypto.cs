namespace SecretMessages_Library.Utilities
{
    public interface IPasswordCrypto
    {
        string CreateSalt();
        string HashPassword(string password, string salt);
    }
}