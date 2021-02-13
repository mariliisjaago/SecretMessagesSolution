using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretMessages_Library.Models;
using SecretMessages_Library.Routines;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class ReadMessagesModel : PageModel
    {
        private readonly IMessageRoutine _messageRoutine;

        public int UserId { get; set; }

        public List<MessageFullModel> NewMessages { get; set; }

        public ReadMessagesModel(IMessageRoutine messageRoutine)
        {
            _messageRoutine = messageRoutine;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            NewMessages = _messageRoutine.GetNewMessages(UserId);

            return Page();
        }
    }
}
