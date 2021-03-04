using SecretMessages_Library.Models;
using System.Collections.Generic;

namespace SecretMessages_Library.Routines
{
    public interface IMessageRoutine
    {
        List<MessageFullModel> GetNewMessages(int userId);
        bool SendMessage(MessageModel message, string toUserName);
        List<MessageFullModel> GetOldMessages(int userId);
    }
}