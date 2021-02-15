using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class SignUpModel : PageModel
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }

        public string PasswordAgain { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
