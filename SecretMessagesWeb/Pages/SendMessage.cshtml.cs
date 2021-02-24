using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretMessages_Library.Routines;
using Microsoft.AspNetCore.Http;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class SendMessageModel : PageModel
    {
        private readonly IMessageRoutine _messageRoutine;

        public int UserId { get; set; }
        public string ToUserName { get; set; }
        public string Message { get; set; }

        public string UserName { get; set; }


        public SendMessageModel(IMessageRoutine messageRoutine)
        {
            _messageRoutine = messageRoutine;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                UserId = (int)HttpContext.Session.GetInt32("UserId");
                UserName = HttpContext.Session.GetString("UserName");
            }
            else
            {
                RedirectToPage("/Index");
            }
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
