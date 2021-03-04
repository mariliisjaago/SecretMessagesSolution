using SecretMessages_Library.Contracts.DataAccess;
using SecretMessages_Library.Models;
using SecretMessages_Library.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace SecretMessages_Library.Services
{
    public class SqliteUserService : IUserService
    {
        private readonly ISqlDbAccess _db;
        private readonly IPasswordCrypto _pwCrypto;
        private readonly string connectionStringName = "SqliteDb";

        public SqliteUserService(ISqlDbAccess db, IPasswordCrypto pwCrypto)
        {
            _db = db;
            _pwCrypto = pwCrypto;
        }

        public bool CreateUser(string userName, string password)
        {
            bool userNameIsAvailable = IsUserNameAvailable(userName);

            string salt = _pwCrypto.CreateSalt();

            string hashedPassword = _pwCrypto.HashPassword(password, salt);

            if (userNameIsAvailable)
            {
                string sql = "insert into Users (UserName, Salt, HashedPassword) values (@UserName, @Salt, @HashedPassword);";

                _db.SaveData<dynamic>(sql,
                    new { UserName = userName, Salt = salt, HashedPassword = hashedPassword },
                    connectionStringName);

                return true;
            }
            else
            {
                return false;
            }
        }

        public (bool, int) ConfirmUserAndPassword(string userName, string password)
        {
            string sql = "select * from Users where UserName = @UserName";

            List<UserModel> matchingUsers = _db.LoadData<UserModel, dynamic>(sql,
                                                                            new { UserName = userName },
                                                                            connectionStringName);
            if (matchingUsers.Count > 0)
            {
                UserModel user = matchingUsers.First();

                (bool, int) result = ConfirmPasswordHashAndReturnUserId(user, password);

                return result;
            }
            else
            {
                return (false, -1);
            }
        }

        private (bool, int) ConfirmPasswordHashAndReturnUserId(UserModel user, string password)
        {
            string hashedPassword = _pwCrypto.HashPassword(password, user.Salt);

            if (hashedPassword == user.HashedPassword)
            {
                return (true, user.Id);
            }
            else
            {
                return (false, -1);
            }

        }

        public (bool, int) GetUserIdByUserName(string toUserName)
        {
            string sql = "select * from Users where UserName = @UserName;";

            var users = _db.LoadData<UserModel, dynamic>(sql, new { UserName = toUserName }, connectionStringName);

            if (users.Count > 0)
            {
                return (true, users.First().Id);
            }
            else
            {
                return (false, -1);
            }
        }

        public string GetUserNameById(int userId)
        {
            string sql = "select UserName from Users where Id = @Id;";

            string userName = _db.LoadData<UserModel, dynamic>(sql, new { Id = userId }, connectionStringName).First().UserName;

            return userName;
        }

        private bool IsUserNameAvailable(string userName)
        {
            string sql = "select * from Users u where u.UserName = @UserName";

            List<UserModel> users = _db.LoadData<UserModel, dynamic>(sql, new { UserName = userName }, connectionStringName);

            if (users.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
