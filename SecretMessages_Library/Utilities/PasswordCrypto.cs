using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace SecretMessages_Library.Utilities
{
    public static class PasswordCrypto
    {
        public static string CreateSaltUsingNowTime()
        {
            int milliseconds = DateTime.Now.Millisecond;

            return milliseconds.ToString();
        }

        public static string SaltAndHashPassword(string password, string salt)
        {
            SHA384 shaM = new SHA384Managed();

            string saltedPassword = password + salt;

            byte[] saltedPasswordBytes = Encoding.ASCII.GetBytes(saltedPassword);

            byte[] hashedPasswordBytes = shaM.ComputeHash(saltedPasswordBytes);

            string hashedPassword = Convert.ToBase64String(hashedPasswordBytes);

            return hashedPassword;
        }

        
    }
}
