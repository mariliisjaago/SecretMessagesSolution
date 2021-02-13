using SecretMessages_Library.Models;
using SecretMessages_Library.Services;
using System.Collections.Generic;

namespace SecretMessages_Library.Routines
{
    public class MessageRoutine : IMessageRoutine
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly int _userId;

        public MessageRoutine(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public bool SendMessage(MessageModel message, string toUserName)
        {
            (bool, int) toUserId = _userService.GetUserIdByUserName(toUserName);

            if (toUserId.Item1 == true)
            {
                message = AddToUserIdToMessage(toUserId.Item2, message);

                _messageService.InsertMessageToDatabase(message);

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MessageFullModel> GetNewMessages(int userId)
        {
            List<MessageFullModel> newMessages = _messageService.GetUnreadMessagesByUserId(userId);

            _messageService.MarkMessagesAsRead(newMessages);

            return newMessages;
        }

        private MessageModel AddToUserIdToMessage(int toUserId, MessageModel message)
        {
            message.ToUserId = toUserId;

            return message;
        }
    }
}
