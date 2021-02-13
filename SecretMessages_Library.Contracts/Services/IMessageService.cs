using SecretMessages_Library.Models;
using System.Collections.Generic;

namespace SecretMessages_Library.Services
{
    public interface IMessageService
    {
        List<MessageModel> GetMessagesByUserId(int userId);
        void InsertMessageToDatabase(MessageModel message);
    }
}