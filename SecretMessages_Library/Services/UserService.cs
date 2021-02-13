using SecretMessages_Library.Contracts.DataAccess;
using SecretMessages_Library.Models;
using System.Collections.Generic;

namespace SecretMessages_Library.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlDbAccess _db;
        private readonly string connectionStringName = "SqliteDb";

        public UserService(ISqlDbAccess db)
        {
            _db = db;
        }

        public bool CreateUser(string userName, string password)
        {
            bool userNameIsAvailable = IsUserNameAvailable(userName);

            if (userNameIsAvailable)
            {
                string sql = "insert into Users (UserName, Password) values (@UserName, @Password);";

                _db.SaveData<dynamic>(sql, new { UserName = userName, Password = password }, connectionStringName);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ConfirmUser(string userName, string password)
        {
            string sql = "select * from Users where UserName = @UserName and Password = @Password;";

            List<UserModel> matchingUsers = _db.LoadData<UserModel, dynamic>(sql,
                                                                            new { UserName = userName, Password = password },
                                                                            connectionStringName);
            if (matchingUsers.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
