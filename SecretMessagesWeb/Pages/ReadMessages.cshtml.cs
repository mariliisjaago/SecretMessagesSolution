using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretMessages_Library.Models;
using SecretMessages_Library.Routines;
using SecretMessages_Library.Services;
using System.Collections.Generic;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class ReadMessagesModel : PageModel
    {
        private readonly IMessageRoutine _messageRoutine;
        private readonly ILookupRoutine _lookupRoutine;
        private readonly IUserService _userService;

        public int UserId { get; set; }

        public string UserName { get; set; }

        public List<MessageFullModel> NewMessages { get; set; }

        public ReadMessagesModel(IMessageRoutine messageRoutine, ILookupRoutine lookupRoutine)
        {
            _messageRoutine = messageRoutine;
            _lookupRoutine = lookupRoutine;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            NewMessages = _messageRoutine.GetNewMessages(UserId);

            if (UserName == null)
            {
                UserName = _lookupRoutine.GetUserNameById(UserId);
            }

            return Page();
        }
    }
}
