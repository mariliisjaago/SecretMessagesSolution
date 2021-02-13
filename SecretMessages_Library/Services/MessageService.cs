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

        public List<MessageFullModel> GetUnreadMessagesByUserId(int userId)
        {
            string sql = "select m.*, u.UserName from Messages m " +
                "left join Users u on m.FromUserId = u.Id " +
                "where ToUserId = @ToUserId and IsRead = 0;";

            List<MessageFullModel> unreadMessages = _db.LoadData<MessageFullModel, dynamic>(sql,
                new { ToUserId = userId }, connectionStringName);

            return unreadMessages;
        }

        public void MarkMessagesAsRead(List<MessageFullModel> newMessages)
        {
            string sql = "update Messages " +
                "set IsRead = 1 " +
                "where Id = @Id;";

            foreach (var item in newMessages)
            {
                _db.SaveData<dynamic>(sql, new { Id = item.Id }, connectionStringName);
            }
        }

    }
}
