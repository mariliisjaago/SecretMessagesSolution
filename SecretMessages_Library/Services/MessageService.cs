using SecretMessages_Library.Contracts.DataAccess;
using SecretMessages_Library.Models;
using System.Collections.Generic;

namespace SecretMessages_Library.Services
{
    public class MessageService : IMessageService
    {
        private readonly ISqlDbAccess _db;
        private readonly UserModel _user;
        private readonly string connectionStringName = "SqliteDb";

        public MessageService(ISqlDbAccess db)
        {
            _db = db;
        }

        public void InsertMessageToDatabase(MessageModel message)
        {
            string sql = "insert into Messages (Message, FromUserId, ToUserId, IsRead) values " +
                "(@Message, @FromUserId, @ToUserId, @IsRead);";

            _db.SaveData<dynamic>(sql, new { message.Message, message.FromUserId, message.ToUserId, message.IsRead }, connectionStringName);
        }

        public List<MessageModel> GetMessagesByUserId(int userId)
        {
            return new List<MessageModel>();
        }

    }
}
