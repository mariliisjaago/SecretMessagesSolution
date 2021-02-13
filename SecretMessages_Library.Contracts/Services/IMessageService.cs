using SecretMessages_Library.Models;
using System.Collections.Generic;

namespace SecretMessages_Library.Services
{
    public interface IMessageService
    {
        List<MessageFullModel> GetUnreadMessagesByUserId(int userId);
        void InsertMessageToDatabase(MessageModel message);
        void MarkMessagesAsRead(List<MessageFullModel> newMessages);
    }
}