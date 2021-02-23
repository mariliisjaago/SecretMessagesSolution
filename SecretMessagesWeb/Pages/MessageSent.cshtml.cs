using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretMessages_Library.Models;
using SecretMessages_Library.Routines;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class MessageSentModel : PageModel
    {
        private readonly IMessageRoutine _messageRoutine;

        public int UserId { get; set; }
        public string ToUserName { get; set; }
        public string Message { get; set; }

        public bool MessageWasSent { get; set; }

        public MessageSentModel(IMessageRoutine messageRoutine)
        {
            _messageRoutine = messageRoutine;
        }

        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                RedirectToPage("/Index");
            }
        }

        public IActionResult OnPost()
        {
            MessageModel message = new MessageModel()
            {
                FromUserId = UserId,
                Message = Message
            };

            MessageWasSent = _messageRoutine.SendMessage(message, ToUserName);

            return Page();
        }
    }
}
