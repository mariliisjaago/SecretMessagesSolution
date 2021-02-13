using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretMessages_Library.Routines;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class SendMessageModel : PageModel
    {
        private readonly IMessageRoutine _messageRoutine;

        public int UserId { get; set; }
        public string ToUserName { get; set; }
        public string Message { get; set; }


        public SendMessageModel(IMessageRoutine messageRoutine)
        {
            _messageRoutine = messageRoutine;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
