using SecretMessages_Library.Contracts.DataAccess;
using SecretMessages_Library.Models;
using System.Collections.Generic;

namespace SecretMessages_Library.Services
{
    public class SqlMessageService : IMessageService
    {
        private readonly ISqlDbAccess _db;
        private readonly string connectionStringName = "SqlDb";

        public SqlMessageService(ISqlDbAccess db)
        {
            _db = db;
        }

        public List<MessageFullModel> GetOldMessagesByUserId(int userId)
        {
            string sql = "select m.*, u.UserName from dbo.Messages m " +
                "left join dbo.Users u on m.FromUserId = u.Id " +
                "where ToUserId = @ToUserId and IsRead = 1;";

            List<MessageFullModel> messages = _db.LoadData<MessageFullModel, dynamic>(sql, new { ToUserId = userId }, connectionStringName);

            return messages;
        }

        public List<MessageFullModel> GetUnreadMessagesByUserId(int userId)
        {
            string sql = "select m.*, u.UserName from dbo.Messages m " +
                "left join dbo.Users u on m.FromUserId = u.Id " +
                "where ToUserId = @ToUserId and IsRead = 0;";

            List<MessageFullModel> unreadMessages = _db.LoadData<MessageFullModel, dynamic>(sql,
                new { ToUserId = userId }, connectionStringName);

            return unreadMessages;
        }

        public void InsertMessageToDatabase(MessageModel message)
        {
            string sql = "insert into dbo.Messages (Message, FromUserId, ToUserId, IsRead) values " +
                "(@Message, @FromUserId, @ToUserId, @IsRead);";

            _db.SaveData<dynamic>(sql, new { message.Message, message.FromUserId, message.ToUserId, message.IsRead }, connectionStringName);
        }

        public void MarkMessagesAsRead(List<MessageFullModel> newMessages)
        {
            string sql = "update dbo.Messages " +
                "set IsRead = 1 " +
                "where Id = @Id;";

            foreach (var item in newMessages)
            {
                _db.SaveData<dynamic>(sql, new { Id = item.Id }, connectionStringName);
            }
        }
    }
}
