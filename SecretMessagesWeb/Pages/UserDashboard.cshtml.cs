using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class UserDashboardModel : PageModel
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
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
    }
}
