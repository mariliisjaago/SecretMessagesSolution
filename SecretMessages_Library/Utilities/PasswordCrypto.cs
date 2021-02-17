using System;
using System.Security.Cryptography;
using System.Text;

namespace SecretMessages_Library.Utilities
{
    public class PasswordCrypto : IPasswordCrypto
    {
        public string CreateSalt()
        {
            int milliseconds = DateTime.Now.Millisecond;

            return milliseconds.ToString();
        }

        public string HashPassword(string password, string salt)
        {
            SHA384 shaM = new SHA384Managed();

            string saltedPassword = SaltPassword(password, salt);

            byte[] saltedPasswordBytes = GetBytesFromASCIIString(saltedPassword);

            byte[] hashedPasswordBytes = shaM.ComputeHash(saltedPasswordBytes);

            string hashedPassword = GetStringFromBytes(hashedPasswordBytes);

            return hashedPassword;
        }

        private string GetStringFromBytes(byte[] bytes)
        {
            string output = Convert.ToBase64String(bytes);

            return output;
        }

        private byte[] GetBytesFromASCIIString(string inputString)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputString);

            return bytes;
        }

        private string SaltPassword(string password, string salt)
        {
            string saltedPassword = password + salt;

            return saltedPassword;
        }
    }
}
